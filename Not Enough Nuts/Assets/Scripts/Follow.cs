using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    private Rigidbody2D rigidbody_2d;

    float x = 100.0f;
    float y = 100.0f;

	// Use this for initialization
	void Start () {

        rigidbody_2d = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody_2d.AddForce(new Vector3(x, y, 0.0f));
	}


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            
            x = -x;
            y = -y;
        }
    }
}
