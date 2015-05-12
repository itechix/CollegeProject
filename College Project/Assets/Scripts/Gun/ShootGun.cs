using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {

	// COMMENT: Explain principles, choice reasons
	// Explain variables, what they do, why they were made
	
	public ScoreboardDisplay scoreboardDisplay;

	public lastShooter lastShot;

	public GameObject player;

	public Text aCounter;
	public AudioClip soundGunShoot;
	public Text aClipCounter;

	public GameObject bulletSpawn;
	public GameObject aEmpty;
	public GameObject aReload;

	public changeWeapon changeWeapon;

	public GameObject bulletHolePrefab;

	int aClipPistolCurrent = 0;
	int aClipAssaultCurrent = 0;

	AudioSource source;

	// Creating a list for the different clips for the pisto weapon (and the ammo in each clip)
	public List<int> aClipPistol = new List<int> ();
	public List<int> aClipAssault = new List<int> ();

	void Start()
	{
		source = GetComponent<AudioSource> ();
		// Call the gunInitialisation function at the start when the script runs for the first time.
		gunInitialisation ();
		// Debug log
	}

	void Update ()
	{
		if (changeWeapon.currentGun == changeWeapon.gunPistol) {
			aCounter.text = " " + aClipPistol[aClipPistolCurrent];
			int aClipPistolCheck = aClipPistol.Count - aClipPistolCurrent;
			aClipCounter.text = "/ " + aClipPistolCheck;
		}
		if (changeWeapon.currentGun == changeWeapon.gunAssault) {
			aCounter.text = " " + aClipAssault [aClipAssaultCurrent];
			int aClipAssaultCheck = aClipAssault.Count - aClipAssaultCurrent;
			aClipCounter.text = "/ " + aClipAssaultCheck;
		}

		if (Input.GetButtonDown ("Fire1")) {
			gunAmmoCheck();
		}
	}

	// Function for initialising the guns and setting their starter ammo / clips.
	void gunInitialisation()
	{
	// Add four entries to the aClipPistol List of the value 12. // SAY WHY, what makes it good? Programming principles?
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);

		aClipAssault.Add (30);
		aClipAssault.Add (30);
	}
	
	// Replenishes the pistol ammo
	public void ReplenishPistolAmmo()
	{
		// This checks to make sure the list isn't empty.
		if (aClipPistol.Count < 1 || aClipAssault.Count < 1)
			return;                

		// Interate through all of the values in the aClipPistol List.
		for (int i = 0; i < aClipPistol.Count - 1; i++) {
			// Set i to 12, which updates the value in the List.
			aClipPistol[i] = 12;
		}
		// Interate through all of the values in the aClipAssault List.
		for (int i = 0; i < aClipAssault.Count - 1; i++) {
			// Set i to 12, which updates the value in the List.
			aClipAssault[i] = 30;
		}
		// Hide the Reload notification
		aReload.SetActive(false);
	}

	void gunAmmoCheck()
	{

		if(changeWeapon.currentGun == changeWeapon.gunPistol && aClipPistol[aClipPistolCurrent] > 0) {
			gunFire ();
			// Reducing the ammo of the current clip by 1.
			// ClipPistol is being used (say array, why array
			aClipPistol[aClipPistolCurrent] -= 1;
		}
		if(changeWeapon.currentGun == changeWeapon.gunAssault && aClipAssault[aClipAssaultCurrent] > 0) {
			gunFire ();
			// Reducing the ammo of the current clip by 1.
			// ClipPistol is being used (say array, why array
			aClipAssault[aClipAssaultCurrent] -= 1;
		}

		if(aClipPistol[aClipPistolCurrent] == 0)
		{
			//Debug.Log ("Reload");
			// Activating the reload notification on the interface
			aReload.SetActive(true);
			gunReload();
		}
		if(aClipAssault[aClipAssaultCurrent] == 0)
		{
			//Debug.Log ("Reload");
			// Activating the reload notification on the interface
			aReload.SetActive(true);
			gunReload();
		}
	}

	void gunFire() {

		source.PlayOneShot(soundGunShoot, 0.5F);
	
		// Debug message for counting the ammo left
		Debug.Log ("Ammo remaining: " + aClipPistol[aClipPistolCurrent]);

		float gunRayDistance = 50f;
		
		Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
		
		// Name what for the raycast collides with (used to reference the target point)
		RaycastHit hit;
		
		// The actual raycast
		if(Physics.Raycast(ray, out hit, gunRayDistance, 1 << 9) || Physics.Raycast(ray, out hit, gunRayDistance, 1 << 8)) {
			Debug.Log("Bullet Hit");
			
			EnemyHealth enHit = hit.collider.gameObject.GetComponent<EnemyHealth>();
			
			// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Head".
			if (hit.collider.gameObject.CompareTag("Enemy_Head")) {
				Debug.Log ("Headshot!");
				//hitPoint = hit.collider.gameObject;
				enHit = hit.collider.gameObject.GetComponent<EnemyHealth>();
				enHit.enemyShotHead();
				lastShot.shotLastUpdate(player.gameObject.name);
			}
			// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Torso".
			if (hit.collider.gameObject.CompareTag("Enemy_Torso")) {
				Debug.Log ("Body-shot!");
				//hitPoint = hit.collider.gameObject;
				enHit = hit.collider.gameObject.GetComponent<EnemyHealth>();
				enHit.enemyShotTorso();
				lastShot.shotLastUpdate(player.gameObject.name);
			}
			// Checking if the raycast (bullet) collided with objects tagged with "Enemy_Limb".
			if (hit.collider.gameObject.CompareTag("Enemy_Limb")) {
				Debug.Log ("Limb-shot!");
				enHit = hit.collider.gameObject.GetComponent<EnemyHealth>();
				enHit.enemyShotLimb();
				lastShot.shotLastUpdate(player.gameObject.name);
			}
			// The point of contact with the model is given by the hit.point (to not cause z-fighting issues with layering)
			Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;
			// Rotation to match where it hits (between the quad vector forward axis and the hit normal)
			Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
			GameObject hole = (GameObject)GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);
			// Destroy the instantiated gameobject of the bulletHole after a delay of 5 seconds.
			Destroy (hole, 2.0f);
		}                                                         	                                                         
	}

	void gunReload()
	{
		Debug.Log("Reload function check");
		if (Input.GetButtonDown("Reload"))
		{
			Debug.Log("Reloading");
			if(changeWeapon.currentGun == changeWeapon.gunPistol) {
				aReload.SetActive(false);
				// Incrementing the aClipPistolCurrent value by 1 so the current clip "should" progress one along? idk
				aClipPistolCurrent += 1;
			}
			if(changeWeapon.currentGun == changeWeapon.gunAssault) {
				aReload.SetActive(false);
				// Incrementing the aClipPistolCurrent value by 1 so the current clip "should" progress one along? idk
				aClipAssaultCurrent += 1;
			}

		}		
	}

}
