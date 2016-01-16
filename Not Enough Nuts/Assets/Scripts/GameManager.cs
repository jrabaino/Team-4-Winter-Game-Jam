using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

    private Player player;
    private int goal;
    private int turnedIn;
    private Text carriedNutsGUI;
    private Text goalGUI;
    

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        GameObject canvas = GameObject.Find("HUD");
        carriedNutsGUI = canvas.transform.FindChild("GoalBG").FindChild("Carrying").GetComponent<Text>();
        goalGUI = canvas.transform.FindChild("GoalBG").FindChild("Goal").GetComponent<Text>();

        goal = 10;
        turnedIn = 0;

	}
	
	// Update is called once per frame
	void Update () {
        carriedNutsGUI.text = player.GetNutCount().ToString();
        goalGUI.text = turnedIn.ToString() + "/" + goal.ToString();

	}
}
