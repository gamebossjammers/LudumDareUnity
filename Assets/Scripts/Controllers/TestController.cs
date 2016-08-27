using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Interfaz de usuario :)

public class TestController : MonoBehaviour {

	private float strenght = 0;
	private bool strenghtUP = true;
	public int stopPoint;

	public Transform bolaDeJuego;
	public Transform catapultBase;
	public Transform centerPalo;
	public RectTransform strengthMeter;

	public Vector3 cameraOffset;

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
		Physics.gravity = new Vector3 (0, -27, 0);
	
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
			this.strengthMeter.sizeDelta = new Vector2 (100, 0);
			this.strenght = Random.Range (5, 67);
			this.strenghtUP = (Random.Range (0, 2) == 1) ? true : false;
		}


	}

	private void buildStrength()
	{ 

		this.strengthMeter.sizeDelta = new Vector2 (100, strenght);

		this.strenght = (this.strenghtUP == true) ? this.strenght += (120 * Time.deltaTime) : this.strenght -= (120 * Time.deltaTime);

		if (this.strenght >= 100)
		{
			this.strenght = 100;
			this.strenghtUP = false;
		} 
		else if (this.strenght <= 0)
		{
			this.strenght = 0;
			this.strenghtUP = true;
		}


		if (Input.GetKeyDown (KeyCode.Space))
		{

			this.currentState = GameState.checkRotation;

		}

	}

	private void checkRotation()
	{

		this.centerPalo.Rotate (new Vector3 (0, 0, 135) * Time.deltaTime);

		if ( Input.GetKeyDown (KeyCode.Space) || this.centerPalo.localEulerAngles.z >= 55)
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
