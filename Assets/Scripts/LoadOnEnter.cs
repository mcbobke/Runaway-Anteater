using UnityEngine;
using System.Collections;

public class LoadOnEnter : MonoBehaviour {

	void Update () 
    {
	    if (Input.GetKey(KeyCode.Return))
	    {
	        Application.LoadLevel(2);
	    }
	}
}
