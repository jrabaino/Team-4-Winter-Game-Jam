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
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        GameObject canvas = GameObject.Find("HUD");
        carriedNutsGUI = canvas.transform.FindChild("GoalBG").FindChild("Carrying").GetComponent<Text>();
        goalGUI = canvas.transform.FindChild("GoalBG").FindChild("Goal").GetComponent<Text>();
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
    }
    private void goalCheck()
    {
        if (turnedIn >= goal)
        {
            level++;
            goal = goal * 2;
            //add in thing later that will display message w/ GUI overlay and talk sprite
        }

    }
}
