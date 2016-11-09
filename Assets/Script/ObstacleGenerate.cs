using UnityEngine;
using System.Collections;

public class ObstacleGenerate : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] obs;

	[SerializeField]
	private float scrollSpeed=0.3f;
	private Transform campos;
	// Use this for initialization
	void Start () {
		obsRandom ();
		obsMove ();
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * PlayerPrefs.GetInt ("speed") * Time.deltaTime);
		GameObject temp = GameObject.Find ("obs");
		//if (temp.transform.transform.position.x < campos.position.x-20) {
		///	Destroy (temp);
		//}
	}

	private void obsRandom(){
		GameObject temp = (GameObject) Instantiate (obs [Random.Range (0, obs.Length)],transform.position,Quaternion.identity);
		temp.name = "obs";
		temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<BoxCollider2D> ().isTrigger = true;
		float tempF = Random.Range (1, 7);
		Invoke ("obsRandom", tempF);
	}

	private void obsMove(){
		Vector2 offset = new Vector2 (Time.time * scrollSpeed,0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}