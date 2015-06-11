using UnityEngine;
using System.Collections;

public class CameraManager_forMobile : MonoBehaviour {
	
	//Public members
	public Camera thisCamera;
	public ZoomZoneTrigger zoomTrigger;

	public GameObject ship;
	
	public float camZoomSize = 3f;
	public float cam_angular_speed;
	
	//Private members
	float camFullSize;
	Vector3 camOriginalPosition;
	bool checkForZoom;

	float angle_zero;

	enum camMode {zoomIn, zoomOut};

	//Gyroscope 
	Gyroscope m_gyro;

	void Awake()
	{
		thisCamera.orthographicSize = 5f;
	}
	
	// Use this for initialization
	void Start () {
		
		checkForZoom = true;
		camFullSize = thisCamera.orthographicSize;
		camOriginalPosition = thisCamera.transform.position;

		if(Manager.IsGyroSupported || true)
		{
			Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
			Screen.autorotateToLandscapeLeft = Screen.autorotateToLandscapeRight = false;
			Screen.orientation = ScreenOrientation.LandscapeLeft;

			m_gyro = Input.gyro;
			Input.gyro.enabled = true;
			m_gyro.enabled = true;

			thisCamera.transform.eulerAngles = Vector3.zero;




		}
	}

	// Update is called once per frame
	void Update () {

		thisCamera.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y,-10.0f);

		if (man.shipManager.shipDestroyed)
			return;


		//Move camera with the ship
		if (Manager.IsGyroSupported || true) //for mobile
		{
			if(Mathf.Abs(m_gyro.rotationRateUnbiased.z) > 0.05f)
			{
				float angle = m_gyro.attitude.eulerAngles.z - 360.0f;

				//Debug.Log("gyro euler: " + m_gyro.attitude.eulerAngles);
				//Debug.Log("angle: " + angle);
				//Debug.Log("Device Rotation rate: : " + m_gyro.rotationRateUnbiased.z);

				thisCamera.transform.Rotate (0.0f, 0.0f,  cam_angular_speed*(m_gyro.rotationRateUnbiased.z)*Time.deltaTime);				

			}
				

				
		}
		
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

