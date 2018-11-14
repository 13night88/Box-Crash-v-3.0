//Should be attached to Main Camera in select level scene
//



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager: MonoBehaviour {
	private int opened_levels; //amount of finished levels
	private string levels_rating; 
	[SerializeField]
	public Material closedLevelMaterial; //material for locked level buttons
	private int[] load_stars_array;

	// Use this for initialization
	void Start () {
		string message = Load();
		Debug.Log(message);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string Load()
	{
		//TODO: запилить загрузку рейтинга
		opened_levels = PlayerPrefs.GetInt("Opened_Levels");
		levels_rating = PlayerPrefs.GetString("Stars_rating");
		 //-----------------------------------------------------raiting load (stars per level)-----------------
		int j = 2;
		List<int> tmp = new List<int>();
		while (PlayerPrefs.HasKey(j.ToString()))
		{
			tmp.Add(PlayerPrefs.GetInt(j.ToString()));
			Debug.Log(PlayerPrefs.GetInt(j.ToString()));
			j++;
		}

		load_stars_array = new int[tmp.Count];
		for (int i = 0; i < tmp.Count; i++)
		{
			load_stars_array[i] = tmp[i];

			
				Debug.Log("Level" + (i+2).ToString() + ": " + load_stars_array[i]);
		}

		//------------------------------------------------------------------------------------------------------------------


		return ("Finished Levels: " + opened_levels + "Stars_rating: " + levels_rating);
	}

	public void SetButtonActive(SelectLevelButton button)//set button active if prev level was complete succsessfully
	{
		if (button.LoadingLevelNumber-2 <= opened_levels)// -2 because firts 2 scenes in manager is menu 
		{
			button.active = true;
			Debug.Log("Level: " + (button.LoadingLevelNumber-1).ToString() + " Is Active = " + button.active);
		}

		if (!button.active)
		{
			button.GetComponent<Renderer>().material = closedLevelMaterial;
			button.GetComponentInChildren<Canvas>().enabled = false;
		}
	}

	public void SetRatingSkins(SelectLevelButton button)
	{
		
		if (button.GetComponent<SelectLevelButton>().active)
		{
			button.GetComponent<Renderer>().material = Resources.Load("Materials/Star1") as Material;
		}


	}

}
