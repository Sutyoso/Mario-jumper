using UnityEngine;
using System.Collections;

/// <summary>
/// kelas ini berguna untuk mengulang background
/// </summary>
public class Background : MonoBehaviour {

	[SerializeField]
	private float scrollSpeed=0.3f;

    // Update is called once per frame
    /// <summary>
    /// method ini berisi instruksi agar background pada game tersebut dapat berjalan 
    /// </summary>

    public void Update () {
		Vector2 offset = new Vector2 (Time.time * scrollSpeed,0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
        this.scrollSpeed += 0.001f;
	}
}
