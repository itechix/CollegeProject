using UnityEngine;
using System.Collections;

public class SpawnHealthPickup : MonoBehaviour {
	
	public GameObject hPickup;
	bool isRespawning;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hPickup.gameObject.activeSelf == false && !isRespawning) {
			StartCoroutine (spawnHealth ());
			isRespawning = true;
		}
	}
	
	IEnumerator	spawnHealth() {
		Debug.Log ("No Pickup");
		yield return new WaitForSeconds (30f);
		Debug.Log ("Spawning new Health");
		hPickup.gameObject.SetActive(true);
		isRespawning = false;
	}
}