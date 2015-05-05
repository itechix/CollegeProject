using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public mainEnemyLife mainEnemyLife;

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
	}

	public void enemyShotHead() {
		mainEnemyLife.enemyTakeDamage (60f);
		Debug.Log ("Headshot!");
	}

	public void enemyShotTorso() {
		mainEnemyLife.enemyTakeDamage (40f);
		Debug.Log ("Bodyshot!");
	}

	public void enemyShotLimb() {
		mainEnemyLife.enemyTakeDamage (20f);
		Debug.Log ("Limbshot!");
	}
}