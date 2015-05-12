using UnityEngine;
using System.Collections;

public class humanShoot : MonoBehaviour {

	public mainEnemyLife enemyHealth;
	public lastShooter lastShot;
	
	float gunDelay = 0.75f;
	bool isShooting = false;
	
	// Update is called once per frame
	void Update () {
		shootGun ();
	}

	RaycastHit hit;
	void shootGun() {
		
		Vector3 rayDirection = GetComponent<Rigidbody>().transform.forward;
		
		if (Physics.Raycast (transform.position + transform.up * 1.5f, rayDirection, out hit)) {
			Debug.Log("ally shoot check");
			Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.black, 2f);

			if(hit.collider.gameObject.CompareTag ("Enemy_Torso") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.cyan, 2f);
				lastShot.shotLastUpdate(this.gameObject.name);
			}
			if(hit.collider.gameObject.CompareTag ("Enemy_Head") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.cyan, 2f);
				lastShot.shotLastUpdate(this.gameObject.name);
			}
			if(hit.collider.gameObject.CompareTag ("Enemy_Limb") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position + transform.up * 1.5f, hit.point, Color.cyan, 2f);
				lastShot.shotLastUpdate(this.gameObject.name);
			}
		}
	}

	IEnumerator	enemyShootAlly() {
		Debug.Log("enemy damaged");
		
		enemyHealth.enemyHealth -= 15f;
		
		yield return new WaitForSeconds (gunDelay);
		Debug.Log ("ally can shoot");
		isShooting = false;
	}
}