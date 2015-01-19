using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (Application.loadedLevel == 2)
        {
            Destroy(this.gameObject);
        }
    }
}