using UnityEngine;
using System.Collections;

public class mainEnemyLife : MonoBehaviour {

	public float enemyHealth = 100.0f;

	public lastShooter lastShooter;
	public enemyRespawn enemyRespawn;
	public ScoreboardDisplay scoreboardScore;

	// Update is called once per frame
	void FixedUpdate () {
		enemyDeath();
	}

	public void enemyTakeDamage(float damage) {
		enemyHealth -= damage;
	}

	public void enemyDeath() {
		if (enemyHealth <= 0.0f) {
			Debug.Log(this.gameObject.name + " was killed by " + lastShooter.shotLast);
			scoreboardScore.scoreboardIncrease();
			enemyRespawn.respawnEnemy();
			enemyHealth = 100.0f;
		}
	}
}