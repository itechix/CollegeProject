using UnityEngine;
using System.Collections;

public class humanShoot : MonoBehaviour {

	public mainEnemyLife enemyHealth;
	
	float gunDelay = 0.75f;
	public bool isShooting = false;
	
	// Update is called once per frame
	void Update () {
		shootGun ();
	}

	RaycastHit hit;
	void shootGun() {
		
		Vector3 rayDirection = GetComponent<Rigidbody>().transform.forward;
		
		if (Physics.Raycast (transform.position, rayDirection, out hit)) {
			Debug.Log("ally shoot check");

			if(hit.collider.CompareTag ("Enemy_Torso") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position, hit.point, Color.black, 2f);
			}
			if(hit.collider.CompareTag ("Enemy_Head") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position, hit.point, Color.black, 2f);
			}
			if(hit.collider.CompareTag ("Enemy_Limb") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position, hit.point, Color.black, 2f);
			}
		}
	}

	IEnumerator	enemyShootAlly() {
		Debug.Log("enemy damaged");
		
		enemyHealth.enemyHealth -= 15f;
		
		yield return new WaitForSeconds (gunDelay);
		isShooting = false;
	}
}