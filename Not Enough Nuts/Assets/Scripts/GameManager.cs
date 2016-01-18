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

    public AudioSource Hitmark;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        GameObject canvas = GameObject.Find("HUD");
        carriedNutsGUI = canvas.transform.FindChild("GoalBG").FindChild("Carrying").GetComponent<Text>();
        goalGUI = canvas.transform.FindChild("GoalBG").FindChild("Goal").GetComponent<Text>();
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        level = 1;
        goal = 2;
        turnedIn = 0;

	}
	
	// Update is called once per frame
	void Update () {
        carriedNutsGUI.text = player.GetNutCount().ToString();
        goalGUI.text = turnedIn.ToString() + "/" + goal.ToString();
        goalCheck();

	}
    public void TurnInNut()
    {
        Hitmark.Play();
        turnedIn++;
    }
    private string KingSays()
    {
        string[] phrases = { "NUTS FOR THE NUT GOD", "THAT'S A LOT OF NUTS... but not enough", "MORE!!!!!!!!!!!!!!1" };
        int i = UnityEngine.Random.Range(0, phrases.Length);
        return phrases[i];
    }
    private void goalCheck()
    {
        int goalBefore;
        if (turnedIn >= goal)
        {
            dialogue.activate("Squirrel King", KingSays());
            level++;
            goalBefore = goal;
            goal = goal * 2;
            timer.timeLeft += (10.0 * (goal - goalBefore)); //(adds 10 seconds per additonal nut asked for) 

            
            //add in thing later that will display message w/ GUI overlay and talk sprite
        }

    }
    
}
