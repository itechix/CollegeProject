using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float playerHealth = 50f;
	public Text hCounter;

	//public Text hCounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		hCounter.text = " " + playerHealth;
	}

	public void playerHealthRestore () {
		playerHealth = 100f;
	}
}