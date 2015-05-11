using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour {

	public GameObject ship;
	Rigidbody2D ship_physics;


	public float gravity_push;

	Vector2 gravity_force;

	bool isInRange;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == ship.name)
			isInRange = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == ship.name)
			isInRange = false;
	}
	// Use this for initialization
	void Start () 
	{
		isInRange = false;
		ship_physics = ship.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isInRange)
		{
			gravity_force = gameObject.transform.position - ship.transform.position;
			
			ship_physics.velocity = ship_physics.velocity + gravity_force * gravity_push;
		}
	}
}
