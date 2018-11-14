using UnityEngine;
using System.Collections;

public class MyGameObject: MonoBehaviour{
	public float height { get; set;}
	public float width { get; set;}
	public Vector2 position { get; set;}
	public string material { get; set; }
	public int hp { get; set; }
	//public string prefabName { get; set;}


	public void Publish(string prefabName){
		GameObject go = Instantiate(Resources.Load("Prefabs/"+prefabName)) as GameObject;
		Vector2 _scale = go.transform.localScale;
		Vector2 _position = go.transform.position;
		_scale.y = height;
		_scale.x = width;
		go.transform.localScale = _scale;
	}

}
