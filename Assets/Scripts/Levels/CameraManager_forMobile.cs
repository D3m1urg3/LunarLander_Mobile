using UnityEngine;
using System.Collections;

public class CameraManager_forMobile : MonoBehaviour {
	
	//Public members
	public Camera thisCamera;
	public ZoomZoneTrigger zoomTrigger;

	public GameObject ship;
	
	public float camZoomSize = 2f;
	
	//Private members
	float camFullSize;
	Vector3 camOriginalPosition;
	bool checkForZoom;
	
	enum camMode {zoomIn, zoomOut};

	//Gyroscope 
	Gyroscope m_gyro;

	void Awake()
	{

	}
	
	// Use this for initialization
	void Start () {
		
		checkForZoom = true;
		camFullSize = thisCamera.orthographicSize;
		camOriginalPosition = thisCamera.transform.position;

		if(Manager.IsGyroSupported || true)
		{
			Screen.orientation = ScreenOrientation.Landscape;
			m_gyro = Input.gyro;
			m_gyro.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {

		thisCamera.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y,-10.0f);


		//Move camera with the ship
		if (Manager.IsGyroSupported || true) //for mobile
			thisCamera.transform.Rotate (0.0f, 0.0f, m_gyro.rotationRateUnbiased.z);

		
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

