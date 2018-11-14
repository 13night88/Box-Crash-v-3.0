using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	private float time;
	public bool timeEnded;
		// Use this for initialization

	
	// Update is called once per frame
	void Update () {

	}

	public Timer(float target_time){
		time = target_time;
		Debug.Log ("Timer Created");
	}


	public void Start(){
		if(time >= 0.0f)
		time -= Time.deltaTime;
		//Debug.Log (time.ToString ());
		if (time <= 0.0f)
		{
			timeEnded = TimerEnd();
		}
	}
	
	public bool TimerEnd()
	{
		return true;
	}

	public float GetTime(){
		return time;
	}
	
	
}

