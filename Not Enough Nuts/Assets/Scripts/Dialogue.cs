﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour {

	// Use this for initialization
    bool HappeningRightNow;
    bool DialogueGoing;
    private GameObject canvas;
    string[] startDialogue;
    bool debriefing;
    int debriefIndex;
    UnityEngine.UI.Text m_message;
    UnityEngine.UI.Text m_name;
    Timer timer;
	void Start () {
        canvas = GameObject.Find("Dialogue");
        HappeningRightNow = false; //change later?
        DialogueGoing = false; ///change later?
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        debriefing = true;
        debriefIndex = 0;
        startDialogue = new string[5]; //{ "Press Space to advance dialogue", "SUBJECT #4531, ARISE! YOUR TIME HAS COME! THE KINGDOM APPROCHES THE DIRE TIME OF THE GREAT FROST. IT IS YOUR DUTY TO GATHER PROVISIONS FOR MY KINGDOM TO SURVIVE THE HARSH COLD.", "Use WASD to run and climb " + System.Environment.NewLine + "Use Space to jump " + System.Environment.NewLine + "Use E to fling nuts with your tail", };
        startDialogue[0] = "Press Space to advance dialogue";
        startDialogue[1] = "SUBJECT #4531, ARISE! YOUR TIME HAS COME! THE KINGDOM APPROCHES THE DIRE TIME OF THE GREAT FROST. IT IS YOUR DUTY TO GATHER PROVISIONS FOR MY KINGDOM TO SURVIVE THE HARSH COLD.";
        startDialogue[2] = "Use WASD to run and climb " + System.Environment.NewLine + "Use Space to jump " + System.Environment.NewLine + "Use E to fling nuts with your tail";
        startDialogue[3] = "Press T on top of a mole hole to move quickly across the forest";
        startDialogue[4] = "GOOD LUCK SUBJECT 4531. MAY YOU VANQUISH THE BADGER MENACE AND HARVEST PLENTY. YOUR NATION IS COUNTING ON YOU.";   
        activate("Squirrel King", startDialogue[0]);
        debriefIndex++;
	}
	
	// Update is called once per frame
	void Update () {
        if (debriefing && Input.GetKeyDown("space"))
        {
            activate("Squirrel King", startDialogue[debriefIndex]);
            debriefIndex++;
            if (debriefIndex == startDialogue.Length)
            {
                debriefing = false;
            }
        }
        else
        {
            if (!HappeningRightNow)
            {
                canvas.GetComponent<CanvasGroup>().alpha = 0;
                timer.unpause();
            }
            if ((Input.GetKeyDown("space") && DialogueGoing))
            {
                DialogueGoing = false;
                //this is where i'd add something to put the rest of the message up immediately
                //will include another if statement for happening rn that will make the box disappear and game resume when space is pressed again
                HappeningRightNow = false;

            }
        }
	}


    public void activate(string name, string message)
    {
        HappeningRightNow = true;
        DialogueGoing = true;
        timer.pause();
        canvas.GetComponent<CanvasGroup>().alpha = 1;
        m_name = canvas.transform.FindChild("DialogueBackground").FindChild("Name").GetComponent<Text>();
        m_message = canvas.transform.FindChild("DialogueBackground").FindChild("Message").GetComponent<Text>();
        m_name.text = name + ":";
        m_message.text = message; //later change this to be a time/frame dependent thing that will "type out" the message
        //Image head = canvas.transform.FindChild("DialogueBackground").FindChild("Head").GetComponent<Image>();
/*        if(name == "Squirrel King"){
            
        }*/
        //switch picture based on character name? 
    }
    private void multipleStrings(int i)
    {

    }
    public void deactivate()
    {
        DialogueGoing = false;
        HappeningRightNow = false;
    }
    public bool IsSomeoneTalking()
    {
        return HappeningRightNow;
    }
}
