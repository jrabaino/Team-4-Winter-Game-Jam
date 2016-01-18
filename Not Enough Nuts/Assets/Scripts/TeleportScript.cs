using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
    private int Toll;
    GameObject Telepad1;
    GameObject Telepad2;
    bool Teleport_Ready1;
    bool Teleport_Ready2;
    bool moleTalking;
    private Rigidbody2D rigidbody_2d;
    private Dialogue dialogue;
    private Player player;

    public AudioSource MoleSound, TeleporToll;


    GameObject Head;
    Animator animator;

	// Use this for initialization
	void Start ()
    {
        rigidbody_2d = this.GetComponent<Rigidbody2D>();
        Teleport_Ready1 = false;
        Telepad1 = GameObject.FindGameObjectWithTag("TeleportPad1");
        Telepad2 = GameObject.FindGameObjectWithTag("TeleportPad2");
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();
        player = GameObject.Find("Squirrel").GetComponent<Player>();
        moleTalking = false;
        Toll = 5;

        Head = GameObject.FindGameObjectWithTag("Head");
        animator = Head.GetComponent<Animator>();
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!dialogue.IsSomeoneTalking())
        {
            moleTalking = false;
        }
        if ((Input.GetKeyDown(KeyCode.T) && Teleport_Ready1) || (Input.GetKeyDown(KeyCode.T) && Teleport_Ready2))
        {
            Debug.Log("Pressed T");
            moleTalking = true;
            MoleSound.Play();
            dialogue.activate("Mole", "You have to pay the mole toll if you want to use the Mole Hole!" + System.Environment.NewLine + "Pay 5 Nuts And Teleport Y/N?");
            animator.SetInteger("AnimationState", 1);
        }

        if (moleTalking && Input.GetKeyDown(KeyCode.Y))
        {
            if (player.GetNutCount() >= Toll)
            {
                TeleporToll.Play();
                player.PayTheMoleToll(Toll);
                if (Teleport_Ready1 == true)
                {
                    Debug.Log("T1");
                    Transform Telepad2Trans = Telepad2.GetComponent<Transform>();
                    this.transform.position = Telepad2Trans.position;
                    dialogue.deactivate();
                }
                else if (Teleport_Ready2 == true)
                {
                    Debug.Log("T2");
                    Transform Telepad1Trans = Telepad1.GetComponent<Transform>();
                    this.transform.position = Telepad1Trans.position;
                    dialogue.deactivate();

                }
            }
            else
            {
                dialogue.activate("Mole", "Not enough nuts??? How embarrassing...");
            }
        }
        else if (moleTalking && Input.GetKeyDown(KeyCode.N))
        {
            dialogue.deactivate();
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("Is it ready yet");
        if (coll.gameObject.tag == "TeleportPad1")
        {
            Teleport_Ready1 = true;
            

            
        }
        if (coll.gameObject.tag == "TeleportPad2")
        {
            Teleport_Ready2 = true;

        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        Teleport_Ready1 = false;
        Teleport_Ready2 = false;
    }
}
