using UnityEngine;
using System.Collections;

public class StartButtonManager_forMobile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void Start_Button_Pushed()
	{
		Application.LoadLevel(1);
	}
}
