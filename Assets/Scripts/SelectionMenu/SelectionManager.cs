using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

// TODO: change playerpref to smth more safe.

[Serializable]
public struct initialMission {
	public int idx;
	public int fuel;
}

public class SelectionManager : MonoBehaviour {

	public GameObject[] missionCards;
	public initialMission[] fuel;
	public Transform[] missions;
	public Transform popup;

	private int actMissionCard = 0;
	private int missionSelected = 0;

	// Checks which leves are avaiable to the player
	private void loadSelectionMenu() {
		for (int i = 0; i < missions.Length; ++i) {
			if (PlayerPrefs.GetInt("level_" + i + "_score",-1) == -1 && !(i > 0 && PlayerPrefs.GetInt("level_" + (i-1) + "_score",0) > 0)) {
				missions[i].Find("Disabled").gameObject.SetActive(true);
				missions[i].Find("Enabled").gameObject.SetActive(false);
			} else {
				missions[i].Find("Enabled").gameObject.SetActive(true);
				missions[i].Find("Disabled").gameObject.SetActive(false);
				if (PlayerPrefs.GetInt("level_" + i + "_score",0) > 0) {
					missions[i].Find("Enabled/Completed").gameObject.SetActive(true);
				} else {
					missions[i].Find("Enabled/Completed").gameObject.SetActive(false);
				}
			}
		}
	}

	private void logMissionScores() {
		for (int i = 0; i < missions.Length; ++i) {
			Debug.Log ("Level "+i+" score: "+PlayerPrefs.GetInt("level_"+i+"_score"));
			Debug.Log ("Level "+i+" fuel: "+PlayerPrefs.GetInt("level_"+i+"_fuel"));
		}
	}

	public void launchPopup(int lvl) {
		popup.Find ("Score").GetComponent<Text> ().text = PlayerPrefs.GetInt("level_"+lvl+"_score").ToString();
		popup.Find ("Fuel").GetComponent<Text> ().text = PlayerPrefs.GetInt("level_"+lvl+"_fuel").ToString();
		foreach (Transform child in popup.Find ("Level")) {
			if (child.name == (lvl+1).ToString()) child.gameObject.SetActive(true);
			else child.gameObject.SetActive(false);
		}
		missionSelected = lvl;
		popup.gameObject.SetActive (true);
	}

	public void closePopup() {
		popup.gameObject.SetActive (false);
	}

	public void launchLevel() {

		if (missionSelected == 0 && PlayerPrefs.GetInt ("level_" + missionSelected + "_score", 0) <= 0) {
			Application.LoadLevel ("Tutorial");
		} else {
			Application.LoadLevel (missionSelected+1);
		}

		//PlayerPrefs.SetInt ("level_" + missionSelected + "_score", 3685);
		//PlayerPrefs.SetInt ("level_" + (missionSelected+1) + "_fuel", 1250);
	}

	public void changeCard (int incr) {
		actMissionCard += incr;
		if (actMissionCard < 0) {
			actMissionCard = 0;
		} else if (actMissionCard > missionCards.Length) {
			actMissionCard = missionCards.Length;
		}
		for (int i = 0; i < missionCards.Length; ++i) {
			if (i == actMissionCard) missionCards[i].SetActive(true);
			else missionCards[i].SetActive(false);
		}
	}

	void Start () {
		// Temporary, for development porpuses
		//PlayerPrefs.DeleteAll ();
		// Initialize score
		for (int i = 0; i < missions.Length; ++i) {
			if (!PlayerPrefs.HasKey("level_"+i+"_score")) PlayerPrefs.SetInt("level_"+i+"_score",-1);
			if (!PlayerPrefs.HasKey("level_"+i+"_fuel")) PlayerPrefs.SetInt("level_"+i+"_fuel",-1);
		}
		// Initialize initial fuel.
		for (int i = 0; i < fuel.Length; ++i) {
			PlayerPrefs.SetInt("level_"+fuel[i].idx+"_fuel", fuel[i].fuel);
		}

		// Make first mission avaiable allways (TODO: more than one initial mission avaiable?)
		if (PlayerPrefs.GetInt ("level_0_score") == -1) {
			PlayerPrefs.SetInt ("level_0_score",0);
		}
		PlayerPrefs.Save ();
	}

	void Update () {
		loadSelectionMenu ();
		//logMissionScores ();
	}
}
