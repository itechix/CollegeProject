using UnityEngine;
using System.Collections;

public class aimSights : MonoBehaviour {

	public GameObject normalPistolGun;
	public GameObject aimPistolGun;

	public GameObject crosshair;
	public GameObject redDot;

	public GameObject normalAssaultGun;
	public GameObject aimAssaultGun;

	public changeWeapon changeWeapon;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		changeGunView();
	}
	void changeGunView() {
		if (Input.GetButtonDown ("Fire2")) {
			Debug.Log ("sights up");
			if (changeWeapon.currentGun == changeWeapon.gunPistol) {
				normalPistolGun.SetActive(false);
				aimPistolGun.SetActive(true);
			}
			else if (changeWeapon.currentGun == changeWeapon.gunAssault) {
				normalAssaultGun.SetActive(false);
				aimAssaultGun.SetActive(true);
				redDot.SetActive(true);
			}
			crosshair.SetActive(false);

		}
		if (Input.GetButtonUp("Fire2")) {
			Debug.Log ("sights down");
			if (changeWeapon.currentGun == changeWeapon.gunPistol) {
				normalPistolGun.SetActive(true);
				aimPistolGun.SetActive(false);
			}
			else if (changeWeapon.currentGun == changeWeapon.gunAssault) {
				normalAssaultGun.SetActive(true);
				aimAssaultGun.SetActive(false);
				redDot.SetActive(false);
			}
			crosshair.SetActive(true);
		}
	}

}
