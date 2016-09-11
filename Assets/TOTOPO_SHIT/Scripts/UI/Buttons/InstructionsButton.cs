using UnityEngine;

public class InstructionsButton : MonoBehaviour 
{
	public void Show ()
    {
        GameInstance.GetCurrentGameManager().ShowInstructions();
    }

    public void Hide()
    {
        GameInstance.GetCurrentGameManager().HideInstructions();
    }
}
