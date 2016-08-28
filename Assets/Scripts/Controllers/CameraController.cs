using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class CameraController : MonoBehaviour {

	public Transform cataCrux;
	public Transform mainCamera;
	public Transform ball;

	private Transform cameraAimObject;

	private readonly float TOP_VIEW_SPEED = 20;
	private readonly float CAMERA_ROTATION_SPEED = 100;

	private Vector3 cameraRotation;
	private readonly Vector2 CAMERA_ROTATION_LIMITS = new Vector2 ( 260, 300);

	private enum cameraStates
	{
		onPosition,
		topView,
		transitionState,
		flyingBall
	}

	private cameraStates currentState;

	private List<int> zoomDistances = new List<int> ();
	private int zoomPosition;

	// Use this for initialization
	void Start () 
	{
		this.cameraAimObject = this.cataCrux.transform;

		this.transform.localPosition = this.cameraAimObject.transform.position;

		currentState = cameraStates.onPosition;
		this.zoomPosition = 0;
		zoomDistances.Add (24);
		zoomDistances.Add (32);
		zoomDistances.Add (40);


	}

	// Update is called once per frame
	void Update () 
	{

		this.transform.localPosition = this.cameraAimObject.position;

		if ( InputManager.cameraTypeChange )
		{
			if (this.currentState == cameraStates.onPosition)
			{

				this.currentState = cameraStates.transitionState;

				Camera.main.transform.DOPause ();

				this.transform.DOLocalRotate (new Vector3 (0, 0, 0), 0.5f).SetEase (Ease.InExpo);
				Camera.main.transform.DOLocalMove ( new Vector3 (-8, 150, 0), 0.5f).SetEase (Ease.InExpo);
				Camera.main.transform.DOLocalRotate ( new Vector3 (90, 270, 0), 0.5f ).SetEase (Ease.InExpo).OnComplete( () =>
				{
					this.currentState = cameraStates.topView;
				});

			} 
			else if (this.currentState == cameraStates.topView)
			{

				this.currentState = cameraStates.transitionState;

				this.zoomPosition = 0;

				Camera.main.transform.DOPause ();

				this.transform.DOLocalRotate ( new Vector3 ( 0, this.cataCrux.parent.localEulerAngles.y - 90 , 0 ), 0.5f).SetEase (Ease.InExpo);
				Camera.main.transform.DOLocalMove ( new Vector3 (-8, 24, 0), 0.5f).SetEase (Ease.InExpo);
				Camera.main.transform.DOLocalRotate ( new Vector3 (90, -270, -180), 0.5f ).SetEase (Ease.InExpo).OnComplete( () =>
				{
					this.currentState = cameraStates.onPosition;
				});
			}
				
		}

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

		// CAMERA LIMITS
		verticalPosition = (verticalPosition <= this.CAMERA_ROTATION_LIMITS.x) ? this.CAMERA_ROTATION_LIMITS.x : verticalPosition;
		verticalPosition = (verticalPosition >= this.CAMERA_ROTATION_LIMITS.y) ? this.CAMERA_ROTATION_LIMITS.y : verticalPosition;

		this.transform.eulerAngles = Vector3.Lerp ( this.transform.eulerAngles, new Vector3( 0, horizontalPosition , verticalPosition ) , 0.75f);

		if ( InputManager.cameraZoom )
		{
			zoomPosition++;

			zoomPosition = (zoomPosition > 2) ? 0 : zoomPosition;

			Transform cameraTransform = Camera.main.transform;

			cameraTransform.DOLocalMoveY (zoomDistances [zoomPosition], 0.5f).SetEase (Ease.OutQuart);

			//cameraTransform.localPosition = new Vector3 (cameraTransform.localPosition.x, zoomDistances[zoomPosition], cameraTransform.localPosition.z);
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
		this.cameraAimObject = this.ball;
	}

	public void restartCamera()
	{
		this.cameraAimObject = this.cataCrux.transform;
	}
		
}
