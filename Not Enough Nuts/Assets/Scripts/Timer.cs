using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//using UnityEngine.SceneManagement;
//using Math;
public class Timer : MonoBehaviour
{
    public double startTime = 9.0;
    public double timeLeft = 0.0;
    private Text timer;
    private bool paused;
    private Dialogue dialogue;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine (countdown ());
        timeLeft = startTime;
        GameObject canvas = GameObject.Find("HUD");
        timer = canvas.transform.FindChild("TimerBG").FindChild("TimeLeft").GetComponent<Text>();
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        paused = true; 
        



    }
    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            timeLeft -= Time.deltaTime;
            int secondsLeft = (int)timeLeft;
            int minutes = secondsLeft / 60;
            int seconds = secondsLeft % 60;
            string s = seconds.ToString();
            if (seconds < 10)
            {
                s = "0" + s;
            }

            timer.text = minutes.ToString() + ":" + s;

            if (timeLeft <= 0)
            {
                //          SceneManager.LoadScene("GameOver");

                Application.LoadLevel("GameOver");

                timeLeft = 0.0;
            }
        }

    }
    public void pause()
    {
        paused = true;
    }
    public void unpause()
    {
        paused = false;
    }

}
