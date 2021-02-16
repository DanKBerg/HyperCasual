using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    private float startingZPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingZPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Touched");
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.rawPosition);
            Debug.Log(touchPosition);
            Debug.Log(touch.position);
            touchPosition.z = startingZPosition;
        }
    }
}
