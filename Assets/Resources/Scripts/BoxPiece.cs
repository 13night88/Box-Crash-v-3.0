using UnityEngine;
using System.Collections;

public class BoxPiece : MyGameObject {
	private float speed { get; set;}
	private float rotateAngleZ { get; set; }
	private Vector3 direction { get; set;}
	private int timer;


	// Use this for initialization
	void Start () {
		Settings sets = new Settings();
		speed = sets.speed;
		rotateAngleZ = (int)Mathf.Round(this.transform.rotation.eulerAngles.z);
		//Debug.Log (rotateAngleZ);
	}
	
	// Update is called once per frame
	void Update () {
		direction = GetDirection ((int)rotateAngleZ);
		Move ();
	}

	void OnCollisionEnter(Collision coll){
		//TODO: Действия при столкновении
		if (coll.gameObject.GetComponent<Box>()) {
			coll.gameObject.GetComponent<Box>().PlayHitSound();
			coll.gameObject.GetComponent<Box>().hp -=1;
			coll.gameObject.GetComponent<Box>().ShowHit(coll.gameObject.GetComponent<Box>().hp);
			coll.gameObject.GetComponent<Box>().OnDamage();

			Destroy (this.gameObject); 
		}
	}
	
	private void Move(){
		this.transform.position = direction;
	}

	void OnBecameInvisible(){ //destroing particle if it is going out of field of view

		Destroy (this.gameObject);

	}

	void OnDestroy(){
		if (Camera.main)
		Camera.main.GetComponent<Level>().particlesReady -= 1;
		Debug.Log ("Destroyed: " + this.gameObject.tag );
	}

	private Vector3 GetDirection(int angle){
		Vector3 _direction = new Vector3(0,0,0);
		if (angle != null) {
			switch (angle) {
			case 90:
				_direction = new Vector3 (this.transform.position.x - Time.deltaTime * speed, this.transform.position.y, 0);
				break;
			case 180:
				_direction = new Vector3 (this.transform.position.x, this.transform.position.y - Time.deltaTime * speed, 0);
				break;
			case 270:
				_direction = new Vector3 (this.transform.position.x + Time.deltaTime * speed, this.transform.position.y, 0);
				break;
			case 0:
				_direction = new Vector3 (this.transform.position.x, this.transform.position.y + Time.deltaTime * speed, 0);
				break;
			default:
				_direction = new Vector3 (this.transform.position.x + Time.deltaTime * speed, this.transform.position.y, 0);
				break;

			}

		}
		return _direction;
	}
}
