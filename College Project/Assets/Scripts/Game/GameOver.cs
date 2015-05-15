using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


	// tried doing the components in a parent object,
	public GameObject healthCounter;
	public GameObject healthTag;
	public GameObject ammoCounter;
	public GameObject ammoClip;
	public GameObject crosshair;
	public GameObject redDot;
	public GameObject reload;
	public GameObject noAmmo;
	public GameObject minimap;

	public GameObject scoreboard;
	public GameObject endUI;

	public AudioClip victoryMusic;

	bool gameOver = false;

	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource> ();
	}

	public void gameOverEnd() {
		if(gameOver == false) {

			gameOver = true;

			healthCounter.SetActive (false);
			healthTag.SetActive (false);
			ammoCounter.SetActive (false);
			ammoClip.SetActive (false);
			crosshair.SetActive (false);
			redDot.SetActive (false);
			reload.SetActive (false);
			noAmmo.SetActive (false);
			minimap.SetActive (false);
			scoreboard.SetActive (true);

			source.PlayOneShot(victoryMusic, 0.5F);
		
			endUI.SetActive (true);
			Time.timeScale = 0;
		}
	}

}
