using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	public GameObject player;
	private GameObject[] tiles;
	
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
	    }
	}
}
