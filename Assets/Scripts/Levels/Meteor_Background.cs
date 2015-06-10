using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Meteor_Background : MonoBehaviour {

	public bool isFading;

	public GameObject shootingStar;

	Animator star_anim;


	// Use this for initialization
	void Start () {
		isFading = false;

		star_anim = shootingStar.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	

	}
}
