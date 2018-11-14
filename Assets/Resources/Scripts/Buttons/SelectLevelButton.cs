//Script should be attached to LevelSelectButton prefab
//


using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectLevelButton : Button {
	public int LoadingLevelNumber;
	public bool active;
	private LevelManager manager;

	// Use this for initialization
	void Start () {
		manager = Camera.main.GetComponent<LevelManager>();
		manager.SetButtonActive(this);
		manager.SetRatingSkins(this);



		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	public override void OnClick(GameObject button, string button_name)
	{
		int level_number = button.GetComponent<SelectLevelButton>().LoadingLevelNumber;
		bool is_active = button.GetComponent<SelectLevelButton>().active;
		if (Application.CanStreamedLevelBeLoaded(level_number) && is_active == true)
		{
			SceneManager.LoadScene(level_number);
			
		}
		else
		{
			Debug.Log("<color = red>There is no level to load : </color>" + level_number);
		}
	}


}
