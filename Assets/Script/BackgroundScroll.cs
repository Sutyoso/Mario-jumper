using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	[SerializeField]
	private float scrollSpeed=0.3f;
	
	// Update is called once per frame
	/*
	 * method ini berisi instruksi agar background pada game tersebut dapat berjalan 
	 * 
	*/

	void Update () {
		Vector2 offset = new Vector2 (Time.time * scrollSpeed,0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	}
}
