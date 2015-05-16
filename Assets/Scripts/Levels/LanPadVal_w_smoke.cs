using UnityEngine;
using System.Collections;

public class LanPadVal_w_smoke : MonoBehaviour 
{

	public int scoreMultiplier;
	public ParticleSystem dust;
	public float distance_for_dust;

	public GameObject ship;

	void Awake()
	{
		dust.enableEmission = false;
	}

	void Update()
	{
		Vector3 ship_to_pad = ship.transform.position - transform.position;

		if(ship_to_pad.magnitude < distance_for_dust)
		{
			dust.enableEmission = true;
		}
		else
		{
			dust.enableEmission = false;
		}
	}






}
