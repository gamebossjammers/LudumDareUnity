using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GameController : MonoBehaviour {

	// fuerza de lanzamiento de la bola
	private float strength = 0;
	private bool strengthUP = true;

	// rotacion del brazo
	private float armRotation = 0;

	public GameObject gameBall;
	public GameObject catapult;
	public GameObject strengthMeter;
	public GameObject catapultArm;
	public GameObject mainCamera;

	// Estados de juego
	private enum GameState
	{
		none,
		rotateCatapult,
		buildStrength,
		launchBall,
		preparingCatapult,
		ballLaunched,
		ballStopped

	};
	private GameState currentState = GameState.rotateCatapult;
	private GameState previousState = GameState.none;

	private readonly float CATAPULT_HORIZONTAL_ROTATION_SPEED = 25f;
	private readonly float CATAPULT_VERTICAL_ROTATION_SPEED = 25f;
	private readonly float STRENGTH_BUILD_SPEED = 170f;

	private readonly Vector3 BALL_LAUNCH_STOP_POSITION = new Vector3 (0, 0, -35f);

	// Use this for initialization
	void Start () 
	{

		// seteamos gravedad
		Physics.gravity = new Vector3 (0, -27, 0);

		// iniciamos la bola
		this.gameBall.GetComponent<Rigidbody> ().useGravity = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		InputManager.checkInputs ();

		switch (currentState)
		{
		case GameState.rotateCatapult:
			this.rotateCatapult ();
			break;
		case GameState.buildStrength:
			this.buildStrength ();
			break;
		case GameState.launchBall:
			this.launchBall ();
			break;
		case GameState.ballLaunched:
			this.checkIfBallStopped ();
			break;
		case GameState.ballStopped:
			this.restartBall ();
			break;
		}

	}

	private void rotateCatapult()
	{

		float horizontalRotation = this.transform.eulerAngles.y + (InputManager.leftJoy.x * CATAPULT_HORIZONTAL_ROTATION_SPEED * Time.deltaTime);
		float verticalRotation = this.transform.eulerAngles.z + (InputManager.leftJoy.y * CATAPULT_VERTICAL_ROTATION_SPEED * Time.deltaTime);

		this.catapult.transform.Rotate (0, -horizontalRotation, 0);
		this.catapultArm.transform.Rotate (0, 0, verticalRotation);

		// limites de catapulta
		if (this.catapultArm.transform.localEulerAngles.z <= 5f)
		{
			this.catapultArm.transform.Rotate (0, 0, -verticalRotation);
		}
		if (this.catapultArm.transform.localEulerAngles.z >= 90f)
		{
			this.catapultArm.transform.Rotate (0, 0, -verticalRotation);
		}

		previousState = GameState.rotateCatapult;

		if (InputManager.launchButton)
		{
			this.currentState = GameState.buildStrength;

			this.strengthMeter.GetComponent<RectTransform>().sizeDelta = new Vector2 (0, 0);

			this.strength = Random.Range (5, 67);
			this.strengthUP = (Random.Range (0, 2) == 1) ? true : false;
			this.armRotation = this.catapultArm.transform.localEulerAngles.z;

		}
	}

	private void buildStrength()
	{ 

		this.strengthMeter.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, strength);

		this.strength = (this.strengthUP == true) ? this.strength += (this.STRENGTH_BUILD_SPEED * Time.deltaTime) : this.strength -= (this.STRENGTH_BUILD_SPEED * Time.deltaTime);

		if (this.strength >= 100)
		{
			this.strength = 100;
			this.strengthUP = false;
		} 
		else if (this.strength <= 0)
		{
			this.strength = 0;
			this.strengthUP = true;
		}

		if (InputManager.launchButton)
		{
			this.strength = this.strength * 0.5f;
			this.currentState = GameState.launchBall;
		}

	}

	private void launchBall()
	{

		currentState = GameState.preparingCatapult;

		this.catapultArm.transform.DOLocalRotate ( this.BALL_LAUNCH_STOP_POSITION, 1 ).OnComplete ( () =>
		{
			this.catapultArm.transform.DOLocalRotate ( this.BALL_LAUNCH_STOP_POSITION , 2).OnComplete ( () =>
			{

				this.catapultArm.transform.DOLocalRotate ( new Vector3 ( 0 , 0 , this.armRotation ) , ( 2 / this.strength ) ).OnComplete ( () =>
				{
					this.addEnergy();
					this.currentState = GameState.ballLaunched;
					this.mainCamera.GetComponent<CameraController>().followBall();
				});
			});
		});

	}

	private void checkIfBallStopped()
	{
		if (this.gameBall.GetComponent<Rigidbody> ().velocity.magnitude <= 3)
		{

			Debug.Log ("ballStopped");

			NavMeshHit navHit;

			if (NavMesh.SamplePosition(this.gameBall.transform.position, out navHit, 1, -1))
			{
				this.catapult.transform.position = navHit.position;
				this.mainCamera.transform.position = this.catapult.transform.position;

				this.currentState = GameState.ballStopped;

			}
				
		}
	}

	private void restartBall()
	{
		this.currentState = GameState.rotateCatapult;
	}

	private void addEnergy()
	{
		this.gameBall.GetComponent<Rigidbody> ().useGravity = true;

		this.gameBall.transform.SetParent (null);

		this.gameBall.transform.localScale = Vector3.one;

		this.gameBall.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * strength, ForceMode.Impulse);

	}

}