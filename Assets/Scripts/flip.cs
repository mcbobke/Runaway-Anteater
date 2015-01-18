using UnityEngine;
using System.Collections;

public class flip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(scale.x * -1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
