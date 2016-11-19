using UnityEngine;
using System.Collections;

public class ObstacleRemover : MonoBehaviour {

    // Update is called once per frame
    /// <summary>
    /// method yang ada pada update digunakan untuk menghilangkan obstacle
    /// method pada onTriggerEnter2D berguna saat obstacle tersebut menyentuh box collider yang ada di kanan background maka
    /// obstacle tersebut akan hilang
    /// </summary>
    void Update()
    {
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
