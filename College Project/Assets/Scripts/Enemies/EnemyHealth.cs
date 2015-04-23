using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float enemyHealth = 100.0f;
	public int playerScore = 0;
	public Text sCounter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		enemyDeath ();
		sCounter.text = " " + playerScore;
	}

	public void enemyShotHead() {
		enemyHealth -= 60f;
		Debug.Log (enemyHealth);
	}

	public void enemyShotTorso() {
		enemyHealth -= 40f;
		Debug.Log (enemyHealth);
	}

	public void enemyShotLimb() {
		enemyHealth -= 20f;
		Debug.Log (enemyHealth);
	}

	void enemyDeath() {
		if (enemyHealth <= 0.0f) {
			Debug.Log ("Enemy Killed");
			Destroy(gameObject);
			playerScore += 1;
		}
	}

}
