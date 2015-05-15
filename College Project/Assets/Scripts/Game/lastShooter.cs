using UnityEngine;
using System.Collections;

public class lastShooter : MonoBehaviour {

	public string shotLast;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void shotLastUpdate(string lastShoot) {
		shotLast = lastShoot;
	}

}
