using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	// Use this for initialization
	public int click;
	public int particlesReady {get; set;}
	public bool showAds;
	GameObject camera;
	private int box_particles;
	private int boxes;
	private bool is_box_was_destroyed;
	private int stars;
	private Timer _timer;
	private int level_finish_time;



	void Start(){
		_timer = Camera.main.GetComponent<Controls>().timer;
		//InitializeBackGround ();
		Debug.Log (string.Format("Level Started: you have {0} clicks",click));
		camera = GameObject.Find ("Main Camera");
		//string mess = Load ();
		//Debug.Log (mess);
		Camera.main.GetComponent<GUI> ().ShowLevelNumber ();
		ShowAds();
	}
	
	// Update is called once per frame
	void Update () {
		//if (GameObject.FindGameObjectsWithTag ("Box").Length + GameObject.FindGameObjectsWithTag ("Bubble").Length <=0)
		LevelFinish ();
	}


	private void InitializeBackGround(){ //setting bg 
		Background bg = new Background ();
		bg.height = 1f;
		bg.width = 1f;
		//bg.Publish("PBackGround");
	}
	
	
	bool is_level_saved;
	void LevelFinish(){

		if (_timer.GetTime() >= 0)
		{
			Debug.Log("Timer " + _timer.GetTime().ToString());
			level_finish_time = Mathf.RoundToInt(_timer.GetTime());
		}
		Debug.Log ("Boxes: " + GameObject.FindObjectsOfType<Box> ().Length);
		boxes = GameObject.FindObjectsOfType<Box> ().Length; //boxes amount on the scene
		box_particles = GameObject.FindGameObjectsWithTag ("Particle").Length; //particles amount on the scene

		Debug.Log (string.Format ("Particles: {0}, Boxes: {1}, Clicks: {2}", particlesReady, boxes, click));
		if (boxes <= 0 && click >= 0) {
			if (!is_level_saved){
				Debug.Log (string.Format ("Win & clicks left {0}", click));
				is_level_saved = Save(Application.loadedLevel, level_finish_time);
				Camera.main.GetComponent<GUI> ().ShowWinMenu ();


			}
		}
		else if (boxes > 0 && click <= 0 && particlesReady == 0)
		{
				Debug.Log (string.Format ("Game Over & boxes left {0}", boxes));
				Camera.main.GetComponent<GUI> ().ShowGameOverMenu ();
			
		}


	}

	bool Save(int level_number, int time){
		//TODO: добавить сохранение рейтига и исправить сохранение уровней
		int opened_levels;
		int stars_rating = 0;
		if (PlayerPrefs.HasKey("Opened_Levels")) //levels
		{
			opened_levels = PlayerPrefs.GetInt("Opened_Levels");

			if (opened_levels < level_number - 1)
			{
				opened_levels = (level_number - 1);
				PlayerPrefs.SetInt("Opened_Levels", opened_levels);
				PlayerPrefs.Save();
			}
		}
		else
		{
			PlayerPrefs.SetInt("Opened_Levels", 1);
			PlayerPrefs.Save(); //---------------------------------------levels------------
		}





		if (!PlayerPrefs.HasKey(Application.loadedLevel.ToString()))
		{

			if (time > 2)
				stars_rating = 2;
			if (time < 2)
				stars_rating = 1;

			PlayerPrefs.SetInt(Application.loadedLevel.ToString(), stars_rating);
			PlayerPrefs.Save();
		}

//-------------------------------------------------------------stars--------------

		return true;
	}

	string Load(){
		//TODO: запилить загрузку уровней и рейтинга
		int opened_levels = PlayerPrefs.GetInt ("Opened_Levels");

	
		return ("Loaded levels: " + opened_levels);

	}

	private void ShowAds()
	{
		//TODO: добавить принимаемы параметр с типом рекламы
		if (showAds == true)
		{
			Ads ad = new Ads();
			bool is_initialized = ad.Init();
			Debug.Log("Ads Initialization finished with: " + is_initialized);
			if (is_initialized)
			{
				ad.Show();
			}
		}
			
	}

	
}


