using UnityEngine;
using System.Collections;

public class IceBox : Box {

	// Use this for initialization
	void Start () {
		Settings sets = new Settings ();
		gameObject.name = "IceBox";
		this.hp = sets.iceBoxHp;
	}
	
	// Update is called once per frame
	void Update () {
		OnClick ();
		OnBoxDestroy();
	}
}
