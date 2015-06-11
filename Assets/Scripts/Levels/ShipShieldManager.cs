using UnityEngine;
using System.Collections;

public class ShipShieldManager : MonoBehaviour {

	public GameObject ship;
	public GameObject shield;
	Animator shield_anim;

	public bool isShieldUP;
	public bool isShieldHit;
	public bool isShieldDestroyed;
	public int shield_lives;
	public int current_lives;

	// Use this for initialization
	void Start () 
	{
		shield_anim = shield.GetComponent<Animator> ();
		isShieldUP = false;
		isShieldHit = false;
		isShieldDestroyed = false;
		shield.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		shield_anim.SetBool ("ShieldUP", isShieldUP);
		shield_anim.SetBool ("ShieldHit", isShieldHit);
		shield_anim.SetBool ("ShieldDestroyed", isShieldDestroyed);

	}

	public void OnShieldHit()
	{
		isShieldHit = true;
		man.colManager.invicible = true;
		current_lives--;
		if (current_lives == 0) 
		{
			DisableShield();
		}
	}


	public void EnableShield()
	{
		shield.SetActive (true);
		shield_anim = shield.GetComponent<Animator> ();
		isShieldDestroyed = false;
		isShieldUP = true;
		current_lives = shield_lives;
	}


	public void DisableShield()
	{
		isShieldUP = false;
		man.colManager.invicible = false;;
		shield.SetActive(false);
	}
}
