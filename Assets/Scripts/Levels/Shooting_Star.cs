using UnityEngine;
using System.Collections;

public class Shooting_Star : MonoBehaviour {

	public float lifetime;
	public bool isFading;
	Animator star_anim;

	void Awake()
	{
		star_anim = gameObject.GetComponent<Animator> ();
	}

	void OnEnable ()
	{

		Invoke ("FadeOut", lifetime);
	}

	void FadseOut()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}

}
