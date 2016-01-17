using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "SquirrelKing") // coll.gameObject.tag == "Tree") ; //|| coll.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
