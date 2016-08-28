using UnityEngine;
using System.Collections;

public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () {}

    private static GameManager _currentGameManager;
    private static WindowManager _currentWindowManager;
    private static GameController _currentGameController;

    /// <summary>
    /// Returns the instance of the current level game manager.
    /// The game manager holds info of the current game state.
    /// </summary>
    /// <returns>The current level game manager instance</returns>
    public static GameManager GetCurrentGameManager()
    {
        return _currentGameManager;
    }


    /// <summary>
    /// When the Game Manager is loaded, 
    /// it registers itself into the GameInstance with this method.
    /// </summary>
    /// <param name="pGameManager">Current level Game Manager</param>
    public static void SetCurrentGameManager(GameManager pGameManager)
    {
        _currentGameManager = pGameManager;
    }

    /// <summary>
    /// Returns the instance of the current level window manager.
    /// The window manager controls the UI panel flow.
    /// </summary>
    /// <returns>The current level window manager instance</returns>
    public static WindowManager GetCurrentWindowManager()
    {
        return _currentWindowManager;
    }


    /// <summary>
    /// When the Window Manager is loaded, 
    /// it registers itself into the GameInstance with this method.
    /// </summary>
    /// <param name="pWindowManager">Current level Game Manager</param>
    public static void SetCurrentWindowManager(WindowManager pWindowManager)
    {
        _currentWindowManager = pWindowManager;
    }

    /// <summary>
    /// Returns the instance of the current level game controller.
    /// The game controller manages the catapult.
    /// </summary>
    /// <returns>The current level game controller instance</returns>
    public static GameController GetCurrentGameController()
    {
        return _currentGameController;
    }


    /// <summary>
    /// When the GameController is loaded, 
    /// it registers itself into the GameInstance with this method.
    /// </summary>
    /// <param name="pGameController">Current level Game Controller</param>
    public static void SetCurrentGameController(GameController pGameController)
    {
        _currentGameController = pGameController;
    }
}
