using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayingUIWindow : BaseWindow
{
    public Text _movesLeftCounter;

    private void Update ()
    {
        _movesLeftCounter.text = GameInstance.GetCurrentGameManager()._movesLeft.ToString();
    }
}
