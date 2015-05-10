using UnityEngine;
using System.Collections;

public class allyHealth : MonoBehaviour {

	public float humanHealth = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		humanDeath ();
	}

	void humanDeath() {
		if (humanHealth <= 0f) {
			gameObject.SetActive(false);
		}
	}

}
