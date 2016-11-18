using UnityEngine;
using System.Collections;

public class ObstacleGenerate : MonoBehaviour {
	
	[SerializeField]
	private GameObject[] obs;

	private Transform campos;

    public bool isRun = true;
	// Use this for initialization
	/*
	 * method ini berguna untuk memanggil obsRandom jika backroundnya berjalan 
	*/
	void Start () {
        if (isRun)
        {
            ScoreManager sm = gameObject.GetComponent<ScoreManager>();
            if (sm.getCount() < 500)
            {
                obsRandom();
            }
            else
            {
                obsRandom2();
            }
        }
	}

	// Update is called once per frame
	void Update () {
    }
	/*
	 * method ini berguna untuk merandom kemunculan dari obstacle
	*/
	private void obsRandom(){
		GameObject obstacle = obs [Random.Range (0, obs.Length-1)];
		Vector2 position = transform.position;
		position+= Vector2.up * obstacle.transform.position.y;
		GameObject temp = (GameObject) Instantiate (obstacle,position,Quaternion.identity);
        temp.name = "obs";
		temp.AddComponent<PolygonCollider2D> ();
		temp.GetComponent<PolygonCollider2D> ().isTrigger = true;
        temp.AddComponent<ObstacleRemover>();
        temp.AddComponent<ObstacleMovement>();
		float tempF = Random.Range (2, 3);
		Invoke ("obsRandom", tempF);
	}
    private void obsRandom2()
    {
        GameObject obstacle = obs[Random.Range(0, obs.Length)];
        
        Vector2 position = transform.position;
        position += Vector2.up * obstacle.transform.position.y;
        GameObject temp = (GameObject)Instantiate(obstacle, position, Quaternion.identity);
        temp.name = "obs";
        temp.AddComponent<PolygonCollider2D>();
        temp.GetComponent<PolygonCollider2D>().isTrigger = true;
        temp.AddComponent<ObstacleRemover>();
        temp.AddComponent<ObstacleMovement>();
        float tempF = Random.Range(2, 3);
        Invoke("obsRandom", tempF);
    }
}