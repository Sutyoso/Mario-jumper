using UnityEngine;
using System.Collections;

public class ObstacleGenerate : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] obs;

	private Transform campos;

    private bool isRun = true;
	// Use this for initialization
	void Start () {
        if (isRun)
        {
            obsRandom();
        }
	}

	// Update is called once per frame
	void Update () {
    }

	private void obsRandom(){
		GameObject temp = (GameObject) Instantiate (obs [Random.Range (0, obs.Length)],transform.position,Quaternion.identity);
		temp.name = "obs";
		temp.AddComponent<PolygonCollider2D> ();
		temp.GetComponent<PolygonCollider2D> ().isTrigger = true;
        temp.AddComponent<ObstacleRemover>();
        temp.AddComponent<ObstacleMovement>();
		float tempF = Random.Range (2, 3);
		Invoke ("obsRandom", tempF);
	}

    public void setIsRun(bool isRun) {
        isRun = isRun;
    }
}