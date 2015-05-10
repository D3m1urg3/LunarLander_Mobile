using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIRightManager : MonoBehaviour {

	//Public members
	public GameObject UIRight;

	//Private members
	int altitude;
	int velocityY;
	int velocityX;
	float zeroHeight;
	float mscale = 100f; //Just to make it look more like an altitude
	Text uiText; 

	// Use this for initialization
	void Start () {

		Vector3 zeroPosition = man.cameraManager.thisCamera.ScreenToWorldPoint (Vector3.zero);

		zeroHeight = zeroPosition.y;

		uiText = UIRight.GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {

		altitude = (int) ( mscale * (man.shipManager.ship.transform.position.y - zeroHeight) );

		Vector3 velocity = man.shipManager.ship.GetComponent<Rigidbody2D>().velocity;
		uiText.text = "Altitude: " + altitude + "\nHorizontal Speed: " + Mathf.Round(10f*velocity.x) + "\nVertical Speed: " + Mathf.Round(10f*velocity.y);

	}
}
