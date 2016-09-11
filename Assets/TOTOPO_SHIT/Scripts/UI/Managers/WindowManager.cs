using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour
{
    /// <summary>List of windows in the scene</summary>
    public BaseWindow[] _windows;

    /// <summary>Current window index from the list</summary>
    [SerializeField]
    private int _currentWindowIndex = -1;
    /// <summary>Default window from the list</summary>
    [SerializeField]
    private int _defaultWindowIndex = 0;


    private void Awake()
    {
        GameInstance.SetCurrentWindowManager(this);
    }

    /// <summary>
    /// Gets the window from the list in the given position.
    /// </summary>
    /// <param name="value">Position of the window to get</param>
    /// <returns>The Window in that position</returns>
    public BaseWindow GetWindow(int value)
    {
        return _windows[value];
    }


    /// <summary>
    /// Opens the window in the given position and closes the rest.
    /// </summary>
    /// <param name="value">Position of the window to open</param>
    private void ToggleVisibility(int value)
    {
        for (int i = 0; i < _windows.Length; i++)
        {
            var window = _windows[i];
            if (i == value)
            {
                // We need to set the gameObject active from here before we call the Open
                window.gameObject.SetActive(true);
                window.Open();
            }
            else if (window.gameObject.activeSelf)
            {
                window.Close();
            }
        }
    }


    /// <summary>
    /// Opens the given window, closes the rest,
    /// sets the opened window as the current one and returns the window.
    /// </summary>
    /// <param name="value">Position of the window to open in the array</param>
    /// <returns>The opened window</returns>
    public BaseWindow Open(int value)
    {
        if (value < 0 || value >= _windows.Length)
        {
            return null;
        }
        _currentWindowIndex = value;
        ToggleVisibility(value);

        return GetWindow(value);
    }


    /// <summary>
    /// Closes the active window(if any).
    /// </summary>
    public void Close()
    {
        if (_currentWindowIndex > 0 && _currentWindowIndex < _windows.Length)
        {
            BaseWindow window = GetWindow(_currentWindowIndex);
            if (window != null && window.gameObject.activeSelf)
            {
                window.Close();
                _currentWindowIndex = -1;
            }
        }
    }


    // Registers the manager and opens the default window
    void Start()
    {
        //BaseWindow._manager = this;
        Open(_defaultWindowIndex);
    }
}
