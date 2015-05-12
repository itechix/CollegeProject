using UnityEngine;
using System.Collections;

public class loadOnClick : MonoBehaviour {

	public GameObject loadingScreen;

	// Level = index in build settings of level wanted to load
	public void LoadScene(int level) {
		// Passing in level from the function
		Application.LoadLevel (level);
		loadingScreen.SetActive (true);
	}

	public void exitGame() {
		Application.Quit ();
	}

}
