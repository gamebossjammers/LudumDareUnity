using UnityEngine;

public class SequencedPanelManager : MonoBehaviour 
{
    /// <summary>List of panels in the window</summary>
    public BasePanel[] _panels;

    /// <summary>Current panel from the list</summary>
    [SerializeField]
    private BasePanel _currentPanel;
    /// <summary>Default panel from the list</summary>
    [SerializeField]
    private BasePanel _defaultPanel;


    // Registers the manager and opens the default window
    private void OnEnable()
    {
        Debug.Log("opening panel");
        //BasePanel._manager = this;
        Open(_defaultPanel);
    }


    /// <summary>
    /// Opens the given panel and closes the rest.
    /// </summary>
    /// <param name="pPanel">Panel to open</param>
    private void ToggleVisibility(BasePanel pPanel)
    {
        for (int i = 0; i < _panels.Length; i++)
        {
            var panel = _panels[i];
            if (_panels[i] == pPanel)
            {
                // We need to set the gameObject active from here before we call the Open
                panel.gameObject.SetActive(true);
                panel.Open();
            }
            else if (panel.gameObject.activeSelf)
            {
                panel.Close();
            }
        }
    }


    /// <summary>
    /// Opens the given panel, closes the rest,
    /// sets the opened panel as the current one.
    /// </summary>
    /// <param name="pPanel">Panel to open</param>
    public void Open(BasePanel pPanel)
    {
        if (pPanel != null)
        {
            _currentPanel = pPanel;
            ToggleVisibility(pPanel); 
        }
    }


    /// <summary>
    /// Closes the active panel(if any).
    /// </summary>
    public void Close()
    {
        if (_currentPanel != null && _currentPanel.gameObject.activeSelf)
        {
            _currentPanel.Close();
            _currentPanel = null;
        }
    }

    public void OpenNextPanel ()
    {
        Open(_currentPanel._nextPanel);
    }

    public void OpenPreviousPanel()
    {
        Open(_currentPanel._previousPanel);
    }
}
