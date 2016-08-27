using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Interfaz de usuario :)

public class TestController : MonoBehaviour {

	private float strenght = 0;
	public int stopPoint;

	public Transform bolaDeJuego;
	public Transform catapultBase;
	public Transform centerPalo;
	public Text strengthText;

	public Vector3 cameraOffset;

	private float timerStrength = 0;
	public float topTime = 10;

	private enum GameState
	{
		lookPosition,
		buildStrength,
		checkRotation,
		launched
	};

	private GameState currentState = GameState.lookPosition;

	// Use this for initialization
	void Start () 
	{
		Physics.gravity = new Vector3 (0, -19, 0);

		this.timerStrength = 0;

		this.bolaDeJuego.GetComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		switch (currentState)
		{
			case GameState.lookPosition:
				this.lookPosition ();
				break;
			case GameState.buildStrength:
				this.buildStrength ();
				break;
			case GameState.checkRotation:
				this.checkRotation ();
				break;
			default:
				this.doNothing();
				break;
		}

	}

	private void lookPosition()
	{
		const float CATAPULT_ROTATION = 25;

		if (Input.GetKey (KeyCode.A))
		{
			catapultBase.Rotate (new Vector3 (0, CATAPULT_ROTATION, 0) * Time.deltaTime);

		} 
		else if (Input.GetKey (KeyCode.D))
		{
			catapultBase.Rotate (new Vector3 (0, -CATAPULT_ROTATION, 0) * Time.deltaTime);
		} 
		else if (Input.GetKeyDown (KeyCode.Space))
		{
			this.currentState = GameState.buildStrength;
		}


	}

	private void buildStrength()
	{
		this.timerStrength += Time.deltaTime;

		if (this.timerStrength <= this.topTime)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				this.strenght += 2f;
			} 

			this.strenght -= 0.1f;

			if (this.strenght <= 0f)
			{
				this.strenght = 0;
			}

			this.strengthText.text = this.strenght.ToString ();
		} 
		else
		{
			
			this.currentState = GameState.checkRotation;

		}

	}

	private void checkRotation()
	{

		this.centerPalo.Rotate (new Vector3 (0, 0, 20) * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.S))
		{
			this.bolaDeJuego.GetComponent<Rigidbody> ().useGravity = true;

			this.bolaDeJuego.SetParent (null);

			this.bolaDeJuego.localScale = Vector3.one;

			this.bolaDeJuego.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.up * strenght, ForceMode.Impulse);

			this.cleanCamera ();

			this.currentState = GameState.launched;

		}

	}

	private void cleanCamera()
	{

		Camera.main.transform.localEulerAngles = new Vector3 (55, -90, 0);
		Camera.main.transform.localPosition = new Vector3 (10, 24, 0);

		this.cameraOffset = Camera.main.transform.position - this.bolaDeJuego.transform.position;


		Camera.main.transform.parent = null;

	}

	private void doNothing()
	{

		Camera.main.transform.position = this.bolaDeJuego.transform.position + cameraOffset;


	}
}
