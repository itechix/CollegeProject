using UnityEngine;
using System.Collections;

public class enemyRespawn : MonoBehaviour {

	public float respawnTime = 1f;
	public GameObject enemy;
	public AndroidShoot androidShoot;
	public mainEnemyLife enemyHealth;

	public void respawnEnemy() {
		StartCoroutine (androidRespawn());
	}
	
	IEnumerator	androidRespawn() {
		enemy.SetActive (false);
		yield return new WaitForSeconds (respawnTime);
		enemy.transform.position = this.transform.position;
		enemy.SetActive (true);
		Debug.Log (enemy.name + " has respawned.");
		androidShoot.isShooting = false;
		enemyHealth.isRespawning = false;
	}
}