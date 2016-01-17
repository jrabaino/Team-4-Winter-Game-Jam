using UnityEngine;
using System.Collections;

public class SquirrelKing : MonoBehaviour {
    private GameManager gameManager;
    private int nutsStored;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       // gameManager
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            gameManager.TurnInNut();
        }
    }
}
