using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	Camera camera;
	public Timer timer;
	bool timer_ended, first_click;
	private int level_clicks;
	[SerializeField]
	AudioClip clickSound;
	Button button;
	// Use this for initialization
	void Start () {
		first_click = true;
		timer = new Timer (5f);
		camera = Camera.main;
		//button = new Button();
		if (Camera.main.GetComponent<Level>())
		level_clicks = Camera.main.GetComponent<Level> ().click;
		if(camera.GetComponent<Level>())
		camera.GetComponent<GUI> ().ShowClicks(level_clicks.ToString());
		clickSound = Resources.Load ("Sounds/button_click") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
		LevelTimerExec ();
		OnMouseClick();
		if (timer.timeEnded == true) {
			Debug.Log ("timer ended");
		}

		if (Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel (1);
	}

	private void LevelTimerExec(){
		if(first_click == false)
		timer.Start ();
		if (camera.GetComponent<GUI>())
		camera.GetComponent<GUI> ().ShowTimer (timer.GetTime());
	}

	public void OnMouseClick(){ //mouse click
		Ray ray;
		RaycastHit hit;
		GameObject hitten_object;
		if (Input.GetMouseButtonDown (0)) { //left mouse button
			if(Camera.main.GetComponent<AudioSource>())
			Camera.main.GetComponent<AudioSource>().PlayOneShot(clickSound);
			ray = Camera.main.ScreenPointToRay (Input.mousePosition); //ray from mouse position
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
				hitten_object = hit.transform.gameObject; //getting clicked object
				Debug.Log (hitten_object.name);
				if(hitten_object.gameObject.GetComponent<Box>() && level_clicks > 0){ //if box
					if (first_click == true){
						first_click = false;
					}
					level_clicks -= 1;	
					Camera.main.GetComponent<Level> ().click = level_clicks;
					camera.GetComponent<GUI> ().ShowClicks (level_clicks.ToString());
					hitten_object.GetComponent<Box>().hp-=1; //getting damage
					hitten_object.GetComponent<Box>().OnDamage();
				}
				if (hitten_object.tag == "Button"){
					//Debug.Log("Button Pressed");
					switch (hitten_object.name)
					{
						case ("LevelSelectButton"):
							button = new SelectLevelButton();
							break;
						case ("StartButton"):
							button = new StartButton();
							break;
					}
					button.OnClick(hitten_object , hitten_object.gameObject.name);
				}
			}

		}
	}
	

}

