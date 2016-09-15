using UnityEngine;
using System.Collections;

public class ReadyWindow : BaseWindow
{
    public void SetReady()
    {
        GameInstance.GetCurrentGameManager().SetReady();
    }
}
