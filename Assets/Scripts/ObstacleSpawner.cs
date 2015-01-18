using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
	//private int respawnTime = 100;
	public bool isVertical;
	public float minRespawnTime;
	public float maxRespawnTime;
	public float spawnRangeStart;
	public float spawnRangeEnd;
	
	public GameObject obstacle;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (Spawn());
	}
	
	IEnumerator Spawn() 
	{
		while (true) 
		{
			RandomizeLocation ();
			Instantiate (obstacle, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (minRespawnTime, maxRespawnTime));
		}
	}
	
	void RandomizeLocation()
	{
		if (isVertical) 
		{
			float newX = Random.Range (spawnRangeStart, spawnRangeEnd);
			transform.position = new Vector3 (newX, transform.position.y, 0);
		} 
		else 
		{
			float newY = Random.Range (spawnRangeStart, spawnRangeEnd);
			transform.position = new Vector3 (transform.position.x, newY, 0);
		}
	}
}


