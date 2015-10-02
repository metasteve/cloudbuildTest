using UnityEngine;
using System.Collections;


public class go1 : MonoBehaviour {

	// Use this for initialization
	string highscore_url = "https://www.airvr.io/anl/add.php";
	string section1 = "2";
	string section2 = "1";

	int score = -1;
	
	// Use this for initialization
	IEnumerator Start () {
		// Create a form object for sending high score data to the server
		WWWForm form = new WWWForm();
		// Assuming the perl script manages high scores for different games
		form.AddField( "sec", section1 );
		// The name of the player submitting the scores
		form.AddField( "subSec", section2 );
		// The score

		// Create a download object
		WWW download = new WWW( highscore_url, form );
		
		// Wait until the download is done
		yield return download;
		
		if(!string.IsNullOrEmpty(download.error)) {
			print( "Error downloading: " + download.error );
		} else {
			// show the highscores
			Debug.Log(download.text);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
