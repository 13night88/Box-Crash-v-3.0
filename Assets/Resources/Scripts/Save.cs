using UnityEngine;
using System.Collections;

public class Save : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Load(){

	}

	public string SaveLevels(int level_number){
		string opened_levels = "";
	    if(PlayerPrefs.HasKey("Levels")) opened_levels = PlayerPrefs.GetString ("Levels");
		opened_levels += level_number.ToString ();
		PlayerPrefs.SetString ("Levels", opened_levels);
		PlayerPrefs.Save ();

		return "Saved";
	}
}
