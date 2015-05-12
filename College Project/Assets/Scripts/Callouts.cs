using UnityEngine;
using System.Collections;

public class Callouts : MonoBehaviour {

	public int currentKills = 0;
	public GameObject player;
	public AudioClip[] calloutSounds;

	void Start () {
		calloutSounds = new AudioClip[8];
	}

	void checkKills() {
		if (currentKills >= 1) {
			int calloutNumber;
			calloutNumber = currentKills - 1;
			Debug.Log(currentKills + calloutNumber);
			AudioSource.PlayClipAtPoint(calloutSounds[calloutNumber], player.transform.position);
		}
	}

}
