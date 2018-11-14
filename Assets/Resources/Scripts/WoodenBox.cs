using UnityEngine;
using System.Collections;

public class WoodenBox : Box {

	// Use this for initialization
	void Start () {
		Settings sets = new Settings ();
		gameObject.name = "WoodenBox";
		this.hp = sets.woodenBoxHp;
		gameObject.tag = "Box";
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
		OnBoxDestroy();
	}
}
