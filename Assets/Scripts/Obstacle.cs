using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private GameObject bgcollider1;
    private GameObject bgcollider2;
    private GameObject collideSound;
    public GameObject pedbikecollide;
    public float X_vel;
	public float Y_vel;

    void Start()
    {
        bgcollider1 = GameObject.Find("bgcollider1");
        bgcollider2 = GameObject.Find("bgcollider2");
        collideSound = GameObject.Find("Bike Crash");
        Physics2D.IgnoreCollision(collider2D, bgcollider1.collider2D, true);
        Physics2D.IgnoreCollision(collider2D, bgcollider2.collider2D, true);
    }
	
	void Update () 
    {
		transform.position = new Vector2 (transform.position.x + X_vel, transform.position.y + Y_vel);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ped" && gameObject.tag == "biker") 
        {
			Vector2 currentPos = rigidbody2D.position;

			Destroy (gameObject);
			Destroy (collision.gameObject);

			Instantiate (pedbikecollide, currentPos, Quaternion.identity);
		}
 
        else if ((collision.gameObject.tag == "ped" || collision.gameObject.tag == "pedbikecollide") && gameObject.tag == "ped") 
        {
			Physics2D.IgnoreCollision (collider2D, collision.gameObject.collider2D, true);
		}
 
        else if (collision.gameObject.tag == "pedbikecollide" && gameObject.tag == "biker")
        {
			Destroy(gameObject);
            collideSound.gameObject.audio.Play();
        }

        else if (collision.gameObject.tag == "ant" &&
                 (gameObject.tag == "biker" || gameObject.tag == "ped" || gameObject.tag == "pedbikecollide"))
        {
            Physics2D.IgnoreCollision(collider2D, collision.gameObject.collider2D, true);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
