using UnityEngine;
using System.Collections;

public class StoneBox : Box {

	// Use this for initialization
	void Start () {
		Settings sets = new Settings ();
		gameObject.name = "StoneBox";
		this.hp = sets.stoneBoxHp;
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
		OnBoxDestroy();
	}
}
