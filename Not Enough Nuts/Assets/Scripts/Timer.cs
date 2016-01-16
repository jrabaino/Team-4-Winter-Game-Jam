using UnityEngine;
using System.Collections;
using UnityEngine.UI;
<<<<<<< HEAD
//using UnityEngine.SceneManagement;
=======
>>>>>>> origin/master
//using Math;
public class Timer : MonoBehaviour
{
    public double startTime = 9.0;
    public double timeLeft = 0.0;
    public Text timer;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine (countdown ());
        timeLeft = startTime;



    }
    // Update is called once per frame
    void Update()
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
<<<<<<< HEAD
      //          SceneManager.LoadScene("GameOver");
=======
                Application.LoadLevel("GameOver");
>>>>>>> origin/master
                timeLeft = 0.0;
        }



    }
}
