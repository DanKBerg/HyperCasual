using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickSnyder;
    public Camera cam;
    public int brickCount;
    public Text brickSnyderCounter;
    public Text finalCounter;
    public Image brickImage;
    public Image loseMenu;
    
    private bool spawnBrick = true;
    private GameObject gameMaster;
    private GameMaster GM;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        gameMaster = GameObject.Find("GameMaster");
        GM = gameMaster.GetComponent<GameMaster>();
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
            if (touch.phase == TouchPhase.Began && brickCount > 0 && (GM.win == false && gameEnded == false))
            {
                //Spawns a brick
                Instantiate(brickSnyder, transform.position, transform.rotation);

                FindObjectOfType<AudioManager>().Play("Fling");

                spawnBrick = false;
                brickCount -= 1;
                Debug.Log(brickCount);
            }
        }

        if(brickCount == 0 && GM.win == false)
        {
            Debug.Log("You Lose!");
            gameEnded = true;
        }

        if (GM.win == true || gameEnded == true)
        {
            brickSnyderCounter.gameObject.SetActive(false);
            brickImage.gameObject.SetActive(false);
        }

        brickSnyderCounter.text = brickCount.ToString();
        finalCounter.text = brickCount.ToString();

        if(GM.win == false && gameEnded == true)
        {
            loseMenu.gameObject.SetActive(true);
        }
        else
        {
            loseMenu.gameObject.SetActive(false);
        }
    }
}
