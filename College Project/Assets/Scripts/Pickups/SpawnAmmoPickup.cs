using UnityEngine;
using System.Collections;

public class SpawnAmmoPickup : MonoBehaviour {

	public GameObject aPickup;
	bool isRespawning;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (aPickup.gameObject.activeSelf == false && !isRespawning) {
			StartCoroutine (spawnAmmo ());
			isRespawning = true;
		}
	}

	IEnumerator	spawnAmmo() {
		Debug.Log ("No Pickup");
		yield return new WaitForSeconds (30f);
		Debug.Log ("Spawning new Ammo");
		aPickup.gameObject.SetActive(true);
		isRespawning = false;
	}
}