using System.Collections;
using UnityEngine;


public enum EGameState
{
    Ready,
    Playing,
    Win,
    Lose
}

public class GameManager : MonoBehaviour
{
    public float _loopDelay = 1f;
    public int _movesLeft = 3;
    public EGameState _gameState = EGameState.Ready;
    public bool _bMasterTowerDestroyed = false;

    private int _defaultMoves = 0;


    private void Awake ()
    {
        GameInstance.SetCurrentGameManager(this);
        _defaultMoves = _movesLeft;
    }

    private void Start ()
    {
        StartCoroutine(Loop());
    }

    public void AddMove (int pNumberOfMovesToAdd)
    {
        _movesLeft += pNumberOfMovesToAdd;
        Debug.Log("Adding " + pNumberOfMovesToAdd + " moves. " + _movesLeft + " moves left.");
    }

    public void SubtractMove(int pNumberOfMovesToSubtract)
    {
        _movesLeft -= pNumberOfMovesToSubtract;
        if (_movesLeft <= 0)
        {
            _movesLeft = 0;
        }
        Debug.Log("Subtracting " + pNumberOfMovesToSubtract + " moves. " + _movesLeft + " moves left.");
    }

    public void MasterTowerDestroyed ()
    {
        _bMasterTowerDestroyed = true;
        Debug.Log("Master Tower Destroyed.");
    }

    public IEnumerator GameOver ()
    {
        yield return new WaitForSeconds(_loopDelay);
        if (_bMasterTowerDestroyed)
        {
            GameInstance.GetCurrentWindowManager().Open(2);
            _gameState = EGameState.Win;
            Debug.Log("You Won!");
        }
        else
        {
            GameInstance.GetCurrentWindowManager().Open(3);
            _gameState = EGameState.Lose;
            Debug.Log("You Died!");
        }
    }

    private IEnumerator Loop ()
    {
        yield return StartCoroutine(GameReady());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameOver());
    }

    private IEnumerator GameReady ()
    {
        Debug.Log("Ready!");
        GameInstance.GetCurrentWindowManager().Open(0);
        yield return new WaitForSeconds(_loopDelay);
    }

    private IEnumerator GamePlaying ()
    {
        GameInstance.GetCurrentWindowManager().Open(1);
        while (!(_movesLeft <= 0 || _bMasterTowerDestroyed))
        {
            Debug.Log("Tick!");
            yield return new WaitForSeconds(_loopDelay);
        }
    }

    public void Reset ()
    {
        _gameState = EGameState.Ready;
        _movesLeft = _defaultMoves;
        _bMasterTowerDestroyed = false;
        Debug.Log("Restarting the game.");
        StopAllCoroutines();
        StartCoroutine(Loop());
    }
}
