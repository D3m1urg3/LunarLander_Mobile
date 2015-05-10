using UnityEngine;
using System.Collections;

public struct man
{
	public static SpaceShipManager_forMobile shipManager;
	public static UILeftManager uiLeftManager;
	public static UIRightManager uiRightManager;
	public static CameraManager_forMobile cameraManager;
	public static CollisionManager colManager;
	public static OverlayTextManager textManager;

}

public class Manager : MonoBehaviour {

	public SpaceShipManager_forMobile ship;
	public UILeftManager uiLeft;
	public UIRightManager uiRight;
	public CameraManager_forMobile theCamera;
	public CollisionManager colliders;
	public OverlayTextManager messages;

	void Awake () {
	
		man.shipManager = ship;
		man.uiLeftManager = uiLeft;
		man.uiRightManager = uiRight;
		man.cameraManager = theCamera;
		man.colManager = colliders;
		man.textManager = messages;
	}
	

}
