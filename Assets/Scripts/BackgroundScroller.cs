using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
    public float speed;

	void Update ()
	{
	    Scroll();
	}

    void Scroll()
    {
        Vector3 currentPos = transform.position;

        if (currentPos.y <= -5.85f)
        {
            transform.position = new Vector3(0, 6);
        }

        else
        {
            transform.position = new Vector3(currentPos.x, currentPos.y - speed);
        }
    }
}
