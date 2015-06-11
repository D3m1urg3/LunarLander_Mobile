using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	GameObject ship;
	Rigidbody2D ship_physics;

	Animator blackhole_anim;

	public Collider2D singularity;

	public float gravity_push;

	public bool isActive;

	Vector2 gravity_force;

	bool isInRange;

	bool doOnce;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == ship.name)
		{
			isInRange = true;
			isActive = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == ship.name)
		{
			isInRange = false;
			isActive = false;
		}
	}

	void Awake()
	{
		isActive = false;
	}
	// Use this for initialization
	void Start () 
	{
		doOnce = true;
		isInRange = false;
		ship = man.shipManager.ship;
		blackhole_anim = gameObject.GetComponent<Animator> ();

		ship_physics = ship.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Blackhole animation
		blackhole_anim.SetBool ("BlackHole_active", isActive);

		singularity.enabled = isActive;

		//Comander msg when it goes active
		if(doOnce && isActive)
		{
			doOnce =false;
			man.comanderMsgManager.comander_msg.msg_index = 0;
			man.comanderMsgManager.comander_msg.isMsgCaution = true;
		}


		//Black Hole Behaviour
		if(isInRange && isActive)
		{
			float ship_to_hole = (gameObject.transform.position - ship.transform.position).magnitude;
			gravity_force = (gameObject.transform.position - ship.transform.position);
			gravity_force.Normalize();
			gravity_force = (1.0f/(ship_to_hole*ship_to_hole))*gravity_force;
			
			ship_physics.velocity = ship_physics.velocity + gravity_force * gravity_push;
		}
	}
}
