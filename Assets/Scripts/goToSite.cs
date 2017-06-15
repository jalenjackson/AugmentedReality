using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using System.Timers; 
using UnityEngine.Video; 


public class goToSite : MonoBehaviour, ITrackableEventHandler {

	//initializing image title
	public UnityEngine.UI.Image imageTitle; 

	public string url = ""; 
	//audio source



	public UnityEngine.Video.VideoPlayer videoPlayer ; 

	// The image showing the title of the game

	//the particle system that shows when you click the image
	public ParticleSystem myParticleSystem; 

    
	private TrackableBehaviour mTrackableBehaviour;

	//the id associated with the game
	string trackableName = "";

	[SerializeField]
	private Text ratingOfGame = null;



    void Start()
    {

		


    	myParticleSystem.Stop(); 
    	imageTitle.enabled = false;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    IEnumerator addImg(){

		WWW www = new WWW(url);
        yield return www;
        imageTitle.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));

    }

  
   

    //url on click 

	void Update ()
	{

		if (Input.GetMouseButtonDown (0)) {

			//"urls" takes a trackable title and the url that the trackable will be sent to whenever you click it.

			urls("Just_Dance_2_Coverart", "http://www.metacritic.com/game/wii/just-dance-2");
			urls("Sonic_and_the_Secret_Rings_coverart", "http://www.metacritic.com/game/wii/sonic-and-the-secret-rings");
			urls("WiiPlay", "http://www.metacritic.com/game/wii/wii-play");
			urls("streetFighterVTekken", "http://www.metacritic.com/game/playstation-3/street-fighter-x-tekken");
			urls("image", "http://www.metacritic.com/game/playstation-3/nba-2k14");
			urls("BioShock_cover", "http://www.metacritic.com/game/pc/bioshock");

		}

	}



    public void OnTrackableStateChanged (
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
		    videoPlayer.enabled = true; 
			videoPlayer.Play ();

			StartCoroutine(addImg());
			// "gameDetails" takes a trackable name , a bool that checks if the title is enabled, the sprite image variable that is attached in the unity interface, and the rating

			gameDetails ("Just_Dance_2_Coverart", true, "7.4 Pretty Good");
			gameDetails ("Sonic_and_the_Secret_Rings_coverart", true, "5.5 Mediocre");
			gameDetails ("WiiPlay", true, "6 It's Okay");
			gameDetails ("streetFighterVTekken", true, "9 Awesome!");
			gameDetails ("image", true, "8.4 Great!");
			gameDetails ("BioShock_cover", true, "9.6 Amazing!");




		}
        // if the tracking is lost reset 
        else {
			if (videoPlayer.enabled = true) {
				videoPlayer.Pause ();
			}
			ratingOfGame.text = "";
			trackableName = "";
			myParticleSystem.Stop();
        }
    } 



    //Helper methods 

    public void urls(string nameOfTheTrackable, string url){
		if (trackableName == nameOfTheTrackable) {
				myParticleSystem.Play ();
				StartCoroutine (reDirect (url, 2.2f));
			}
    }

	public void gameDetails( string nameOfTrackable, bool isTitleEnabled, string rating ){

		if (mTrackableBehaviour.Trackable.Name == nameOfTrackable) {

				imageTitle.enabled = isTitleEnabled; 
				ratingOfGame.text = rating;
				trackableName = nameOfTrackable;

			}
      } 


	IEnumerator reDirect(string url, float time)
         {
             yield return new WaitForSeconds(time);
             Application.OpenURL(url);
         }

	
}
