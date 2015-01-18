using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int collisionCount;
    public Image healthBar;
    public int invulnerability;
    private int hitTime;

	void Start ()
	{
	    Screen.SetResolution(800, 600, false);
        hitTime = 0;
	}
	
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
        Vector2 currentPos = rigidbody2D.position;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody2D.MovePosition(new Vector2(currentPos.x + speed, currentPos.y));
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody2D.MovePosition(new Vector2(currentPos.x - speed, currentPos.y));
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
                Destroy(gameObject);
            else
            {
                rigidbody2D.MovePosition(new Vector2(0, -2.5f));
                rigidbody2D.velocity = new Vector2(0, 0);
            }
        }
    }
}
