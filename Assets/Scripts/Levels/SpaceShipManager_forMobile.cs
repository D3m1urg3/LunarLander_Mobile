using UnityEngine;
using System.Collections;



public class SpaceShipManager_forMobile : MonoBehaviour {
	
	//Managed object
	public GameObject ship;
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
	Animator anim; // Ship animator
	AudioSource shipFX;

	void Awake()
	{
		fuel = 1000;
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
		shipDestroyed = false;
		anim = ship.GetComponent<Animator>();
		shipFX = ship.GetComponent<AudioSource> ();
		
		// Fuel value storage in Player Prefs
		// TODO: make it cleaner
		if (PlayerPrefs.HasKey ("fuel")) {
			fuel = PlayerPrefs.GetInt("fuel");
		} 
		else {
			fuel = 1000;
			PlayerPrefs.SetInt ("fuel", fuel);
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

		anim.SetBool ("Thrust", enginesON); //engines
		anim.SetBool ("Destroyed", shipDestroyed); //Destruction

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
