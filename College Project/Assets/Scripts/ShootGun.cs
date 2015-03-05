using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {

	public Text Ammo;
	public GameObject noAmmo;

	public int ammoCount = 30;

	void FixedUpdate ()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			if(ammoCount > 0)
			{
				ammoCount -= 1;
				Debug.Log ("Ammo remaining: " + ammoCount);
				Ammo.text = " " + ammoCount;
					
				Vector3 gunRayOrigin = transform.position;
				float gunRayDistance = 50f;

				Ray gunRay = new Ray ();
				gunRay.origin = gunRayOrigin;
				gunRay.direction = Vector3.down;
				
				if(Physics.Raycast(gunRayOrigin, gunRay.direction, gunRayDistance)) {
					Debug.Log("Bullet Hit");
				}
			}
			if(ammoCount == 0)
			{
				noAmmo.SetActive(true);
			}

		}

	}

}