﻿using UnityEngine;

public class GameManagerTester : MonoBehaviour
{
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) GameInstance.GetCurrentGameManager().AddMove(1);
        if (Input.GetKeyDown(KeyCode.Alpha2)) GameInstance.GetCurrentGameManager().SubtractMove(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) GameInstance.GetCurrentGameManager().MasterTowerDestroyed();
        if (Input.GetKeyDown(KeyCode.Alpha4)) GameInstance.GetCurrentGameManager().Reset();
    }
}
