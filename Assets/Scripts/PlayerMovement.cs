using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;

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

        if (Input.GetKey(KeyCode.RightArrow) && currentPos.x < 2.0f)
        {
            player.rigidbody2D.MovePosition(new Vector2(currentPos.x + speed, currentPos.y));
        }

        else if (Input.GetKey(KeyCode.LeftArrow) && currentPos.x > -2.0f)
        {
            player.rigidbody2D.MovePosition(new Vector2(currentPos.x - speed, currentPos.y));
        }
    }
}
