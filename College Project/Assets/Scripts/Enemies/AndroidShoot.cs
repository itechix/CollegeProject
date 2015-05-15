using UnityEngine;
using System.Collections;

public class AndroidShoot : MonoBehaviour {
	
	public GameObject humanTarget;
	public GameObject playerTarget;
	public PlayerHealth playerHealth;
	public allyHealth allyHealth;

	public lastShooter lastShot;

	float gunDelay = 0.75f;
	public bool isShooting = false;

	// Update is called once per frame
	void Update () {
		shootGun ();
	}
	
	// Name what for the raycast collides with (used to reference the target point)
	RaycastHit hit;
	void shootGun() {

		Vector3 rayDirection = GetComponent<Rigidbody>().transform.forward;

		if (Physics.Raycast (transform.position + transform.up * 1.5f, rayDirection, out hit)) {
			Debug.Log("enemy shoot check");
			Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.yellow, 2f);

			if (hit.collider.CompareTag("Player") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootPlayer ());
				Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.red, 2f);
				lastShot.shotLastUpdate(this.gameObject.name);
			}
			if(hit.collider.CompareTag ("Ally") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.red, 2f);
				lastShot.shotLastUpdate(this.gameObject.name);
			}
		}
	}
	IEnumerator	enemyShootPlayer() {
		Debug.Log("player damaged");

		playerHealth.playerHealth -= 15f;

		yield return new WaitForSeconds (gunDelay);
		isShooting = false;
	}

	IEnumerator	enemyShootAlly() {
		Debug.Log("ally damaged");

		allyHealth.humanHealth -= 15f;
		
		yield return new WaitForSeconds (gunDelay);
		isShooting = false;
	}
}