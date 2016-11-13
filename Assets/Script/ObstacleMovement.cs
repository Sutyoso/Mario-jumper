using UnityEngine;
using System.Collections;

public class ObstacleMovement : MonoBehaviour {
    [SerializeField]
	float speed = 0.3f;

    public bool isRun = true;
    // Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            transform.position -= Vector3.right * speed;
            speed += 0.00001f;
        }
    }
}
