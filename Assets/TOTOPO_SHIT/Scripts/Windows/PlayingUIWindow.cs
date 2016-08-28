using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayingUIWindow : BaseWindow
{
    public Text _movesLeftCounter;
    public GameObject _regularTowerPanel;
    public float _regularTowerPanelDelay = 2f;

    void OnEnable()
    {
        GameInstance.GetCurrentGameManager().OnRegularTowerDestroyed += ShowRegularTowerPanel;
    }


    void OnDisable()
    {
        //if (GameInstance.GetCurrentGameManager().OnRegularTowerDestroyed != null)
        GameInstance.GetCurrentGameManager().OnRegularTowerDestroyed -= ShowRegularTowerPanel;
    }

    private void Update ()
    {
        _movesLeftCounter.text = GameInstance.GetCurrentGameManager()._movesLeft.ToString();
    }

    public void Restart ()
    {
        GameInstance.GetCurrentGameManager().Reset();
    }

    private void ShowRegularTowerPanel ()
    {
        _regularTowerPanel.SetActive(true);
        StartCoroutine(HideRegularTowerPanel());
    }

    private IEnumerator HideRegularTowerPanel ()
    {
        yield return new WaitForSeconds(_regularTowerPanelDelay);
        _regularTowerPanel.SetActive(false);
    }
}
