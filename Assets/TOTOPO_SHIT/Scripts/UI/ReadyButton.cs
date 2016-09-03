using UnityEngine;
using System.Collections;

public class ReadyButton : MonoBehaviour
{
    public void SetReady ()
    {
        GameInstance.GetCurrentGameManager().SetReady();
    }
}
