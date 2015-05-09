using UnityEngine;
using System.Collections;

public class changeWeapon : MonoBehaviour {

	public GameObject gunPistol;
	public GameObject gunAssault;
	public GameObject currentGun;

	// Use this for initialization
	void Start () {
		currentGun = gunAssault;
	}
	
	// Update is called once per frame
	void Update () {
		weaponSwitch ();
	}

	void weaponSwitch() {
		// Pistol
		if(Input.GetButton("Weapon1")) {
			gunPistol.SetActive(true);
			gunAssault.SetActive(false);
			currentGun = gunPistol;

		}
		// assault rifle else if because it doesn't need to be checked if the user uses button 1
		else if(Input.GetButton("Weapon2")) {
			gunAssault.SetActive(true);
			gunPistol.SetActive(false);
			currentGun = gunAssault;
		}
	}
}