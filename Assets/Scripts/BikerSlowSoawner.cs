using UnityEngine;
using System.Collections;

public class BikerSlowSoawner : MonoBehaviour
{

    public GameObject biker;

	// Use this for initialization
	void Start ()
	{
	    Spawn();

	}

    void Spawn()
    {
        Instantiate(biker, new Vector3(1, 3), Quaternion.identity);
    }
}
