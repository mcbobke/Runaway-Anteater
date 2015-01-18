using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
	//private int respawnTime = 100;
	public float minRespawnTime;
	public float maxRespawnTime;
	
	public GameObject biker;
	
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
			Instantiate (biker, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (Random.Range (minRespawnTime, maxRespawnTime));
		}
	}
	
	void RandomizeLocation()
	{
		float newX = Random.Range(-2.0f, 2.0f);
		transform.position = new Vector3 (newX, transform.position.y, 0);
	}
}

