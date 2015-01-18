using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public int collisionCount;
    public Image healthBar;
    public int invulnerability;
    private int hitTime;

	// Use this for initialization
	void Start ()
	{
	    Screen.SetResolution(800, 600, false);
        hitTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
        MoveCharacter();
        if (hitTime < invulnerability)
        {
            ++hitTime;
        }
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
        if (collision.gameObject.tag == "biker" || collision.gameObject.tag == "ped")
        {
            Destroy(collision.gameObject);
            if (hitTime == invulnerability)
            {
                hitTime = 0;
                --collisionCount;
                healthBar.fillAmount -= 0.34f;
            }
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
