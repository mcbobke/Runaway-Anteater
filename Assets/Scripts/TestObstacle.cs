using UnityEngine;
using System.Collections;

public class TestObstacle : MonoBehaviour
{

    public GameObject obstacle;
    public float vel;
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 currentPos = obstacle.rigidbody2D.position;
	    obstacle.rigidbody2D.MovePosition(new Vector2(currentPos.x, currentPos.y - vel));
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(obstacle);
    }
}
