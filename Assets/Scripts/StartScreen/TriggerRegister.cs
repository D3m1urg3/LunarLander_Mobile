using UnityEngine;
using System.Collections;

public class TriggerRegister : MonoBehaviour {

	public bool triggerIN;

	// Use this for initialization
	void Start () {
		triggerIN = false;
	}
	
	void OnTriggerEnter2D ( Collider2D col )
	{
		triggerIN = true;
	}

	void OnTriggerExit2D ( Collider2D col )
	{
		triggerIN = false;
	}
}
