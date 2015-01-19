using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour
{
	public bool isVertical;
	public float minRespawnTime;
	public float maxRespawnTime;
	public float spawnRangeStart;
	public float spawnRangeEnd;
    public float percentToDecrease;
    private int frameCount;
	
	public GameObject obstacle;
	
	void Start ()
	{
		StartCoroutine (Spawn());
	    frameCount = 0;
	}

    void Update()
    {
        frameCount++;

        if (frameCount%600 == 0)
        {
            maxRespawnTime = maxRespawnTime - (maxRespawnTime * percentToDecrease);
        }
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


