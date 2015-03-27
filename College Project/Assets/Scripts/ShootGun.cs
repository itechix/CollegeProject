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
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		aClipPistol.Add (12);
		Debug.Log (aClipPistol.Count);

	}
	void Update ()
	{
		gunFire();
	}


	void FixedUpdate ()
	{
		int aClipCheck = aClipPistol.Count - aClipCurrent;
		aClipCounter.text = "/ " + aClipCheck;


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
				aCounter.text = " " + aClipPistol[aClipCurrent];

				// Raycasting for bullet projection against obstacles within the world (WIP)
				Vector3 rayOrigin = transform.position;
				float gunRayDistance = 50f;
				
				Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
				//ray.origin = rayOrigin;
				//ray.direction = Vector3.forward;

				// Name what for the raycast collides with
				RaycastHit hit;
				// The actual raycast
				if(Physics.Raycast(ray, out hit, 1 << 8)) {
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