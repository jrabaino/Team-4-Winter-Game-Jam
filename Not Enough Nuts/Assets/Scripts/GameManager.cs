using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System; 
public class GameManager : MonoBehaviour {

    private Player player;
    private int goal;
    private int turnedIn;
    private Text carriedNutsGUI;
    private Text goalGUI;
    private int level;
    private Dialogue dialogue;
    private Timer timer;
    private bool isGameOver;
    private CanvasGroup GameOver;

    public AudioSource Hitmark;
    

	// Use this for initialization

	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        GameObject canvas = GameObject.Find("HUD");
        carriedNutsGUI = canvas.transform.FindChild("GoalBG").FindChild("Carrying").GetComponent<Text>();
        goalGUI = canvas.transform.FindChild("GoalBG").FindChild("Goal").GetComponent<Text>();
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        GameOver = GameObject.Find("Dialogue").transform.FindChild("GAMEOVERSHIT").GetComponent<CanvasGroup>();
        level = 1;
        goal = 2;
        turnedIn = 0;
        isGameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
        carriedNutsGUI.text = player.GetNutCount().ToString();
        goalGUI.text = turnedIn.ToString() + "/" + goal.ToString();
        goalCheck();

        if (timer.timeLeft <= 0.0)
        {
            isGameOver = true;
            GameOver.alpha = 1;
            dialogue.activate("King Nutter", "LET IT BE KNOWN THAT SUBJECT #4135 HAS DISAPPOINTED ME ONCE AGAIN. SHE ONLY GATHERED " + turnedIn.ToString() + " NUTS.");


            if (Input.GetKey(KeyCode.Return))
            {
                Application.LoadLevel("Menu");

                player.setToZero();
            }
        }
	}
    public void TurnInNut()
    {
        Hitmark.Play();
        turnedIn++;
    }
    public int TurnedIn()
    {
        Debug.Log(turnedIn);
        return turnedIn;
    }
    private string KingSays()
    {
        string[] phrases = { "NUTS FOR THE NUT GOD!", "THAT'S A LOT OF NUTS... but not enough!", "MORE!!!!!!!!!!!!!!1", turnedIn.ToString()+ "??? How pathetic.", "Do you really think that is enough to satisfy me, I mean, my kingdom's hunger?", "You... You're joking, right?", "TOOK YOU LONG ENOUGH. NOW GET ME SOME MORE!"};
        int i = UnityEngine.Random.Range(0, phrases.Length);
        return phrases[i];
    }
    private void goalCheck()
    {
        int goalBefore;
        if (turnedIn >= goal)
        {
            dialogue.activate("King Nutter", KingSays());
            level++;
            goalBefore = goal;
            goal = goal * 2;
            if (level < 4)
            {
                timer.timeLeft += (10.0 * (goal - goalBefore)); //(adds 10 seconds per additonal nut asked for) 
            }
            else
            {
                timer.timeLeft = goal * 5.0;
            }
            
            //add in thing later that will display message w/ GUI overlay and talk sprite
        }

    }
    
}
