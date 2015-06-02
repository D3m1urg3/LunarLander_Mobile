﻿using UnityEngine;
using System.Collections;

public class CameraManager_forMobile : MonoBehaviour {
	
	//Public members
	public Camera thisCamera;
	public ZoomZoneTrigger zoomTrigger;

	public GameObject ship;
	
	public float camZoomSize = 2f;
	public float cam_angular_speed;
	
	//Private members
	float camFullSize;
	Vector3 camOriginalPosition;
	bool checkForZoom;

	float initialGyro_z;

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
			Screen.autorotateToPortrait = Screen.autorotateToPortraitUpsideDown = false;
			Screen.orientation = ScreenOrientation.Landscape;

			m_gyro = Input.gyro;
			Input.gyro.enabled = true;
			m_gyro.enabled = true;

			initialGyro_z = m_gyro.rotationRateUnbiased.z;

			Debug.Log(m_gyro.attitude.eulerAngles.z);
			thisCamera.transform.eulerAngles = new Vector3(0.0f,0.0f,m_gyro.attitude.eulerAngles.z);


		}
	}

	// Update is called once per frame
	void Update () {

		thisCamera.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y,-10.0f);


		//Move camera with the ship
		if (Manager.IsGyroSupported || true) //for mobile
		{
			if(Mathf.Abs(m_gyro.rotationRateUnbiased.z) > 0.05f)
				thisCamera.transform.Rotate (0.0f, 0.0f,  cam_angular_speed*(initialGyro_z + m_gyro.rotationRateUnbiased.z));				
				
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

