using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton : Button  {


	public override void OnClick(GameObject button, string button_name)
	{
		SceneManager.LoadScene(1);

	}
}
