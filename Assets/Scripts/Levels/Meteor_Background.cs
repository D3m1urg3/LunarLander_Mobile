using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteor_Background : MonoBehaviour {

	public float emission_time;
	public int stars_on_screen = 4;
	float deltaTime;


	public int pool_size = 10;
	public GameObject shooting_star;
	public List<GameObject> stars;



	// Use this for initialization
	void Start () {

		stars = new List<GameObject> ();

		for(int i=0; i<pool_size; ++i)
		{
			GameObject obj = (GameObject)Instantiate(shooting_star);
			obj.SetActive(false);
			stars.Add (obj);
		}

		InvokeRepeating ("Starfall", emission_time, emission_time);
	}

	void Starfall()
	{
		for(int i=0; i<stars.Count; ++i)
		{
			if(!stars[i].activeInHierarchy)
			{

				
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
	

	}
}
