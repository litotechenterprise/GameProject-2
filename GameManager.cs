using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int Lives = 3;

    public Text NumLives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NumLives.text = "Lives: " + Lives.ToString();
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Lives > 0)
            {
                Lives = Lives - 1;
                collision.gameObject.transform.position = transform.Find("respond").position;
                NumLives.text = "Lives: " + Lives.ToString();
            }
            else
            {
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }
}
