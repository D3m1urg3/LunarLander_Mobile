﻿using UnityEngine;
using System.Collections;

public struct startman
{
	//public static StartButtonManager startButtonManager;
	public static StartButtonManager_forMobile startButtonManager;
	//public static PointerManager pointerManager;
	//public static TriggerManager triggerManager;

}

public class StartManager : MonoBehaviour {

	//	public StartButtonManager start;
	public StartButtonManager_forMobile start;
	//public PointerManager pointer;
	//public TriggerManager trigger;


	void Awake () 
	{

		startman.startButtonManager = start;
		//startman.pointerManager = pointer;
		//startman.triggerManager = trigger;
	
	}
	

}
