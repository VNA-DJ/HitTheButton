using UnityEngine;
using System.Collections;

public class share : MonoBehaviour 
{
	/* TWITTER VARIABLES*/

	//Twitter Share Link
	string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";

	//Language
	string TWEET_LANGUAGE = "en";

	//This is the text which you want to show
	string textToDisplay="My 'HIT THE BUTTON' Game's Score is ";

	//This link is attached to this post
	string url = "https://play.google.com/store/apps/details?id=com.WOLKY.HitTheButton";

	/*END OF TWITTER VARIABLES*/

	/* FACEBOOK VARAIBLES */

	//App ID
	string AppID = "147831819089829";

	//This link is attached to this post
	string Link = "http://www.google.com";

	//The URL of a picture attached to this post. The Size must be atleat 200px by 200px.
	string Picture = "https://i.hizliresim.com/8MAZPn.png";

	//The Caption of the link appears beneath the link name
	string Caption = "Check out My New Score: ";

	//The Description of the link
	string Description = "Enjoy Fun, free games! Challenge yourself or share with friends. Fun and easy to use games.";

	/* END OF FACEBOOK VARIABLES */

	// Twitter Share Button	
	public void shareScoreOnTwitter () 
	{
		Application.OpenURL (TWITTER_ADDRESS + "?text=" + WWW.EscapeURL(textToDisplay + " " + ScoreManager.score + "\n" + url ) + "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}
	
	// Facebook Share Button
	public void shareScoreOnFacebook ()
	{
		Application.OpenURL ("https://www.facebook.com/dialog/feed?" + "app_id=" + AppID + "&link=" + Link + "&picture=" + Picture
			+ "&caption=" + Caption + ScoreManager.score + "&description=" + Description);
	}
}
