using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameOverDialogue : MonoBehaviour {

    UnityEngine.UI.Text message;
    private GameObject canvas;
    private GameManager manager;


	// Use this for initialization
	void Start () {
        canvas = GameObject.Find("Dialogue2");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        message = canvas.transform.FindChild("DialogueBackground").FindChild("Message").GetComponent<Text>();
        int score = manager.TurnedIn();
        message.text ="LET IT BE KNOWN THAT SUBJECT #4135 HAS DISAPPOINTED ME ONCE AGAIN. SHE ONLY GATHERED " + score.ToString() + " NUTS.";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
