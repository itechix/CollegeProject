using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {

	public EnemyHealth enemyHealth;
	public ScoreboardDisplay scoreboardDisplay;

	public Text aCounter;
	public Text aClipCounter;

	public GameObject bulletSpawn;
	public GameObject aEmpty;
	public GameObject aReload;

	public GameObject bulletHolePrefab;

	int aClipCurrent = 0;

	// Creating a list for the different clips for the piston weapon (and the ammo in each clip)
	public List<int> aClipPistol = new List<int> ();

	void Start()
	{
		// Call the gunInitialisation function at the start when the script runs for the first time.
		gunInitialisation ();
		// Debug log
		Debug.Log (aClipPistol.Count);
	}

	void Update ()
	{
		// Call the firing function everu update to detect whenever the user triggers the if statement in it.
		gunFire();
		aCounter.text = " " + aClipPistol[aClipCurrent];
		int aClipCheck = aClipPistol.Count - aClipCurrent;
		aClipCounter.text = "/ " + aClipCheck;
	}

	// Function for initialising the guns and setting their starter ammo / clips.
	void gunInitialisation()
	{
		// Add four entries to the aClipPistol List of the value 12.
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
	}
	
	// Replenishes the pistol ammo
	public void ReplenishPistolAmmo()
	{
		// This checks to make sure the list isn't empty.
		if (aClipPistol.Count < 1)
			// 
			return;                

		// For loop for all of the values in the aClipPistol List.
		for (int i = 0; i < aClipPistol.Count - 1; i++) {
			// Set i to 12, which updates the value in the List.
			aClipPistol[i] = 12;
		}
		// Hide the Reload notification
		aReload.SetActive(false);
	}

	void gunFire()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(aClipPistol[aClipCurrent] > 0)
			{
				// Reducing the ammo of the current clip by 1.
				aClipPistol[aClipCurrent] -= 1;
				
				// Debug message for counting the ammo left
				Debug.Log ("Ammo remaining: " + aClipPistol[aClipCurrent]);
				//aCounter.text = " " + aClipPistol[aClipCurrent];
				
				// Raycasting for bullet projection against obstacles within the world (WIP)
				float gunRayDistance = 50f;
				
				Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
				
				// Name what for the raycast collides with (used to reference the target point)
				RaycastHit hit;

				// The actual raycast
				if(Physics.Raycast(ray, out hit, gunRayDistance, 1 << 9) || Physics.Raycast(ray, out hit, gunRayDistance, 1 << 8)) {
					Debug.Log("Bullet Hit");

					// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Head".
					if (hit.transform.CompareTag("Enemy_Head")) {
						Debug.Log ("Headshot!");
						//hitPoint = hit.collider.gameObject;
						//enemyHealth.enemyShotHead();
					}
					// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Torso".
					if (hit.transform.CompareTag("Enemy_Torso")) {
						Debug.Log ("Body-shot!");
						//hitPoint = hit.collider.gameObject;
						//enemyHealth.enemyShotTorso();
					}
					// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Limb".
					if (hit.transform.CompareTag("Enemy_Limb")) {
						Debug.Log ("Limb-shot!");
						//hitPoint = hit.collider.gameObject;
						//enemyHealth.enemyShotLimb();
					}

					// The point of contact with the model is given by the hit.point (to not cause z-fighting issues with layering)
					Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;
					// Rotation to match where it hits (between the quad vector forward axis and the hit normal)
					Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
					GameObject hole = (GameObject)GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);
					// Destroy the instantiated gameobject of the bulletHole after a delay of 5 seconds.
					Destroy (hole, 5.0f);
				}                                                         	                                                         
			}
			
			if(aClipPistol[aClipCurrent] == 0)
			{
				//Debug.Log ("Reload");
				// Activating the reload notification on the interface
				aReload.SetActive(true);
				gunReload();
			}
		}
	}

	void gunReload()
	{
		Debug.Log("Reload function check");
		if (Input.GetButtonDown("Reload"))
		{
			Debug.Log("Reload Button Check");
			
			// Deactivating the reload notification on the interface
			aReload.SetActive(false);
			// Incrementing the aClipCurrent value by 1 so the current clip "should" progress one along? idk
			aClipCurrent += 1;
		}		
	}
	
	void gunDamage()
	{
		
	}
}
