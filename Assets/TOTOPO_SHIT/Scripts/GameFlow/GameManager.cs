using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public bool _masterTowerDestroyed = false;
    public AudioSource _canvasAudioSource;
    public AudioClip[] _sounds;

    public delegate void RegularTowerDestroyed();
    public event RegularTowerDestroyed OnRegularTowerDestroyed;

    private int _defaultMoves = 0;
    private bool _bReady = false;

    private void Awake ()
    {
        GameInstance.SetCurrentGameManager(this);
        _defaultMoves = _movesLeft;
    }

    private void Start ()
    {
        StartCoroutine(Loop());
    }

    public void RegularTowerHit(int pNumberOfMovesToAdd)
    {
        if (OnRegularTowerDestroyed != null) OnRegularTowerDestroyed();
        AddMove(pNumberOfMovesToAdd);
    }

    // Keep this method for cheating. On regular game flow, external scripts call RegularTowerHit, not this one.
    public void AddMove (int pNumberOfMovesToAdd)
    {
        _movesLeft += pNumberOfMovesToAdd;
        //Debug.Log("Adding " + pNumberOfMovesToAdd + " moves. " + _movesLeft + " moves left.");
    }

    public void SubtractMove(int pNumberOfMovesToSubtract)
    {
        _movesLeft -= pNumberOfMovesToSubtract;
        if (_movesLeft <= 0)
        {
            _movesLeft = 0;
        }
        //Debug.Log("Subtracting " + pNumberOfMovesToSubtract + " moves. " + _movesLeft + " moves left.");
    }

    public void MasterTowerDestroyed ()
    {
        _masterTowerDestroyed = true;
        //Debug.Log("Master Tower Destroyed.");
    }

    public void SetReady ()
    {
        _bReady = true;
    }

    private IEnumerator Loop ()
    {
        yield return StartCoroutine(GameReady());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameOver());
    }

    private IEnumerator GameReady ()
    {
        StartCoroutine(PlaySound(0)); // Ready!!
        //Debug.Log("Ready!");
        GameInstance.GetCurrentWindowManager().Open(0);
        while (!_bReady)
        {
            yield return new WaitForSeconds(_loopDelay);
        }
    }

    private IEnumerator GamePlaying ()
    {
        StartCoroutine(PlaySound(1)); // Go!
        GameInstance.GetCurrentWindowManager().Open(1);
        _gameState = EGameState.Playing;
        while (!(_movesLeft <= 0 || _masterTowerDestroyed))
        {
            //Debug.Log("Tick!");
            yield return new WaitForSeconds(_loopDelay);
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(_loopDelay);
        if (_masterTowerDestroyed)
        {
            StartCoroutine(PlaySound(2)); // Congratulations!!
            GameInstance.GetCurrentWindowManager().Open(2);
            _gameState = EGameState.Win;
            //Debug.Log("You Won!");
        }
        else
        {
            StartCoroutine(PlaySound(3)); // Game Over
            GameInstance.GetCurrentWindowManager().Open(3);
            _gameState = EGameState.Lose;
            //Debug.Log("You Died!");
        }
    }

    private IEnumerator PlaySound(int pIndex)
    {
        yield return new WaitForSeconds(_loopDelay);
        _canvasAudioSource.clip = _sounds[pIndex];
        _canvasAudioSource.Play();
    }

    public void Reset ()
    {
        /*
        _gameState = EGameState.Ready;
        _movesLeft = _defaultMoves;
        _masterTowerDestroyed = false;
        _bReady = false;
        GameInstance.GetCurrentGameController().ResetGame();
        //Debug.Log("Restarting the game.");
        StopAllCoroutines();
        StartCoroutine(Loop());
        */
        StopAllCoroutines();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
    }
}
