using UnityEngine;
using System.Collections;

public class ZoomZoneTrigger : MonoBehaviour {

	public bool doZoomIn;
	
	void Start()
	{
		doZoomIn = false;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		doZoomIn = true;

	}
	void OnTriggerExit2D (Collider2D other)
	{
		doZoomIn = false;
		
	}


}
