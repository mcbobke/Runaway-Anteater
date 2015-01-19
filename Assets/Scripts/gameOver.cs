using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

	public GameObject player;
    public Text gameOverText;
    public Text scoreText;
	private GameObject[] tiles;
    private int finalScore;
	
	void Start()
	{
		tiles = GameObject.FindGameObjectsWithTag("backgroundTile");
	}
	
	void Update()
    {
	    if (player.GetComponent<PlayerMovement>().dead)
	    {
	        for (int i = 0; i < tiles.Length; i++)
	        {
	            tiles[i].GetComponent<BackgroundScroller>().speed = 0;
	        }

	        GameObject[] students = GameObject.FindGameObjectsWithTag("ped");

	        for (int i = 0; i < students.Length; i++)
	        {
	            students[i].GetComponent<Obstacle>().Y_vel = 0;
	        }

	        GameObject[] collides = GameObject.FindGameObjectsWithTag("pedbikecollide");

	        for (int i = 0; i < collides.Length; i++)
	        {
	            collides[i].GetComponent<Obstacle>().Y_vel = 0;
	        }

	        GameObject[] ants = GameObject.FindGameObjectsWithTag("ant");

	        for (int i = 0; i < ants.Length; i++)
	        {
	            ants[i].GetComponent<Obstacle>().Y_vel = 0;
	        }

	        GameObject[] inGameUI = GameObject.FindGameObjectsWithTag("ingameui");

	        for (int i = 0; i < inGameUI.Length; i++)
	        {
	            Destroy(inGameUI[i]);
	        }

	        gameOverText.gameObject.SetActive(true);
	        scoreText.gameObject.SetActive(true);
	        scoreText.text = "Your Final Score: " + finalScore + "\n Press R to restart!";
	    }

	    else
	    {
	        finalScore++;
	    }
	}
}
