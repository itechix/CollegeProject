using UnityEngine;
using System.Collections;

public class mainEnemyLife : MonoBehaviour {

	public float enemyHealth = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		enemyDeath();
	}

	public void enemyTakeDamage(float damage) {
		enemyHealth -= damage;
	}

	public void enemyDeath() {
		if (enemyHealth <= 0f) {
			gameObject.SetActive(false);
		}
	}
}