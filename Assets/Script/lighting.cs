using UnityEngine;
using System.Collections;

public class lighting : MonoBehaviour {

    /// <summary>
    /// mengcover methods lightRand supaya diinisiasikan
    /// </summary
	public void Start () {
        this.lightRand();
	}

    /// <summary>
    /// methods untuk menrandom nilai intensity dari light dan di set ke GameObject Light
    /// </summary>
    private void lightRand()
    {
        float range = Random.Range(0f, 1.1f);
        GetComponent<Light>().intensity = Mathf.Abs(range);
        float temp = Random.Range(3.0f, 6f);
        Invoke("lightRand", temp);
    }
}