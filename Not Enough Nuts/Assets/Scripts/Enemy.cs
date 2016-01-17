using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Player player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Player")
        {
            //player.LoseYourShit();
        }
    }
}
