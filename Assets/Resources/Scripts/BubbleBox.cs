using UnityEngine;
using System.Collections;

public class BubbleBox : Box {
	// Use this for initialization
	void Start () {
		Settings sets = new Settings ();
		gameObject.name = "BubbleBox";
		this.hp = sets.bubbleBoxHp;
		//gameObject.tag = "Box";
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
		OnBoxDestroy();
	}

}
