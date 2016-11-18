using UnityEngine;
using System.Collections;

public class ObstacleGenerate : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obs;

    private Transform campos;

    public bool isRun = true;
    // Use this for initialization
    /*
	 * method ini berguna untuk memanggil obsRandom jika backroundnya berjalan 
	*/
    void Start()
    {
        if (isRun)
        {
            obsRandom();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    /*
	 * method ini berguna untuk merandom kemunculan dari obstacle
	*/
    private void obsRandom()
    {
        int obsIndex = Random.Range(4, obs.Length);
        GameObject obstacle = obs[obsIndex];
        Vector2 position = transform.position;
        if (obsIndex == 7|| obsIndex==6) {
            position = new Vector2(13.51f, Random.Range(-3.6f, -2.5f));
        }
        position += Vector2.up * obstacle.transform.position.y;
        GameObject temp = (GameObject)Instantiate(obstacle, position, Quaternion.identity);
        temp.name = "obs";
        temp.AddComponent<ObstacleRemover>();
        temp.AddComponent<ObstacleMovement>();
        float tempF = Random.Range(2, 3);
        Invoke("obsRandom", tempF);
    }
   
}