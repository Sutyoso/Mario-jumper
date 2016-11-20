using UnityEngine;
using System.Collections;

/// <summary>
/// Class lighting.
/// kelas ini berfungsi untuk menentukan intensitas cahaya kepada background
/// </summary>
public class lighting : MonoBehaviour {

    /// <summary>
    /// meng-cover methods lightRand supaya diinisiasikan
    /// </summary>
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
        float temp = Random.Range(5.0f, 10.0f);
        Invoke("lightRand", temp);
    }
}