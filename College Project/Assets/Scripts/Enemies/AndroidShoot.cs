using UnityEngine;
using System.Collections;

public class AndroidShoot : MonoBehaviour {
	
	public GameObject humanTarget;
	public GameObject playerTarget;
	public PlayerHealth playerHealth;
		
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
		//float gunRayDistance = 50f;

		// SET TO UPDATED DIRECTIONAL CONTROL?!?!?!
		Vector3 rayDirection = GetComponent<Rigidbody>().transform.position;

		if (Physics.Raycast (transform.position, rayDirection, out hit)) {
			//Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red, 2f);
			if (hit.collider.CompareTag("Player")) {
				Debug.Log("player in range");
				Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
				playerHealth.playerHealth -= 10f;
			}
		}
	}
	
}