using UnityEngine;
using System.Collections;

public class AndroidShoot : MonoBehaviour {
	
	public GameObject humanTarget;
	public GameObject playerTarget;
	public PlayerHealth playerHealth;
	public allyHealth allyHealth;	

	float gunDelay = 0.75f;
	bool isShooting = false;
		
		// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shootGun ();
	}
	
	// Name what for the raycast collides with (used to reference the target point)
	RaycastHit hit;
	void shootGun() {

		Vector3 rayDirection = GetComponent<Rigidbody>().transform.forward;

		if (Physics.Raycast (transform.position, rayDirection, out hit)) {
			Debug.Log("enemy shoot check");
			Debug.DrawLine(transform.position, hit.point, Color.magenta, 2f);

			if (hit.collider.CompareTag("Player") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootPlayer ());
				Debug.DrawLine(transform.position, hit.point, Color.magenta, 2f);
			}
			if(hit.collider.CompareTag ("Ally") && isShooting == false) {
				isShooting = true;
				StartCoroutine (enemyShootAlly ());
				Debug.DrawLine(transform.position, hit.point, Color.black, 2f);
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