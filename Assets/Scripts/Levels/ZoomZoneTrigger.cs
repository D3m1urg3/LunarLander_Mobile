using UnityEngine;
using System.Collections;

public class ZoomZoneTrigger : MonoBehaviour {

	public bool doZoomIn;


	void Awake()
	{
		doZoomIn = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if(other.gameObject.layer == 9)
			doZoomIn = true;

	}
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.gameObject.layer == 9)
			doZoomIn = false;
		
	}


}
