using UnityEngine;
using System.Collections;

public class allyRespawn : MonoBehaviour {

	public float respawnTime = 1f;
	public humanShoot humanShoot;

	public GameObject ally;

	public void respawnAlly() {
		StartCoroutine (humanRespawn());
	}

	IEnumerator	humanRespawn() {
		ally.SetActive(false);
		yield return new WaitForSeconds (respawnTime);
		ally.transform.position = this.transform.position;
		Debug.Log (ally.name + " has respawned.");
		ally.SetActive (true);
		humanShoot.isShooting = false;
	}
}