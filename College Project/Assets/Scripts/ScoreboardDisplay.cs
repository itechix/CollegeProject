using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreboardDisplay : MonoBehaviour {

	public GameObject scoreboard;
	int[] humanScores = new int[5] {0, 0, 0, 0, 0};
	int[] androidScores = new int[5] {0, 0, 0, 0, 0};

	// HUMANS TEAM
	public Text playerScore;

	public Text humanOneScore;
	public Text humanTwoScore;
	public Text humanThreeScore;
	public Text humanFourScore;

	// ANDROID TEAM
	public Text androidOneScore;
	public Text androidTwoScore;
	public Text androidThreeScore;
	public Text androidFourScore;
	public Text androidFiveScore;


	// Use this for initialization
	void Start () {
		int[] humanScores = new int[] {20, 5, 0, 0, 0};
	}
	
	// Update is called once per frame
	void Update () {
		scoreboardUpdate ();
		scoreboardToggle ();
	}

	void scoreboardUpdate() {
		// HUMAN score updates

		// convert to string so that it can be applied to text gui 
		playerScore.text = humanScores[0].ToString();
		humanOneScore.text = humanScores[1].ToString();
		humanTwoScore.text = humanScores[2].ToString();
		humanThreeScore.text = humanScores[3].ToString();
		humanFourScore.text = humanScores[4].ToString();

		// ANDROID score updates
		androidOneScore.text = androidScores[0].ToString();
		androidTwoScore.text = androidScores[1].ToString();
		androidThreeScore.text = androidScores[2].ToString();
		androidFourScore.text = androidScores[3].ToString();
		androidFiveScore.text = androidScores[4].ToString();
	}

	void scoreboardToggle() {
		if (Input.GetButtonDown ("Tab")) {
			Debug.Log("scoreboard on");
			scoreboard.SetActive (true);
		}
		if (Input.GetButtonUp ("Tab")){
			Debug.Log("scoreboard off");
			scoreboard.SetActive(false);
		}
	}
}