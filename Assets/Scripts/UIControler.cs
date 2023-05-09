using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControler : MonoBehaviour
{
    // Start is called before the first frame update
    private bool started = false;
    private ControlPlayer ControlPlayer;

    public Slider SlinderVida;
    public GameObject GameOverPanel;
    public GameObject StartPanel;

    public Text TextTime;
    public Text TextScore;


    void Start()
    {
        if (!started)
        {
            Time.timeScale = 0;
            StartPanel.SetActive(true);
        }
        else
        {
            StartGame();
        }
    }

    // Update is called once per frame 
    public void AtualizarSliderVida()
    {
        SlinderVida.value = ControlPlayer.status.Vida;
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;

        int minutes = (int)Time.timeSinceLevelLoad / 60;
        int seconds = (int)Time.timeSinceLevelLoad % 60;
        int hour = (int)minutes / 60;
        //TextTime.text = $"Time: {hour}:{minutes}:{seconds}";
        if(seconds < 10) {
            TextTime.text = $"Time: " + hour + ":" + minutes + ":0" + seconds;
        } else
        {
            TextTime.text = $"Time: " + hour + ":" + minutes + ":" + seconds;
        }
        TextScore.text = $"Score: {ControlPlayer.status.Score}";

        Debug.Log($"Time: {hour}:{minutes}:{seconds}");
        
    }
    public void Restart() 
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        started = true;
        StartPanel.SetActive(false);
        ControlPlayer = GameObject.FindWithTag("Player").GetComponent<ControlPlayer>();
        SlinderVida.maxValue = ControlPlayer.status.Vida;
        SlinderVida.value = ControlPlayer.status.Vida;
        Time.timeScale = 1;
    }
}
