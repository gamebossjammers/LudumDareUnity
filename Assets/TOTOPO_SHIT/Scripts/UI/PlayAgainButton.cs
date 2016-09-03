using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour
{
    public void Reset ()
    {
        GameInstance.GetCurrentGameManager().Reset();
    }
}
