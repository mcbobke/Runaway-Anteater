using UnityEngine;
using System.Collections;

public class TestObstacle : MonoBehaviour
{

    public GameObject obstacle;
    private GameObject bgcollider1;
    private GameObject bgcollider2;
    public float X_vel;
	public float Y_vel;

    void Start()
    {
        bgcollider1 = GameObject.Find("bgcollider1");
        bgcollider2 = GameObject.Find("bgcollider2");
        Physics2D.IgnoreCollision(obstacle.collider2D, bgcollider1.collider2D, true);
        Physics2D.IgnoreCollision(obstacle.collider2D, bgcollider2.collider2D, true);
    }
	
	void Update () 
    {
        Vector2 currentPos = obstacle.rigidbody2D.position;
	    obstacle.rigidbody2D.MovePosition(new Vector2(currentPos.x + X_vel, currentPos.y + Y_vel));
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "background" && obstacle.tag == "biker")
        {
            Destroy(obstacle);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(obstacle);
    }
}
