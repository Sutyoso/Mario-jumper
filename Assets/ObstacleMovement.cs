using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
	float speed = 0.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= Vector3.right * speed;
	}
}
