using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	public GameObject player;
	private GameObject[] tiles;
	
	void Start(){
		tiles = GameObject.FindGameObjectsWithTag("backgroundTile");
	}
	
	void Update(){
		Debug.Log (player);
		if(player.GetComponent<PlayerMovement>().dead) 
		{
			for(int i = 0; i < tiles.Length; i++) {
				tiles[i].GetComponent<BackgroundScroller>().speed = 0;
			}
			GameObject[] students = GameObject.FindGameObjectsWithTag ("ped");
			for(int i = 0; i < students.Length; i++) {
				students[i].GetComponent<Obstacle>().Y_vel = 0;
			}
		}
	}
}
