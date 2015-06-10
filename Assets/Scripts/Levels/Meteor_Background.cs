using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteor_Background : MonoBehaviour {

	public float emission_time;
	public float stars_lifetime;
	public int stars_on_screen = 4;
	public int pool_size = 10;
	public GameObject shooting_star;
	public List<GameObject> stars;

	int active_stars;



	// Use this for initialization
	void Start () {

		stars = new List<GameObject> ();

		for(int i=0; i<pool_size; ++i)
		{
			GameObject obj = (GameObject)Instantiate(shooting_star);
			obj.transform.parent = gameObject.transform;
			obj.SetActive(false);
			stars.Add (obj);
		}

		InvokeRepeating ("Starfall", emission_time, emission_time);
	}

	void Starfall()
	{
		active_stars = 0;
		for(int i=0; i<stars.Count; ++i)
		{
			if(!stars[i].activeInHierarchy)
			{
				active_stars++;
				stars[i].transform.position = new Vector3(Random.Range(-7.0f,7.0f),gameObject.transform.position.y + Random.Range(-3.0f,3.0f),0.0f);
				stars[i].transform.eulerAngles = new Vector3(0.0f,0.0f,45.0f);
				Shooting_Star star_control = stars[i].GetComponent<Shooting_Star>();
				star_control.lifetime = stars_lifetime + (float)Random.Range(0.0f,5.0f);

				stars[i].SetActive(true);
			}
			if( active_stars > stars_on_screen)
				break;
		}
	}

	// Update is called once per frame
	void Update () 
	{
	

	}
}
