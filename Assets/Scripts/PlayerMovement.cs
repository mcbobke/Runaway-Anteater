using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public int collisionCount;

	// Use this for initialization
	void Start ()
	{
	    Screen.SetResolution(800, 600, false);
	}
	
	// Update is called once per frame
	void Update ()
	{
        MoveCharacter();
	}

    void MoveCharacter()
    {
        Vector2 currentPos = player.rigidbody2D.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.rigidbody2D.MovePosition(new Vector2(currentPos.x + speed, currentPos.y));
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.rigidbody2D.MovePosition(new Vector2(currentPos.x - speed, currentPos.y));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            --collisionCount;
            Destroy(collision.gameObject);

            if (collisionCount == 0)
                Destroy(player);
            else
            {
                player.rigidbody2D.MovePosition(new Vector2(0, -2.5f));
                player.rigidbody2D.velocity = new Vector2(0, 0);
            }
        }
    }
}
