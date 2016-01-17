using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {
    public float Toll;
    GameObject Telepad1;
    GameObject Telepad2;
    bool Teleport_Ready1;
    bool Teleport_Ready2;
    private Rigidbody2D rigidbody_2d;
    
	// Use this for initialization
	void Start ()
    {
        rigidbody_2d = this.GetComponent<Rigidbody2D>();
        Teleport_Ready1 = false;
        Telepad1 = GameObject.FindGameObjectWithTag("TeleportPad1");
        Telepad2 = GameObject.FindGameObjectWithTag("TeleportPad2");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (Teleport_Ready1 == true)
            {
                Transform Telepad2Trans = Telepad2.GetComponent<Transform>();
                this.transform.position = Telepad2Trans.position;
            }
            else if(Teleport_Ready2 == true)
            {
                Transform Telepad1Trans = Telepad1.GetComponent<Transform>();
                this.transform.position = Telepad1Trans.position;
            }
        }
	
	}

    void OnTriggerStay2D(Collider2D coll)
    {
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
