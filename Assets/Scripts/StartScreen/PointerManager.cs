using UnityEngine;
using System.Collections;

public class PointerManager : MonoBehaviour {

	//Public members
	public GameObject pointer;
	public Camera cam;
	
	//Private members
	Vector3 mousePosition;

	// Use this for initialization
	void Start () {
		mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
		//Mouse Controller
		mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);
		pointer.transform.position = mousePosition;
	}
}
