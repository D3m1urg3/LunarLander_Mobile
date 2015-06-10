using UnityEngine;
using System.Collections;

public class Shooting_Star : MonoBehaviour {

	public float speed;
	public float lifetime;
	public bool isFading;
	Animator star_anim;


	void Start()
	{
		star_anim = gameObject.GetComponent<Animator> ();
	}

   	void Update()
	{
		transform.Translate(-speed*Time.deltaTime*Vector3.right);	
	}

	void OnEnable ()
	{
		isFading = false;
		Invoke ("FadeOut", lifetime);
	}

	void FadeOut()
	{
		isFading = true;
		star_anim.SetBool ("isFading", isFading);
	}

	void Disable()
	{
		gameObject.SetActive (false);
	}

	void OnDisable()
	{
		CancelInvoke ();
	}

}
