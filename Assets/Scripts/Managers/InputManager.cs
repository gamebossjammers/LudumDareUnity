using UnityEngine;
using System.Collections;

public static class InputManager {

	public static Vector2 leftJoy = new Vector2 (0,0);
	public static Vector2 rightJoy = new Vector2 (0,0);

	
	// Update is called once per frame
	public static void checkInputs () 
	{
		InputManager.leftJoy = new Vector2 (0, 0);
		InputManager.rightJoy = new Vector2 (0, 0);

		// LEFT JOYSTICK
		InputManager.leftJoy.x = ( Input.GetKey (KeyCode.D) ) ? leftJoy.x + 1 : leftJoy.x;
		InputManager.leftJoy.x = ( Input.GetKey (KeyCode.A) ) ? leftJoy.x - 1 : leftJoy.x;

		InputManager.leftJoy.y = ( Input.GetKey (KeyCode.W) ) ? leftJoy.y + 1 : leftJoy.y;
		InputManager.leftJoy.y = ( Input.GetKey (KeyCode.S) ) ? leftJoy.y - 1 : leftJoy.y;

		// RIGHT JOYSTICK
		InputManager.rightJoy.x = ( Input.GetKey (KeyCode.RightArrow) ) ? rightJoy.x + 1 : rightJoy.x;
		InputManager.rightJoy.x = ( Input.GetKey (KeyCode.LeftArrow) ) ? rightJoy.x - 1 : rightJoy.x;

		InputManager.rightJoy.y = ( Input.GetKey (KeyCode.UpArrow) ) ? rightJoy.y + 1 : rightJoy.y;
		InputManager.rightJoy.y = ( Input.GetKey (KeyCode.DownArrow) ) ? rightJoy.y - 1 : rightJoy.y;

	}
}
