using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public List<GameObject> constructionPieces;
    public Transform heightLimit;
    public Image winMenu;

    public bool win;
    private int constructionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckForHeight());
    }

    // Update is called once per frame
    void Update()
    {
        if(win == true)
        {
            winMenu.gameObject.SetActive(true);
        }
    }

    private IEnumerator CheckForHeight()
    {
        while(win == false)
        {
            yield return new WaitForSeconds(2);
            foreach (var piece in constructionPieces)
            {
                if(piece.transform.position.y > heightLimit.transform.position.y)
                {
                    constructionCount += 1;
                }
            }

            if(constructionCount == 0)
            {
                win = true;
                FindObjectOfType<AudioManager>().Play("Level Complete");
            }

            constructionCount = 0;
        }

        Debug.Log("You Win");
    }
}
