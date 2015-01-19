using UnityEngine;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public int collisionCount;
    public int invulnerability;
    private int hitTime;
    private int score;

    private Color invincibilityColor;
    public Image healthBar;
    public Text scoreText;

    public AudioSource bikeSplat;
    public AudioSource pedSplat;
    public AudioSource collideSplat;

	void Start ()
	{
	    //Screen.SetResolution(800, 600, false);
	    //Application.targetFrameRate = 60;
        invincibilityColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        hitTime = 0;
        score = 0;
        scoreText.text = "Score: " + score;
	}
	
	void Update ()
	{
        MoveCharacter();
        score++;
        scoreText.text = "Score: " + score;

	    if (hitTime < invulnerability)
	    {
	        ++hitTime;

	        renderer.material.color = invincibilityColor;
	    }
	    else if (renderer.material.color == invincibilityColor)
	    {
	        renderer.material.color = Color.white;
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
        if (collision.gameObject.tag == "biker" || collision.gameObject.tag == "ped" || collision.gameObject.tag == "pedbikecollide")
        {
            if (hitTime == invulnerability)
            {
                if (collision.gameObject.tag == "biker")
                    bikeSplat.Play();
                else if (collision.gameObject.tag == "ped")
                    pedSplat.Play();
                else if (collision.gameObject.tag == "pedbikecollide")
                    collideSplat.Play();

                Destroy(collision.gameObject);
                hitTime = 0;
                --collisionCount;
                healthBar.fillAmount -= 0.34f;

                rigidbody2D.velocity = new Vector2(0, 0);
            }

            else if (hitTime < invulnerability)
            {
                Physics2D.IgnoreCollision(collider2D, collision.gameObject.collider2D, true);
            }
        }
    }
}
