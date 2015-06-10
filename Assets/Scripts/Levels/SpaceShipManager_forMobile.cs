using UnityEngine;
using System.Collections;



public class SpaceShipManager_forMobile : MonoBehaviour {
	
	//Managed object
	public GameObject ship;
	public GameObject engines;
	public Camera cam;
	//Public behaviour parameters
	//Movement
	public float maxAngle = 90f;
	public float spinVelocity = 75f;
	public float impulse = 2.5f;
	public float maxVelocity = 2.5f;
	
	
	//Features
	public int fuel;	
	public bool enginesON;
	public bool shipDestroyed;
	
	//Private variables
	Vector3 angles; // Vector to store rotation angles
	Animator ship_anim; // Ship animator
	Animator engine_anim;
	AudioSource shipFX;

	void Awake()
	{
		enginesON = false;
		shipDestroyed = false;

	}
	
	
	
	// Use this for initialization
	void Start () {
		
		//Set Initial Position
		//ship.transform.position += new Vector3(0,4,0);
		
		// Parameter Initialization

		if(Manager.IsGyroSupported || true)//Mobile Init
		{
			ship.transform.rotation = cam.transform.rotation;			
		}
		else//PC init
		{
			angles = ship.transform.eulerAngles;
			maxAngle += angles.z;

		}

		enginesON = false;
		engine_anim = engines.GetComponent<Animator> ();


		shipDestroyed = false;
		ship_anim = ship.GetComponent<Animator>();
		shipFX = ship.GetComponent<AudioSource> ();
		//PlayerPrefs.SetInt ("level_test_fuel", fuel);
		// Fuel value storage in Player Prefs
		// TODO: make it cleaner
		if (PlayerPrefs.HasKey ("level_"+Application.loadedLevel+"_fuel")) 
		{
			fuel = PlayerPrefs.GetInt("level_"+Application.loadedLevel+"_fuel");
		} 
		else 
		{
			Debug.Log ("No fuel set for this level!");
			fuel = 1000;
			PlayerPrefs.SetInt ("level_"+Application.loadedLevel+"_fuel", fuel);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(Manager.IsGyroSupported || true)
		{
			// Rotation controls
			ship.transform.rotation = cam.transform.rotation;

			// Thrust controls. fuel + animation
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Began && fuel > 0)
					enginesON = true;
				else if(touch.phase == TouchPhase.Ended)
					enginesON = false;
			}
		}
		else
		{
			angles.z += -1.0f*Input.GetAxis ("Horizontal") * spinVelocity * Time.deltaTime; //Angle increase controled by spinVelocity
			angles.z = Mathf.Clamp (angles.z, -1.0f*maxAngle, maxAngle); //Limit angle
			
			ship.transform.eulerAngles = angles;

			if (Input.GetKeyDown (KeyCode.UpArrow) && fuel > 0) 
			{
				enginesON = true;
			} 
			else if (Input.GetKeyUp (KeyCode.UpArrow)) 
			{
				enginesON = false;
			}
		}

		// Ship animation triggers

		engine_anim.SetBool ("EnginesON", enginesON); //engines
		ship_anim.SetBool ("Destroyed", shipDestroyed); //Destruction

		//Sound FX

		if (enginesON && !man.soundFxManager.thrust_sound.isPlaying) 
		{
			man.soundFxManager.thrust_sound.Play();
			
		}
		else if(!enginesON)
		{
			man.soundFxManager.thrust_sound.Stop();
		}

		if(shipDestroyed && !man.soundFxManager.explosion_sound.isPlaying)
		{
			man.soundFxManager.explosion_sound.Play ();
		}
		else if(!shipDestroyed)
			man.soundFxManager.explosion_sound.Stop ();

		
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit();
		}
		
	}
	
	void FixedUpdate()
	{
		
		// Added constant force for thrust
		if (enginesON) {
			
			ship.GetComponent<Rigidbody2D>().AddForce(ship.transform.up*impulse,ForceMode2D.Force);
			ship.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(ship.GetComponent<Rigidbody2D>().velocity, maxVelocity);	
			
			
			// Burn Fuel with engines ON
			if(fuel > 0)
				fuel--;
		}
	}
	
	
	
	
}
