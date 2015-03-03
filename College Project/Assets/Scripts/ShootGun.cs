using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShootGun : MonoBehaviour {

	public Text Ammo;
	public GameObject endScreen;

	public int ammoCount = 30;

	void Update ()
	{
		for(int i = 0; i < ammoCount; i++)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				Vector3 gunRayOrigin = transform.position;
				float gunRayDistance = 50f;
				
				Ray gunRay = new Ray ();
				gunRay.origin = gunRayOrigin;
				gunRay.direction = Vector3.down;
				
				if(Physics.Raycast(gunRayOrigin, gunRay.direction, gunRayDistance)) {
					Debug.Log("Bullet Hit");
				}
				ammoCount -= 1;
				Debug.Log ("Ammo remaining: " + ammoCount);
				Ammo.text = " " + ammoCount;
			}
		}
		if(ammoCount == 0) {
			endScreen.SetActive(true);
		}

	}
}