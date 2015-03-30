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