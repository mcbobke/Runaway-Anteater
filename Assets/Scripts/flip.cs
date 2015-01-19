using UnityEngine;
using System.Collections;

public class flip : MonoBehaviour {

	void Start ()
    {
		Vector3 scale = transform.localScale;
		transform.localScale = new Vector3(scale.x * -1, 1, 1);
	}
}
