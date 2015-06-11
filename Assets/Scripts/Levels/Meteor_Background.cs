using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteor_Background : MonoBehaviour {

	public float emission_time;
	public float stars_lifetime;
	public int stars_on_screen = 4;
	public int pool_size = 10;
	public GameObject shooting_star_close;
	public GameObject shooting_star_mid;
	public GameObject shooting_star_far;	
	public List<GameObject> stars_close;
	public List<GameObject> stars_mid;
	public List<GameObject> stars_far;



	int active_stars;



	// Use this for initialization
	void Start () {

		stars_close = new List<GameObject> ();
		stars_mid = new List<GameObject> ();
		stars_far = new List<GameObject> ();
		
		for(int i=0; i<pool_size; ++i)
		{
			GameObject obj;
			//pool close star
			obj = (GameObject)Instantiate(shooting_star_close);
			obj.transform.parent = gameObject.transform;
			obj.SetActive(false);
			stars_close.Add (obj);
			//pool mid star
			obj = (GameObject)Instantiate(shooting_star_mid);
			obj.transform.parent = gameObject.transform;
			obj.SetActive(false);
			stars_mid.Add (obj);
			//pool far star
			obj = (GameObject)Instantiate(shooting_star_far);
			obj.transform.parent = gameObject.transform;
			obj.SetActive(false);
			stars_close.Add (obj);

		}

		InvokeRepeating ("Starfall", emission_time, emission_time);
	}

	void Starfall()
	{
		active_stars = 0;

		for(int i=0; i<pool_size; ++i)
		{

			int select = Random.Range (0, 2);
			
			switch(select)
			{
			case 0:

				if(!stars_close[i].activeInHierarchy)
				{
					active_stars++;
					stars_close[i].transform.position = new Vector3(Random.Range(-7.0f,7.0f),gameObject.transform.position.y + Random.Range(-3.0f,3.0f),0.0f);
					stars_close[i].transform.eulerAngles = new Vector3(0.0f,0.0f,45.0f);
					Shooting_Star star_control = stars_close[i].GetComponent<Shooting_Star>();
					star_control.lifetime = stars_lifetime + (float)Random.Range(0.0f,5.0f);
					
					stars_close[i].SetActive(true);
				}
				if( active_stars > stars_on_screen)
					break;

				break;
			case 1:

				if(!stars_mid[i].activeInHierarchy)
				{
					active_stars++;
					stars_mid[i].transform.position = new Vector3(Random.Range(-7.0f,7.0f),gameObject.transform.position.y + Random.Range(-3.0f,3.0f),0.0f);
					stars_mid[i].transform.eulerAngles = new Vector3(0.0f,0.0f,45.0f);
					Shooting_Star star_control = stars_mid[i].GetComponent<Shooting_Star>();
					star_control.lifetime = stars_lifetime + (float)Random.Range(0.0f,5.0f);
					
					stars_mid[i].SetActive(true);
				}
				if( active_stars > stars_on_screen)
					break;

				break;
			case 2:
				if(!stars_far[i].activeInHierarchy)
				{
					active_stars++;
					stars_far[i].transform.position = new Vector3(Random.Range(-7.0f,7.0f),gameObject.transform.position.y + Random.Range(-3.0f,3.0f),0.0f);
					stars_far[i].transform.eulerAngles = new Vector3(0.0f,0.0f,45.0f);
					Shooting_Star star_control = stars_far[i].GetComponent<Shooting_Star>();
					star_control.lifetime = stars_lifetime + (float)Random.Range(0.0f,5.0f);
					
					stars_far[i].SetActive(true);
				}
				if( active_stars > stars_on_screen)
					break;

				break;
			}

		}
	}

	// Update is called once per frame
	void Update () 
	{


	}
}
