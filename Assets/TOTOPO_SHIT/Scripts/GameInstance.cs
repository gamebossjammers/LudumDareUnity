using UnityEngine;
using System.Collections;

public class GameInstance : Singleton<GameInstance>
{
    protected GameInstance () {}

    private static GameManager _currentGameManager;

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
}
