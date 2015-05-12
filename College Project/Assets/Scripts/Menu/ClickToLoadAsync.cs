using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickToLoadAsync : MonoBehaviour {

	public Slider loadingBar;
	public GameObject loadingScreen;

	AsyncOperation async;

	public void ClickAsync(int level){
		loadingScreen.SetActive (true);
		StartCoroutine (LoadLevelWithBar (level));
	}

	IEnumerator LoadLevelWithBar (int level) {
		// Call to return async operation to then check.
		async = Application.LoadLevelAsync (level);
		// Check whether operation is done and check the progress of it.
		while (!async.isDone) {
			// Set value of the loading bar to the progress of the async operation (real-time bar updates basically).
			loadingBar.value = async.progress;
			yield return null;
		}
	}
}