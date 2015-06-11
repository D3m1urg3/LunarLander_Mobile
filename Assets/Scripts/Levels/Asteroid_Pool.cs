using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Asteroid_Pool : MonoBehaviour {

	
	public float emission_time;
	public float asteroid_lifetime;
	public int asteroids_on_screen = 4;
	public int pool_size = 10;
	public GameObject asteroid;
	public List<GameObject> asteroids;

	bool doOnce;

	int active_asteroids;

	// Use this for initialization
	void Start () {

		doOnce = true;
		
		asteroids = new List<GameObject> ();
		
		for(int i=0; i<pool_size; ++i)
		{
			GameObject obj = (GameObject)Instantiate(asteroid);
			obj.transform.parent = gameObject.transform;
			obj.SetActive(false);
			asteroids.Add (obj);
		}
		
		InvokeRepeating ("Starfall", emission_time, emission_time);
	}
	
	void Starfall()
	{
		active_asteroids = 0;

		if(doOnce)
		{
			doOnce = false;
			man.comanderMsgManager.comander_msg.msg_index = 2;
			man.comanderMsgManager.comander_msg.isMsgCaution = true;
		}

		for(int i=0; i<pool_size; ++i)
		{
	
			if(!asteroids[i].activeInHierarchy)
			{
				active_asteroids++;
				asteroids[i].transform.position = new Vector3(Random.Range(-7.0f,7.0f),gameObject.transform.position.y + Random.Range(-3.0f,3.0f),0.0f);
				Asteroid asteroid_control = asteroids[i].GetComponent<Asteroid>();
				asteroid_control.lifetime = asteroid_lifetime + (float)Random.Range(0.0f,5.0f);
				
				asteroids[i].SetActive(true);
			}
			if( active_asteroids > asteroids_on_screen)
				break;


			
		}
	}

}
