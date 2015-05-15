using UnityEngine;
using System.Collections;

public class loadAdditive : MonoBehaviour {

	public GameObject pause;

	public void UnloadOnClick() {
		pause = GameObject.Find ("PauseMenu");
		Destroy (pause);
	}
}
