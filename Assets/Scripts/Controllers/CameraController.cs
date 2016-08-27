using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class CameraController : MonoBehaviour {

	public Transform cataCrux;
	public Transform mainCamera;
	public Transform ball;

	private readonly float TOP_VIEW_SPEED = 20;
	private readonly float CAMERA_ROTATION_SPEED = 50;

	private Vector3 cameraRotation;

	private enum cameraStates
	{
		onPosition,
		topView,
		flyingBall
	}

	private cameraStates currentState;

	private List<int> zoomDistances = new List<int> ();
	private int zoomPosition;

	// Use this for initialization
	void Start () 
	{

		this.transform.position = this.cataCrux.transform.position;

		currentState = cameraStates.onPosition;
		this.zoomPosition = 0;
		zoomDistances.Add (24);
		zoomDistances.Add (32);
		zoomDistances.Add (40);
	}

	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.R) && currentState != cameraStates.flyingBall)
		{
			if (this.currentState == cameraStates.onPosition)
			{
				this.currentState = cameraStates.topView;
			
				this.transform.localPosition = new Vector3 (0, 2.46f, 0);
				this.transform.localEulerAngles = new Vector3 (0, 0, 0);

				Camera.main.transform.localPosition = new Vector3 (-8, 150, 0);
				Camera.main.transform.localEulerAngles = new Vector3 (90, 270, 0);
				//Camera.main.orthographic = true;
			} 
			else if ( this.currentState == cameraStates.topView )
			{
				this.transform.localPosition = new Vector3 (0, 2.46f, 0);
				this.transform.localEulerAngles = new Vector3 (0, 0, -90);

				Camera.main.transform.localPosition = new Vector3 (-8, 24, 0);
				Camera.main.transform.localEulerAngles = new Vector3 (90, -270, -180);

				this.currentState = cameraStates.onPosition;

			}
				
		}

		//Debug.Log (currentState);

		InputManager.checkInputs ();

	}

	public void LateUpdate()
	{
		switch (currentState)
		{
		case cameraStates.onPosition:
			this.rotateAround();
			break;
		case cameraStates.flyingBall:
			this.transform.localPosition = this.ball.transform.localPosition;
			this.rotateAround();
			break;
		case cameraStates.topView:
			this.viewTop();
			break;
		}

	}

	public void rotateAround()
	{

		float horizontalPosition = this.transform.eulerAngles.y + (InputManager.rightJoy.x * CAMERA_ROTATION_SPEED * Time.deltaTime);
		float verticalPosition = this.transform.eulerAngles.z + (InputManager.rightJoy.y * CAMERA_ROTATION_SPEED * Time.deltaTime);

		this.transform.eulerAngles = new Vector3( 0, horizontalPosition , verticalPosition );

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

		float horizontalMovement = InputManager.rightJoy.x * this.TOP_VIEW_SPEED * Time.deltaTime;
		float verticalMovement = InputManager.rightJoy.y * this.TOP_VIEW_SPEED * Time.deltaTime;

		Camera.main.transform.Translate(horizontalMovement,verticalMovement,0);
	
	}

	public void followBall()
	{
		this.currentState = cameraStates.flyingBall;
	}

	/*
	public void trembleScreen( float trembleTime_ )
	{

		Vector3 initialPosition = Camera.main.transform.localPosition;
		Vector3 initialRotation = Camera.main.transform.localEulerAngles;

		Camera.main.transform.DOLocalMove ( ( initialPosition + (Vector3.one * 0.3f) ), (trembleTime_ * 0.5f) ).OnComplete ( () =>
		{	
			Camera.main.transform.DOLocalRotate (initialRotation + (Vector3.one * 0.3f), (trembleTime_ * 0.5f)).OnComplete (() =>
			{
				Camera.main.transform.localPosition = initialPosition;
				Camera.main.transform.localEulerAngles = initialRotation;
			});
		});


	}
	*/
}
