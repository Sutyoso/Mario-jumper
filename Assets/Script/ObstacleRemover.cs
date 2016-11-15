using UnityEngine;
using System.Collections;

public class ObstacleRemover : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*
	 * method yang ada pada update digunakan untuk menghilangkan obstacle
	 * method pada onTriggerEnter2D berguna saat obstacle tersebut menyentuh box collider yang ada di kanan background maka
	 * obstacle tersebut akan hilang
	*/

	void Update () {
		if (transform.position.x < -20) {
			Destroy (gameObject);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "obs")
		{
			Destroy(collider.gameObject);
		}
	}
}
