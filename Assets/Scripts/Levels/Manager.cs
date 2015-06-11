using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public struct man
{
	public static SpaceShipManager_forMobile shipManager;
	public static ShipShieldManager shipShieldManager;
	//public static UILeftManager uiLeftManager;
	//public static UIRightManager uiRightManager;
	public static UI_Fuel_Manager uiFuel;
	public static CameraManager_forMobile cameraManager;
	public static CollisionManager colManager;
	public static OverlayTextManager textManager;
	public static SoundFXManager soundFxManager;
	public static ComanderMsgManager comanderMsgManager;

}

public class Manager : MonoBehaviour {

	public SpaceShipManager_forMobile ship;
	public ShipShieldManager ship_shield;
	//public UILeftManager uiLeft;
	//public UIRightManager uiRight;
	public UI_Fuel_Manager fuel;
	public CameraManager_forMobile theCamera;
	public CollisionManager colliders;
	public OverlayTextManager messages;
	public SoundFXManager sound;
	public ComanderMsgManager comander;

	public static bool IsGyroSupported;

	void Awake () {


		man.shipManager = ship;
		man.shipShieldManager = ship_shield;
	//	man.uiLeftManager = uiLeft;
	//	man.uiRightManager = uiRight;
		man.uiFuel = fuel;
		man.cameraManager = theCamera;
		man.colManager = colliders;
		man.textManager = messages;
		man.soundFxManager = sound;
		man.comanderMsgManager = comander;

		//Is gyroscope supported?
		IsGyroSupported = SystemInfo.supportsGyroscope;

		//PlayerPrefs.DeleteAll ();
	}



	void OnApplicationQuit()
	{
		//PlayerPrefs.DeleteAll ();
	}

}
