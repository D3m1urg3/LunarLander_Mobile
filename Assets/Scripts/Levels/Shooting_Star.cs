using UnityEngine;
using System.Collections;

public class Shooting_Star : MonoBehaviour {

	public float speed;
	public float lifetime;
	public float fading_time;

	SpriteRenderer render;
	float time_increment;
	float timer;
	float alpha;
	public bool isFading;

	void Start()
	{
		render = gameObject.GetComponent<SpriteRenderer> ();
		time_increment = fading_time / 30.0f;
		timer = 0.0f;
		isFading = false;
	}

   	void Update()
	{

		transform.Translate(-speed*Time.deltaTime*Vector3.right);	


		if (isFading) 
		{
			if (timer < time_increment)
				timer += Time.deltaTime;
			else if (render.color.a != 0f && render.color.a > 0f) 
			{
				float current_alpha = render.color.a;
				render.color = new Color (render.color.r, render.color.g, render.color.b, render.color.a - 0.03333f);
				timer = 0.0f;
			} 
			else if (render.color.a <= 0.0f) 
			{				
				render.color = new Color(render.color.r,render.color.g, render.color.b, 1.0f);
				gameObject.SetActive (false);
			}
		}

	}

	void OnEnable ()
	{
		Invoke ("FadeOut", lifetime);
	}

	void FadeOut()
	{
		isFading = true;
	}

	void OnDisable()
	{
		timer = 0.0f;
		isFading = false;
		CancelInvoke ();
	}

}
