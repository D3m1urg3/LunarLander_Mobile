using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	bool levelStart;

	Rigidbody2D ship_phys;
	
	void OnLevelWasLoaded()
	{
		levelStart = false;

		man.colManager.invicible = true;
		man.textManager.message.text = "TOUCH TO START";
		


	}


	// Use this for initialization
	void Start () {

		ship_phys = man.shipManager.ship.GetComponent<Rigidbody2D> ();
		
		if(!levelStart)
		{
			ship_phys.isKinematic = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if (!levelStart) 
		{
			foreach(Touch touch in Input.touches)
			{
				if(touch.phase == TouchPhase.Ended)
				{
					man.textManager.message.text = "";
					ship_phys.isKinematic = false;
					man.colManager.invicible = false;
					levelStart = true;
				}
			}
		}

	}

	public void GotoMenu() {
		Application.LoadLevel("Selection_Menu");
	}

	public void Replay() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
