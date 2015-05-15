using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth = 100f;

	public Text hCounter;

	public AudioClip soundDeath;

	public PlayerRespawn playerRespawn;
	public ScoreboardDisplay scoreboardScore;

	AudioSource source;

	//public Text hCounter;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		playerHealthCheck ();
		hCounter.text = " " + playerHealth;
		Debug.Log (playerHealth);
	}

	public void playerHealthRestore () {
		playerHealth = 100f;
	}

	void playerHealthCheck() {
		if (playerHealth <= 0f) {
			source.PlayOneShot(soundDeath, 0.5F);
			Debug.Log ("player has no health");
			playerRespawn.respawnPlayer();
			playerHealth = 100f;
			scoreboardScore.scoreboardIncrease();
		}
	}
}