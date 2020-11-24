using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

	public static int score;        // The player's score.
	static int highscore;

	Text text;                      // Reference to the Text component.

	public Text highscoreText;
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();

		// Reset the score.
		score = 0;
		highscore = PlayerPrefs.GetInt("highscore");
	}


	void Update ()
	{
		if (score > highscore)
		{
			highscore = score;
			PlayerPrefs.SetInt("highscore", highscore);

		}
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
		highscoreText.text = "High Score: " + highscore;
	}
}
