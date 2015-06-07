using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UILeftManager : MonoBehaviour {


	// Public members
	//  Parameters
	public int score;
	public int time;
	public int fuel;
	//  Objects
	public GameObject UILeft;

	//Private members
	Text uiText;

	// Use this for initialization
	void Start() {

		time = 0;
		fuel = man.shipManager.fuel; //Get Fuel value from ship manager

		uiText = UILeft.GetComponent<Text> ();

		//Sets or Gets the score value in/from playerprefs
		// TODO: make it more clean
		if (PlayerPrefs.HasKey ("score")) {
			score = PlayerPrefs.GetInt("score");
		} 
		else {
			score = 0;
			PlayerPrefs.SetInt ("score", score);
		}
	}
	
	// Update is called once per frame
	void Update () {


		// Timer
		// TODO: use string parsing the ints
		int seconds, minutes, hours;

		hours = (int) time / 3600;
		minutes = (int)(time - hours * 3600) / 60;
		seconds = time - hours * 3600 - minutes * 60;

		uiText.text = "Score: " + score + "\nTIME: " + hours + ":" + minutes + ":" + seconds + "\nFUEL: " + fuel;

	}

	void FixedUpdate(){
		time++;
		fuel = man.shipManager.fuel;
		}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt ("score", 0);
		PlayerPrefs.SetInt ("fuel", 1000);
	}
}
