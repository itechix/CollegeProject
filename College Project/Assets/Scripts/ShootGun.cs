using UnityEngine;
using System.Collections;

public class ShootGun : MonoBehaviour {
	
	public Rigidbody rocketPrefab;
	public Transform barrelEnd;

	public int ammoCount = 30;

	void Update ()
	{
		for(int i = 0; i < ammoCount; i++)
		{
			if(Input.GetButtonDown("Fire1"))
			{
				ammoCount -= 1;
				Debug.Log ("Ammo remaining: " + ammoCount);
				Rigidbody rocketInstance;
				rocketInstance = Instantiate(rocketPrefab, barrelEnd.position, barrelEnd.rotation) as Rigidbody;
				rocketInstance.AddForce(barrelEnd.forward * 1500);
			}
		}

	}
}