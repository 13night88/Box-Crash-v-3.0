using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;


public class Ads : MonoBehaviour {
	//класс отвечает за отображение и подключение рекламы
	//TODO: добавить разные рекламные площадки
	private string gameId = "2904150";
	private bool testMode = false;

	public bool Init () {
		if (!Advertisement.isInitialized)
		{
			Advertisement.Initialize(gameId, testMode);
		}
		return Advertisement.IsReady();

	}
	



	public void Show()
	{

		Advertisement.Show();
		if(Advertisement.isShowing)
		Debug.Log("Show");
	} 
}
