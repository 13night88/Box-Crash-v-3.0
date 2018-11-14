using UnityEngine;
using System.Collections;

public class Box : MyGameObject {
	
	protected string name { get; set; }
	public int scene_index { get; set;} //задается при подсчете количества объектов на сцене;
	string box_prefab_type;
	public AudioClip hit_sound;
	public string type { get; set; }


	void Start () {
		type = "Box";
	}

	void Update (){

	}

	public void OnBoxDestroy(){
		//TODO: Действия при уничтожении;
		if (this.hp <= 0) {
			Debug.Log (this.gameObject.tag + " 123");
			InstantiateParticles();
			Destroy (gameObject);
		}
	}

	protected void OnClick(){
		//TODO: Действия при клике


	}

	public void PlayHitSound(){
		Camera.main.GetComponent<AudioSource>().PlayOneShot(this.hit_sound);	
	}
	

	void InstantiateParticles(){
		switch (this.tag){
			case "Box":
			Debug.Log("Particles Box");
			Camera.main.GetComponent<Level>().particlesReady += 4;
				box_prefab_type = "BoxParticle";
				break;
			case "Bubble":
			Debug.Log("Particles Bubble");
			Camera.main.GetComponent<Level>().particlesReady += 4;
				box_prefab_type = "BubbleParticle";
				break;
			case "Ice":
			Camera.main.GetComponent<Level>().particlesReady += 4;
				box_prefab_type = "IceParticle";
				break;
			case "Stone":
			Camera.main.GetComponent<Level>().particlesReady += 4;
				box_prefab_type = "StoneParticle";
				break;
		}
		GameObject particle_right = Instantiate(Resources.Load("Prefabs/"+box_prefab_type)) as GameObject;
		particle_right.transform.position = this.transform.position;
		particle_right.transform.rotation  =  Quaternion.Euler (0,0,270f);
		GameObject particle_left = Instantiate(Resources.Load("Prefabs/"+box_prefab_type)) as GameObject;
		particle_left.transform.position = this.transform.position;
		particle_left.transform.rotation  =  Quaternion.Euler (0,0,90f);
		GameObject particle_up = Instantiate(Resources.Load("Prefabs/"+box_prefab_type)) as GameObject;
		particle_up.transform.position = this.transform.position;
		GameObject particle_down = Instantiate(Resources.Load("Prefabs/"+box_prefab_type)) as GameObject;
		particle_down.transform.position = this.transform.position;
		particle_down.transform.rotation  =  Quaternion.Euler (0,0,180f);

	}

	public void ShowHit (int HitMessage){
		Debug.Log (HitMessage.ToString());
	}

	public void OnDamage(){
		switch (hp){
		case 1:
			this.gameObject.GetComponent<Renderer>().material = Resources.Load("Materials/Wood") as Material;
			break;
		case 2:
			this.gameObject.GetComponent<Renderer>().material = Resources.Load("Materials/Buuble") as Material;
			break;
		case 3:
			this.gameObject.GetComponent<Renderer>().material = Resources.Load("Materials/Ice") as Material;
			break;
		}
	}


}
