using UnityEngine;
using System.Collections;

public abstract class  Button : MonoBehaviour {


	public abstract void OnClick(GameObject button, string button_name);
	/*{
		//Debug.Log (button_name);

		switch (button.name){
		case "LevelSelectButton2": //Select level button  (Кнопка выбора уровня в меню);
			
			int level_number = button.GetComponent<SelectLevelButton>().LoadingLevelNumber;
			if(Application.CanStreamedLevelBeLoaded(level_number) && button.GetComponent<SelectLevelButton>().active == true){
				Application.LoadLevel(level_number);
				}
				else{
					Debug.Log("There is no level to load :" + level_number);
				}
			break;
		case ("StartButton"):
			Application.LoadLevel(1);
			break;
		default:
		//TODO: think about defaul section
			Debug.Log("There is no action associated with that button: " +button.name);
			break;

		}
		//Application.LoadLevel (1);
	}*/
}
