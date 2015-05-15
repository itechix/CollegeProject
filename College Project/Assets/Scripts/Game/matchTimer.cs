using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class matchTimer : MonoBehaviour {

	public GameOver gameOver;

	public Text timer;
	
	float seconds = 0;
	float minutes = 10;
	
	string secondsString;
	string minutesString;
	
	void Update() {

		timerCheck ();
		timerUpdateUI ();
		timerUpdateValues();
	}

	void timerUpdateValues() {
		seconds -= Time.deltaTime;
		if (seconds <= -1) {
			minutes -= 1f;
			seconds = 59f;
		}
		
		if (seconds < 10 && seconds >= 0) {
			secondsString = "0" + Mathf.RoundToInt(seconds).ToString ();
		}
		if (seconds >= 10 && seconds <= 60) {
			secondsString = Mathf.RoundToInt(seconds).ToString();
		}
		
		if (minutes < 10 && minutes >= 0) {
			minutesString = "0" + minutes.ToString ();
		}
		if (minutes >= 10 && minutes <= 10) {
			minutesString = minutes.ToString ();
		}
	}

	void timerUpdateUI() {
		timer.text = minutesString + ":" + secondsString;
	}

	void timerCheck() {
		if (minutes <= 0 && seconds <= 0) {
			gameOver.gameOverEnd();
		}
	}


}	