using UnityEngine;
using System.Collections;

public class TestObstacle : MonoBehaviour
{

    public GameObject obstacle;
    public float X_vel;
	public float Y_vel;
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 currentPos = obstacle.rigidbody2D.position;
	    obstacle.rigidbody2D.MovePosition(new Vector2(currentPos.x + X_vel, currentPos.y + Y_vel));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "background")
        {
            Destroy(obstacle);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(obstacle);
    }
}
