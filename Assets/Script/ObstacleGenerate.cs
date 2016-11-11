using UnityEngine;
using System.Collections;

public class ObstacleGenerate : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] obs;

	[SerializeField]
	private float speed=0.3f;

	private Transform campos;
	// Use this for initialization
	void Start () {
		obsRandom ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	private void obsRandom(){
		GameObject temp = (GameObject) Instantiate (obs [Random.Range (0, obs.Length)],transform.position,Quaternion.identity);
		temp.name = "obs";
		temp.AddComponent<BoxCollider2D> ();
		temp.GetComponent<BoxCollider2D> ().isTrigger = true;
		float tempF = Random.Range (1, 7);
		Invoke ("obsRandom", tempF);
	}
}