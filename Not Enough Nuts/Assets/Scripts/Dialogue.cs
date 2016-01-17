using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour {

	// Use this for initialization
    bool HappeningRightNow;
    bool DialogueGoing;
    private GameObject canvas;
    UnityEngine.UI.Text m_message;
    UnityEngine.UI.Text m_name;
    Timer timer;
	void Start () {
        canvas = GameObject.Find("Dialogue");
        HappeningRightNow = false; //change later?
        DialogueGoing = false; ///change later?
        timer = GameObject.Find("Timer").GetComponent<Timer>();
	}
	
	// Update is called once per frame
	void Update () {
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
    /*    if(name = "Squirrel King"){
            canvas.transform.FindChild("DialogueBackground").FindChild("Name").GetComponent<Image>();
        }*/ //switch picture based on character name? 
    }
    public bool IsSomeoneTalking()
    {
        return HappeningRightNow;
    }
}
