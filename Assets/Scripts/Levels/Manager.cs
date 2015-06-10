using UnityEngine;
using System.Collections;

public struct man
{
	public static SpaceShipManager_forMobile shipManager;
	//public static UILeftManager uiLeftManager;
	//public static UIRightManager uiRightManager;
	public static UI_Fuel_Manager uiFuel;
	public static CameraManager_forMobile cameraManager;
	public static CollisionManager colManager;
	public static OverlayTextManager textManager;
	public static SoundFXManager soundFxManager;

}

public class Manager : MonoBehaviour {

	public SpaceShipManager_forMobile ship;
	//public UILeftManager uiLeft;
	//public UIRightManager uiRight;
	public UI_Fuel_Manager fuel;
	public CameraManager_forMobile theCamera;
	public CollisionManager colliders;
	public OverlayTextManager messages;
	public SoundFXManager sound;

	public static bool IsGyroSupported;

	void Awake () {


		man.shipManager = ship;
	//	man.uiLeftManager = uiLeft;
	//	man.uiRightManager = uiRight;
		man.uiFuel = fuel;
		man.cameraManager = theCamera;
		man.colManager = colliders;
		man.textManager = messages;
		man.soundFxManager = sound;

		//Is gyroscope supported?
		IsGyroSupported = SystemInfo.supportsGyroscope;

		//PlayerPrefs.DeleteAll ();
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.DeleteAll ();
	}

}
