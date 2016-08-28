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
    // Reference to Catapult's starting position
    public Transform startLocation;

    public float navMeshcheckRange = 20f;

	// Estados de juego
	private enum GameState
	{
		none,
		rotateCatapult,
		buildStrength,
		launchBall,
		preparingCatapult,
		ballLaunched,
		ballStopped,
		rebuildCatapult

	};
	private GameState currentState = GameState.rotateCatapult;
	private GameState previousState = GameState.none;

	private readonly float CATAPULT_HORIZONTAL_ROTATION_SPEED = 50f;
	private readonly float CATAPULT_VERTICAL_ROTATION_SPEED = 25f;
	private readonly float STRENGTH_BUILD_SPEED = 170f;

	private readonly Vector3 BALL_LAUNCH_STOP_POSITION = new Vector3 (-3, 0, 0);
	private readonly Vector3 BALL_CATAPULT_POSITION = new Vector3 (0, -0.056188f, 0.005135f);
	private readonly Vector3 BALL_CATAPULT_ROTATION = new Vector3 (90, 0, 0);
	private readonly Vector3 CATAPULT_ARM_ROTATION = new Vector3 (-45, 0, 0);
    

    private void Awake ()
    {
        GameInstance.SetCurrentGameController(this);
    }

	// Use this for initialization
	void Start () 
	{

		// seteamos gravedad
		Physics.gravity = new Vector3 (0, -27, 0);

		// iniciamos la bola
		this.restartBall(); 


	}
	
	// Update is called once per frame
	void Update () 
	{
        // Do not check catapult controls in any other GameManager state but Playing
        if (GameInstance.GetCurrentGameManager()._gameState == EGameState.Playing)
        {
            InputManager.checkInputs();

            switch (currentState)
            {
                case GameState.rotateCatapult:
                    this.rotateCatapult();
                    break;
                case GameState.buildStrength:
                    this.buildStrength();
                    break;
                case GameState.launchBall:
                    this.launchBall();
                    break;
                case GameState.ballLaunched:
                    this.checkIfBallStopped();
                    break;
				case GameState.rebuildCatapult:
                    this.restartGame();
                    break;
            }
        }

	}

	private void rotateCatapult()
	{

		float horizontalRotation = this.transform.eulerAngles.y + (InputManager.leftJoy.x * CATAPULT_HORIZONTAL_ROTATION_SPEED * Time.deltaTime);
		float verticalRotation = this.transform.eulerAngles.z + (InputManager.leftJoy.y * CATAPULT_VERTICAL_ROTATION_SPEED * Time.deltaTime);

		this.catapult.transform.Rotate (0 , 0 , -horizontalRotation);
		this.catapultArm.transform.Rotate (verticalRotation, 0, 0);

		// limites de catapulta
		if (this.catapultArm.transform.localEulerAngles.x <= 275f)
		{
			this.catapultArm.transform.Rotate (-verticalRotation, 0, 0);
		}
		if (this.catapultArm.transform.localEulerAngles.x >= 356f)
		{
			this.catapultArm.transform.Rotate (verticalRotation, 0, 0);
		}

		previousState = GameState.rotateCatapult;

		if (InputManager.launchButton)
		{
			
			this.currentState = GameState.buildStrength;

			this.strengthMeter.GetComponent<RectTransform>().sizeDelta = new Vector2 (0, 0);

			this.strength = Random.Range (5, 67);
			this.strengthUP = (Random.Range (0, 2) == 1) ? true : false;
			this.armRotation = this.catapultArm.transform.localEulerAngles.x;

		}
	}

	private void buildStrength()
	{ 

		this.strengthMeter.GetComponent<RectTransform>().sizeDelta = new Vector2 (100, strength);

		this.strength = (this.strengthUP == true) ? this.strength += (this.STRENGTH_BUILD_SPEED * Time.deltaTime + (this.strength * 0.1f) ) : this.strength -= (this.STRENGTH_BUILD_SPEED * Time.deltaTime + (this.strength * 0.1f));

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

				this.mainCamera.transform.DOShakePosition ( Mathf.Clamp( ( 50 / this.strength ) , 0.1f ,1f) , this.strength * 0.02f );

				this.catapultArm.transform.DOLocalRotate ( new Vector3 ( this.armRotation , 0 , 0 ) , ( 2 / this.strength ) ).OnComplete ( () =>
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
		// Comprobamos
		if ( (this.gameBall.GetComponent<Rigidbody> ().velocity.magnitude) <= 5 && Physics.Raycast(this.gameBall.transform.position,Vector3.down, 1))
		{
			
			NavMeshHit navHit;

			if (NavMesh.SamplePosition(this.gameBall.transform.position, out navHit, this.navMeshcheckRange , -1))
			{

				this.currentState = GameState.ballStopped;

				StartCoroutine(letTheBallRun( 3 , navHit) );

                // Subtract 1 move from the pool
                GameInstance.GetCurrentGameManager().SubtractMove(1);

			}
				
		}
	}

	IEnumerator letTheBallRun(float time , NavMeshHit navHit_ )
	{
		yield return new WaitForSeconds(time);

		this.catapult.transform.position = navHit_.position;
		this.currentState = GameState.rebuildCatapult;

		// Code to execute after the delay
	}

	public void restartGame()
	{
		this.restartBall ();
		this.mainCamera.GetComponent<CameraController>().restartCamera();

		this.currentState = GameState.rotateCatapult;
	}

	private void addEnergy()
	{
		this.gameBall.GetComponent<Rigidbody> ().useGravity = true;

		this.gameBall.transform.SetParent (null);

		this.gameBall.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * strength, ForceMode.Impulse);

		this.gameBall.GetComponent<Rigidbody>().freezeRotation = false;

		//this.gameBall.GetComponent<Rigidbody> ().maxAngularVelocity = 200;
		//this.gameBall.GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, strength * 0.9f );

	}

	private void restartBall()
	{
		this.mainCamera.GetComponent<CameraController> ().restartCamera ();

		this.catapultArm.transform.localEulerAngles = this.CATAPULT_ARM_ROTATION;
		this.catapult.transform.localEulerAngles = new Vector3 (-90, mainCamera.transform.localEulerAngles.y + 90 , 0);

		this.gameBall.transform.SetParent (this.catapultArm.transform);

		this.gameBall.GetComponent<Rigidbody> ().useGravity = false;
		this.gameBall.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		this.gameBall.transform.localPosition = this.BALL_CATAPULT_POSITION;
		this.gameBall.transform.localEulerAngles = this.BALL_CATAPULT_ROTATION;

		gameBall.GetComponent<Rigidbody>().freezeRotation = true;

	}

    /// <summary>
    /// Resets the catapult's transform to the one referenced by startLocation
    /// </summary>
    public void ResetGame ()
    {
        catapult.transform.position = this.startLocation.position;
        catapult.transform.rotation = this.startLocation.rotation;
        restartBall();
    }
}