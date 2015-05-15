using UnityEngine;
using System.Collections;

public class Callouts : MonoBehaviour {

	public int currentKills = 0;
	public GameObject player;
	public AudioClip[] calloutSounds;
	AudioSource calloutSource;

	void Start () {
		calloutSource = GetComponent<AudioSource> ();
	}

	public void checkKills() {
		if(currentKills >= 2 && currentKills <= 9) {
			int calloutNumber;
			calloutNumber = currentKills - 2;
			calloutSource.clip = calloutSounds [calloutNumber];
			calloutSource.Play ();
			Debug.Log ("Killstreak - " + currentKills);
		}
		if (currentKills >= 10) {
			calloutSource.clip = calloutSounds[7];
			calloutSource.Play ();
		}
	}
}