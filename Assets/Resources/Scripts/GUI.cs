using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
	Texture game_over_popup;
	// Use this for initialization
	[SerializeField]
	Transform UIPanelWin, UIPanelGameOver, UIClicksPanel; //Will assign our panel to this variable so we can enable/disable it
	[SerializeField]
	Text clickText, timerText,levelNumber;
	public Button nextButton, restartButton, levelSelectButton;
	
	[SerializeField]
	Text timeText; //Will assign our Time Text to this variable so we can modify the text it displays.
	
	bool isPaused; //Used to determine paused state
	void Start () {
		UIPanelWin.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
		UIPanelGameOver.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
		isPaused = false; //make sure isPaused is always false when our scene opens
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShowWinMenu(){
		isPaused = true;
		UIPanelWin.gameObject.SetActive (true);
		Camera.main.GetComponent<Controls> ().enabled = false;
	}

	public void ShowGameOverMenu(){
		isPaused = true;
		UIPanelGameOver.gameObject.SetActive (true);
		Camera.main.GetComponent<Controls> ().enabled = false;
	}
	
	public void NextLevel(){
		if (Application.CanStreamedLevelBeLoaded(Application.loadedLevel + 1))
		{
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		else
		{
			//TODO: Заставить дизайнера нарисовать попап и добавить 
			Debug.Log("This is last level");
		}
	}

	public void SelectLevel(){
		Application.LoadLevel (1);
	}

	public void RestartLevel(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void ShowClicks(string clicks){
		clickText.text = clicks.ToString();
	}

	public void ShowTimer(float time){
		timerText.text = Mathf.RoundToInt(time).ToString ();
	}

	public void ShowLevelNumber(){
		levelNumber.text = (Application.loadedLevel -1).ToString();
	}
}
