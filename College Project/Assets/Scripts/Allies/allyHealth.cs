using UnityEngine;
using System.Collections;

public class allyHealth : MonoBehaviour {

	public float humanHealth = 100.0f;
	public string allyName;

	public allyRespawn humanRespawn;
	public lastShooter lastShooter;
	public ScoreboardDisplay scoreboardScore;

	// Use this for initialization
	void Start () {
		allyName = this.gameObject.name;
	}

	void FixedUpdate () {
		humanDeath ();
	}
	void humanDeath() {
		if (humanHealth <= 0f) {
			gameObject.SetActive(false);
			Debug.Log(allyName + " was killed by " + lastShooter.shotLast);
			scoreboardScore.scoreboardIncrease();
			humanRespawn.respawnAlly();
			humanHealth = 100.0f;
		}
	}
}