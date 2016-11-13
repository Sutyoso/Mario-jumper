using UnityEngine;
using System.Collections;

public class ObstacleRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -20) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collision collider)
	{
		if (collider.gameObject.name == "obs")
		{
			Destroy(collider.gameObject);
		}
	}
}
