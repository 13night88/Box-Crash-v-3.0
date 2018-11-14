using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectButtonLabel : MonoBehaviour {
	public Text levelButtonLabel;

	// Use this for initialization
	void Start () {
		Vector3 label_position = Camera.main.WorldToScreenPoint (this.transform.position);
		levelButtonLabel.transform.position = label_position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
