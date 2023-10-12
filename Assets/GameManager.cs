using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI highText;
    private float score = 0f;
    public float scoreMulti = 1f;
    private bool alive = false;
    private bool playing = false;
    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject player;
    public GameObject explosion;
    private float highScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        alive = playerScript.alive;
        if (Input.GetKeyDown("space"))
        {
            if(!playing)
            {
                playing = true;
                Debug.Log(playing);
                player.SetActive(true);
                playerScript.alive = true;
                menuCanvas.SetActive(false);
                explosion.SetActive(false);
                scoreCanvas.SetActive(true);
            }
        }
        if(playing)
        {
            menuCanvas.SetActive(false);
            scoreCanvas.SetActive(true);

            if(Time.timeScale < 0.9f)
            {
                Time.timeScale += 0.1f * Time.deltaTime;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            menuCanvas.SetActive(true);
            scoreCanvas.SetActive(false);
            Time.timeScale = 0.2f;
        }

        if(alive)
        {
            score += 1 * scoreMulti;
            //Debug.Log(score);
            float displayScore = Mathf.Round(score);
            text.text = "Score: " + displayScore.ToString();

            if(score > highScore){highScore = score;}
            highText.text = "High score: " + Mathf.Round(highScore).ToString();
        }
    }

    public void Death()
    {
        playing = false;
        player.SetActive(false);
        explosion.SetActive(true);
        score = 0f;
    }
}
