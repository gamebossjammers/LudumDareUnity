using UnityEngine;
using System.Collections;

public static class InputManager {

	public static Vector2 leftJoy = new Vector2 (0,0);
	public static Vector2 rightJoy = new Vector2 (0,0);

	public static bool launchButton = false;
	public static bool cameraZoom = false;
	public static bool cameraTypeChange = false;

	private static Vector2 mousePreviousPosition = new Vector2 (0,0);
	private static bool mouseClicked = false;

	// Update is called once per frame
	public static void checkInputs () 
	{
		InputManager.leftJoy = new Vector2 (0, 0);
		InputManager.rightJoy = new Vector2 (0, 0);
		InputManager.launchButton = false;
		InputManager.cameraZoom = false;
		InputManager.cameraTypeChange = false;

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



		if ( Input.GetMouseButtonDown (0) && !InputManager.mouseClicked)
		{
			InputManager.mousePreviousPosition = Input.mousePosition ;
			InputManager.mouseClicked = true;
		}
		if ( Input.GetMouseButton(0) && InputManager.mouseClicked)
		{
			InputManager.rightJoy = ( (Vector2)Input.mousePosition - InputManager.mousePreviousPosition).normalized * 3;

			InputManager.mousePreviousPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0))
		{
			InputManager.mouseClicked = false;
		}


		// BUTTONS
		InputManager.launchButton = ( Input.GetKeyDown (KeyCode.Space) ) ? true : false;
		InputManager.cameraZoom = ( Input.GetKeyDown (KeyCode.Q) ) ? true : false;
		InputManager.cameraTypeChange = ( Input.GetKeyDown (KeyCode.E) ) ? true : false;

		Debug.Log (rightJoy);

	}
}
