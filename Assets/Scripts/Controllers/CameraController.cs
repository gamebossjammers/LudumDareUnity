using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	private enum cameraStates
	{
		onPosition,
		topView
	}

	private cameraStates currentState;

	private List<int> zoomDistances = new List<int> ();
	private int zoomPosition;

	// Use this for initialization
	void Start () 
	{
		currentState = cameraStates.onPosition;
		this.zoomPosition = 0;
		zoomDistances.Add (24);
		zoomDistances.Add (32);
		zoomDistances.Add (40);
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.R))
		{
			this.currentState = (this.currentState == cameraStates.onPosition) ? cameraStates.topView : cameraStates.onPosition; 
		}

		//Debug.Log (currentState);

		switch (currentState)
		{
			case cameraStates.onPosition:
			this.rotateAround();
			break;
			case cameraStates.topView:
			this.viewTop();
			break;
		}
			

	}

	public void rotateAround()
	{
		
		float CATAPULT_ROTATION = 50 * Time.deltaTime;

		float horizontalPosition = this.transform.eulerAngles.y;
		float verticalPosition = this.transform.eulerAngles.z;

		if (Input.GetKey (KeyCode.RightArrow))
		{
			horizontalPosition += (CATAPULT_ROTATION);
		} 
		else if (Input.GetKey (KeyCode.LeftArrow))
		{
			horizontalPosition -= (CATAPULT_ROTATION);
		}


		if (Input.GetKey (KeyCode.UpArrow))
		{
			verticalPosition += (CATAPULT_ROTATION);
		} 
		else if (Input.GetKey (KeyCode.DownArrow))
		{
			verticalPosition -= (CATAPULT_ROTATION);
		}

		this.transform.eulerAngles = new Vector3( 0, horizontalPosition , verticalPosition );


		// ZOOM

		if ( Input.GetKeyDown(KeyCode.Q) )
		{

			zoomPosition++;

			zoomPosition = (zoomPosition > 2) ? 0 : zoomPosition;

			Transform cameraTransform = Camera.main.transform;

			cameraTransform.localPosition = new Vector3 (cameraTransform.localPosition.x, zoomDistances[zoomPosition], cameraTransform.localPosition.z);
		}
	}

	public void viewTop()
	{

	}
}
