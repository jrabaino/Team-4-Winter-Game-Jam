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

    public AudioSource Turnin;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        GameObject canvas = GameObject.Find("HUD");
        carriedNutsGUI = canvas.transform.FindChild("GoalBG").FindChild("Carrying").GetComponent<Text>();
        goalGUI = canvas.transform.FindChild("GoalBG").FindChild("Goal").GetComponent<Text>();
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
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
        turnedIn++;
        Turnin.Play();
    }
    private void goalCheck()
    {
        if (turnedIn >= goal)
        {
            dialogue.activate("Squirrel King", "NUTS FOR THE NUT GOD!");
            level++;
            goal = goal * 2;
            
            //add in thing later that will display message w/ GUI overlay and talk sprite
        }

    }
}
