using UnityEngine;
using System.Collections;

/// <summary>
/// Class ObstacleGenerate.
/// kelas untuk mengenerate obstacle berdasarkan waktu dan jenis obstcle yang akan di random
/// </summary>
public class ObstacleGenerate : MonoBehaviour
{

    [SerializeField]
    private GameObject[] obs;
    // Use this for initialization
    /// <summary>
    /// merupakan methods pembungkus dari methods obsRandom
    /// </summary>
    public void Start()
    {
        obsRandom();
    }
    
    /// <summary>
    /// method ini berguna untuk merandom obstacle yang akan muncul
    /// jika obstacle tersebut merupakan obstacle terbang akan di random nilai ketinggiannya
    /// </summary>
    private void obsRandom()
    {
        int obsIndex = Random.Range(0, obs.Length);
        GameObject obstacle = obs[obsIndex];
        Vector2 position = transform.position;
        if (obsIndex == 6) {
            position = new Vector2(13.51f, Random.Range(-3.7f, -2.5f));
        }
        else if (obsIndex == 7) {
            position = new Vector2(13.51f, Random.Range(-4.5f,-2.5f));
        }
        position += Vector2.up * obstacle.transform.position.y;
        GameObject temp = (GameObject)Instantiate(obstacle, position, Quaternion.identity);
        temp.name = "obs";
        temp.AddComponent<ObstacleRemover>();
        temp.AddComponent<ObstacleMovement>();
        float tempF = Random.Range(0.8f, 1.5f);
        Invoke("obsRandom", tempF);
    }
   
}