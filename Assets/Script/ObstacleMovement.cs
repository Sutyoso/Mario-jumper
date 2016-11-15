using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField]
	float speed = 0.3f;

    public bool isRun = true;

    // Update is called once per frame
	/*
	 * method ini berguna agar obstacle tersebut dapat mundur ke arah character
	*/
    void Update()
    {
        if (isRun)
        {
            transform.position -= Vector3.right * speed;
            speed += 0.001f;
        }
    }
}
