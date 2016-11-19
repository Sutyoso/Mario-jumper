using UnityEngine;
using System.Collections;

/// <summary>
/// kelas yang berfungsi untuk membuat obstacle dapat berjalan
/// </summary>
public class ObstacleMovement : MonoBehaviour {
    [SerializeField]
	private float speed = 0.3f;

    public bool isRun = true;

    // Update is called once per frame
    /// <summary>
    /// method ini berguna agar obstacle tersebut dapat mundur ke arah character
    /// speed perpindahan obstacle akan bertambah cepat
    /// </summary>
    public void Update()
    {
        if (isRun)
        {
            transform.position -= Vector3.right * speed;
            this.speed += 0.001f;
        }
    }
}
