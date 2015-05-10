using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	//Public members
	public Camera thisCamera;
	public ZoomZoneTrigger zoomTrigger;

	public float camZoomSize = 2f;

	//Private members
	float camFullSize;
	Vector3 camOriginalPosition;
	bool checkForZoom;
	
	enum camMode {zoomIn, zoomOut};
	
	// Use this for initialization
	void Start () {
		
		checkForZoom = true;
		camFullSize = thisCamera.orthographicSize;
		camOriginalPosition = thisCamera.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (checkForZoom && zoomTrigger.doZoomIn) {
			SetCameraMode (camMode.zoomIn); // do the camera zoom in
			checkForZoom = false;
		} 
		else if (!zoomTrigger.doZoomIn && !checkForZoom) {
			SetCameraMode(camMode.zoomOut);
			checkForZoom = true;
		}
	}
	
	void SetCameraMode(camMode mode)
	{
		

		if (mode == camMode.zoomOut)
		{
			
			thisCamera.orthographicSize = camFullSize;
			thisCamera.transform.position = camOriginalPosition;
			
		}
		else
		{

			thisCamera.orthographicSize = camZoomSize;

			Vector3 shipPosition = man.shipManager.ship.transform.position;
			Vector3 camPosition = thisCamera.transform.position;
			float camLimitX = (1f*camFullSize - camZoomSize) * Screen.width/Screen.height; 

			thisCamera.transform.position = new Vector3(Mathf.Clamp(shipPosition.x,-camLimitX,camLimitX), -1f*camFullSize + camZoomSize , camPosition.z);

						
		}
		
		
	}

}
