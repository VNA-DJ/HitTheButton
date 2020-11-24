using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GoogleService : MonoBehaviour {

	public GameObject content;

	// Use this for initialization
	void Start () {
		content.SetActive (false);
		PlayGamesPlatform.Activate ();

		Social.localUser.Authenticate ((bool success) => {
			if(success)
				Debug.Log("Login Successfully");
			else
				Debug.Log("Login Failed");
		});
	}
	
	// Update is called once per frame
	public void ReportScore () {
		if (ScoreManager.score <= 100)
			content.SetActive (true);
		else {
			Social.ReportScore (ScoreManager.score, "CgkI2-D-upIEEAIQAQ", (bool success) => {
				if (success)
					Debug.Log ("Score Reported.");
				else
					Debug.Log ("Reporting failed");
		
			});
		}


			
	}

	public void ShowLeaderboard(){
		Social.ShowLeaderboardUI();
		((PlayGamesPlatform)Social.Active).ShowLeaderboardUI ("CgkI2-D-upIEEAIQAQ");
	}

	public void RateUs()
	{
		Application.OpenURL ("market://details?id=com.trollugames.caverun3d");
	}

	public void LogOut()
	{
		((PlayGamesPlatform)Social.Active).SignOut ();
	}

	public void Ok()
	{
		content.SetActive (false);
	}
}
