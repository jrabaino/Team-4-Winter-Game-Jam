using UnityEngine;
using System.Collections;

public class SquirrelKing : MonoBehaviour {
    private GameManager gameManager;
    private int nutsStored;

    Animator animator;
    private GameObject Head;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       // gameManager

        Head = GameObject.FindGameObjectWithTag("Head");
        animator = Head.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            Debug.Log("turned in nut!");
            gameManager.TurnInNut();

            animator.SetInteger("AnimationState", 0);
        }
    }
}
