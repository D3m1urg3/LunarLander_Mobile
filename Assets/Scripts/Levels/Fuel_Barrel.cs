using UnityEngine;
using System.Collections;

public class Fuel_Barrel : MonoBehaviour {

	public int fuel_value;

	public float speed;


	void Update()
	{
		transform.RotateAround (transform.position, Vector3.forward, speed * Time.deltaTime);

	}
	
}
