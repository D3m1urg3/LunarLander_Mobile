using UnityEngine;
using System.Collections;

public class StartButtonManager : MonoBehaviour {

	public GameObject buttonNormal;
	public GameObject buttonOver;
	public GameObject buttonPush;

	public TriggerRegister trigger;
	
	SpriteRenderer normalRender;
	SpriteRenderer pushRender;

	void Awake()
	{
		// Initially the button is not pushed
		buttonPush.GetComponent<Renderer>().enabled = false;
		buttonOver.GetComponent<Renderer>().enabled = false;
		buttonNormal.GetComponent<Renderer>().enabled = true;

	}

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
	
		if(!trigger.triggerIN)
		{
			//Button not Pushed
			buttonPush.GetComponent<Renderer>().enabled = false;
			buttonOver.GetComponent<Renderer>().enabled = false;
			buttonNormal.GetComponent<Renderer>().enabled = true;
		}
		else
		{
			buttonOver.GetComponent<Renderer>().enabled = true;

			if(Input.GetMouseButton(0))
			{
				//Button Pushed
				buttonOver.GetComponent<Renderer>().enabled = false;
				buttonPush.GetComponent<Renderer>().enabled = true;
				buttonNormal.GetComponent<Renderer>().enabled = false;
			}
			else if (Input.GetMouseButtonUp(0))
			{
				Application.LoadLevel(1);
			}

		}

	}
}
