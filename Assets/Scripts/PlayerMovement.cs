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
    public int antCount;

    public bool dead;
	public bool gameOver;

    private Animator anim;
    private Color invincibilityColor;
    public Image healthBar;
    public Image antBar;
    public Text scoreText;

    public AudioSource bikeSplat;
    public AudioSource pedSplat;
    public AudioSource collideSplat;
    public AudioSource antSoundNotFull;
    public AudioSource antSoundFull;

	void Start ()
	{
        invincibilityColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        hitTime = 0;
		anim = GetComponent<Animator> ();
		gameOver = false;
		dead = false;
        score = 0;
	    antCount = 0;
        scoreText.text = "Score: " + score;
	}
	
	void Update ()
	{
		if (!dead) 
        {
			MoveCharacter ();
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
            resetPos();

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
                healthBar.fillAmount -= 0.2f;

				if(collisionCount == 0)
                    killPeter();
             }

            else if (hitTime < invulnerability)
            {
                Physics2D.IgnoreCollision(collider2D, collision.gameObject.collider2D, true);
            }
        }

        else if (collision.gameObject.tag == "ant")
        {
            resetPos();

            if (antCount < 2)
            {
                antSoundNotFull.Play();
                antCount++;
                antBar.fillAmount += 0.34f;
            }

            else if (collisionCount < 5)
            {
                antSoundFull.Play();
                collisionCount++;
                healthBar.fillAmount += 0.2f;
                antCount = 0;
                antBar.fillAmount = 0f;
            }

            else if (antCount == 2 && collisionCount == 5)
            {
                antSoundFull.Play();
            }
            
            Destroy(collision.gameObject);
        }
    }

    void resetPos()
    {
        Vector2 currentPos = rigidbody2D.position;

        if (rigidbody2D.position.y != -2.12)
        {
            rigidbody2D.position = new Vector2(currentPos.x, -2.12f);
        }
    }

	private void killPeter()
	{
		gameOver = true;
		anim.SetBool("isDead", true);
		dead = true;
	}
}
