using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

	public ShootGun shootGun;

	public float respawnTime = 1f;

	public GameObject player;

	public void respawnPlayer() {
		StartCoroutine (playerRe ());
	}

	IEnumerator	playerRe() {
		player.transform.position = this.transform.position;
		yield return new WaitForSeconds (respawnTime);
		Debug.Log (player.name + " has respawned.");
		shootGun.ReplenishAmmo ();
	}
}
