using UnityEngine;
using System.Collections;

public class Comander_Messages : MonoBehaviour {

	public SpriteRenderer [] messages_good;
	public SpriteRenderer [] messages_caution;
	SpriteRenderer render;
	Animator comander_anim;

	public bool sendMsg;
	public bool isMsgGood;
	public bool isMsgCaution;
	bool isFading;
	public int msg_index;
	public float msg_time;
	public float fade_time;
	float time_increment;
	float timer;

	bool doOnce;
	/*

	Good Msgs
	0 - Keep it up
	1 - Increasing Gas

	Caution Msgs
	0 - Blackhole
	1 - Low Gas
	2 - Generic Caution
	3 - Lookout

	 */
	void Fade()
	{
		render.enabled = false;
		isFading = true;
	}

	// Use this for initialization
	void Start () {

		doOnce = true;

		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		

		isFading = false;
		sendMsg = false;
		isMsgGood = false;
		isMsgCaution = false;
		msg_index = 0;
		DisableRenders ();
		comander_anim = gameObject.GetComponent<Animator> ();
		timer = 0f;
		time_increment = fade_time / 30.0f;
	}
	
	// Update is called once per frame
	void Update () {


		if(isMsgGood && !isFading && !sendMsg && doOnce)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			doOnce = false;
		
			messages_good[msg_index].enabled = true;
			comander_anim.SetBool ("GreenMsg", isMsgGood);
			render = messages_good[msg_index];
			Invoke("Fade",msg_time);
		}
		else if(isMsgCaution && !isFading && !sendMsg && doOnce)
		{
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			doOnce = false;
			
			messages_caution[msg_index].enabled = true;
			comander_anim.SetBool ("RedMsg", isMsgCaution);
			render = messages_good[msg_index];
			Invoke("Fade",msg_time);
		}


		if (isFading) 
		{
			render = gameObject.GetComponent<SpriteRenderer>();

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
				timer = 0f;
				render.color = new Color(render.color.r,render.color.g, render.color.b, 1.0f);
				isFading = false;
				isMsgGood = isMsgCaution = sendMsg = false;
				comander_anim.SetBool ("GreenMsg", isMsgGood);
				comander_anim.SetBool ("RedMsg", isMsgCaution);
				doOnce = true;
				DisableRenders();
			}
		}

	}

	public void SendMessage()
	{
		sendMsg = true;
	}

	void DisableRenders()
	{
		
		for(int i=0; i<messages_good.Length; ++i)
		{
			messages_good[i].enabled = false;
		}
		for(int i=0; i<messages_caution.Length; ++i)
		{
			messages_caution[i].enabled = false;
		}

		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		
	}


}
