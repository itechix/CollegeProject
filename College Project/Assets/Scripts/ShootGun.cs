using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {
	

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
		gunInitialisation ();
		Debug.Log (aClipPistol.Count);

	}
	void Update ()
	{
		gunFire();
		aCounter.text = " " + aClipPistol[aClipCurrent];
	}


	void FixedUpdate ()
	{
		int aClipCheck = aClipPistol.Count - aClipCurrent;
		aClipCounter.text = "/ " + aClipCheck;


	}

	void gunInitialisation()
	{
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
	}

	/// <summary>
	/// Replenishes the pistol ammo.
	/// </summary>
	public void ReplenishPistolAmmo()
	{
		/* Turns out C# has some bizzaro definition of the foreach loop that prevents
		   the value from being modified. It's passed by reference but read-only.

		   So, there are a few different ways to accompish what we want to do.
		   This is the closest to our original foreach loop (it basically is a foreach loop)
		   and is the preffered method. It's fastest and most reliable. */

		/* P.S. Whoever's doing the modeling and skinning, epic work! */

		// We need to make sure the list isn't empty or it'll break.
		if (aClipPistol.Count < 1) // This is a type of shorthand if statement.
			return;                // If you only have one statement to execute you can omit the curly braces.

		// Now we loop through all the values.
		for (int i = 0; i < aClipPistol.Count - 1; i++) {
			aClipPistol[i] = 12;
		}
	}

	/// <summary>
	/// Replenishes the pistol ammo.
	/// </summary>
	public void ReplenishPistolAmmoAlt()
	{
		/* Second way of doing it, just gets rid of everything and starts over
		 * This has a potential to go wrong with null reference exceptions and shouldn't really be used. */
		
		// Wipe the list
		aClipPistol.Clear ();
		
		// Re-initalize it.
		gunInitialisation ();
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
				if(Physics.Raycast(ray, out hit, gunRayDistance, 1 << 8)) {
					Debug.Log("Bullet Hit");


					// The point of contact with the model is given by the hit.point (to not cause z-fighting issues with layering)
					Vector3 bulletHolePosition = hit.point + hit.normal * 0.01f;
					// Rotation to match where it hits (between the quad vector forward axis and the hit normal)
					Quaternion bulletHoleRotation = Quaternion.FromToRotation(-Vector3.forward, hit.normal);
					GameObject hole = (GameObject)GameObject.Instantiate(bulletHolePrefab, bulletHolePosition, bulletHoleRotation);
				}                                                         	                                                         
			}

			if(aClipPistol[aClipCurrent] == 0)
			{
				//Debug.Log ("Reload");
				// Activating the reload notification on the interface
				aReload.SetActive(true);
				gunReload();

				//aClipCurrent += 1;
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

			// Deactivating the reload notification and activating the out of ammo notification on the interface
//			aReload.SetActive(false);
//			aEmpty.SetActive (true);

	}

	void gunDamage()
	{
		
	}


}