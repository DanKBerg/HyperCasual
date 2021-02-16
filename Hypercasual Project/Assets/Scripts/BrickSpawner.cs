using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickSnyder;

    public Camera cam;

    private bool spawnBrick = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If the user touches the screen.
        if (Input.touchCount > 0)
        {
            //Holds the information of the first touch
            Touch touch = Input.GetTouch(0);

            //Brianna will explain this
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane + 7f));

            //Sets the transform position of the gameobject to the position of the touch.
            transform.position = touchPosition;

            //If the touch has started and you can spawn a brick
            if (touch.phase == TouchPhase.Began)
            {
                //Spawns a brick
                Instantiate(brickSnyder, transform.position, transform.rotation);

                spawnBrick = false;
            }

            //If the touch ends...
            if (touch.phase == TouchPhase.Ended)
            {
                //...spawnBrick will be set to true.
                spawnBrick = true;
            }
        }
    }
}
