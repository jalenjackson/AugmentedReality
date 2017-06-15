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
			urls("385841-2dark-limited-edition-windows-front-cover", "http://www.metacritic.com/game/pc/2dark");
			urls("7WaysToDie", "http://www.metacritic.com/game/xbox-one/7-days-to-die");
			urls("AdamsVentureOrigins", "http://www.metacritic.com/game/playstation-4/adams-venture-origins");
			urls("AdventureTimeFinnAndJakeInvestigations", "http://www.metacritic.com/game/playstation-4/adventure-time-finn-and-jake-investigations");
			urls("aegisOfEarthProtonovusAssault", "http://www.metacritic.com/game/playstation-4/aegis-of-earth-protonovus-assault");
			urls("AgathaChristieAbcMurders", "http://www.metacritic.com/game/pc/agatha-christie-the-abc-murders");
			urls("airConflictsDoublePack", "http://www.metacritic.com/game/playstation-4/air-conflicts-double-pack");
			urls("airConflictsPacificCarriers", "http://www.metacritic.com/game/playstation-4/air-conflicts-pacific-carriers");
			urls("airConflictsSecretWars", "http://www.metacritic.com/game/pc/air-conflicts-secret-wars");
			urls("airConflictsVietnameWar", "http://www.metacritic.com/game/playstation-4/air-conflicts-vietnam-ultimate-edition");
			urls("AkibasBeat", "http://www.metacritic.com/game/playstation-4/akibas-beat");
			urls("akibas-trip-2_6szz", "http://www.metacritic.com/game/playstation-vita/akibas-trip-undead-undressed");
			urls("alkehinesGun", "http://www.metacritic.com/game/playstation-4/alekhines-gun");
			urls("Alien_Isolation", "http://www.metacritic.com/game/playstation-4/alien-isolation");
			urls("arcaniaTheCompleteTale", "http://www.metacritic.com/game/playstation-4/arcania-the-complete-tale");
			urls("arkSurvival", "http://www.metacritic.com/game/playstation-4/ark-survival-evolved");
			urls("armaGallentDecksOfDestiny", "http://www.metacritic.com/game/playstation-4/armagallant-decks-of-destiny");
			urls("arsianTheWarriorsOfLegend", "http://www.metacritic.com/game/playstation-4/arslan-the-warriors-of-legend");
			urls("assasinsCreedBlackFlag", "http://www.metacritic.com/game/playstation-4/assassins-creed-iv-black-flag");
			urls("assasinsCreedSyndacate", "http://www.metacritic.com/game/playstation-4/assassins-creed-syndicate");
			urls("assasinsCreeedTheEzioCollection", "http://www.metacritic.com/game/playstation-4/assassins-creed-the-ezio-collection");
			urls("crashBandicootSaneTrilogy", "http://www.metacritic.com/game/playstation-4/crash-bandicoot-n-sane-trilogy");
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
			gameDetails ("385841-2dark-limited-edition-windows-front-cover", true, "6.9 Pretty Good!");
			gameDetails ("7WaysToDie", true, "3.5 Bad!");
			gameDetails ("AdamsVentureOrigins", true, "5.3 Mediocre!");
			gameDetails ("AdventureTimeFinnAndJakeInvestigations", true, "6.6 It's Okay");
			gameDetails ("aegisOfEarthProtonovusAssault", true, "5.7 Mediocre");
			gameDetails ("AgathaChristieAbcMurders", true, "No Rating Yet");
			gameDetails ("airConflictsDoublePack", true, "No Rating Yet");
			gameDetails ("airConflictsPacificCarriers", true, "4.8 Not So Good!");
			gameDetails ("airConflictsSecretWars", true, "6.4 Decent");
			gameDetails ("airConflictsVietnameWar", true, "3 BAD!");
			gameDetails ("AkibasBeat", true, "6 It's Okay");
			gameDetails ("akibas-trip-2_6szz", true, "6.4 It's Okay");
			gameDetails ("alkehinesGun", true, "3.6 Terrible");
			gameDetails ("Alien_Isolation", true, "7.9 Great!");
			gameDetails ("arcaniaTheCompleteTale", true, "4.2 pretty bad");
			gameDetails ("arkSurvival", true, "No Rating Yet");
			gameDetails ("armaGallentDecksOfDestiny", true, "No Rating Yet");
			gameDetails ("arsianTheWarriorsOfLegend", true, "6.9 Pretty Good");
			gameDetails ("assasinsCreedBlackFlag", true, "8.3 Great!");
			gameDetails ("assasinsCreedSyndacate", true, "7.6 GOOD!");
			gameDetails ("assasinsCreeedTheEzioCollection", true, "7.2 GOOD!");
			gameDetails ("crashBandicootSaneTrilogy", true, "No Rating Yet");




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
