using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    GameObject myGameObject = new GameObject("Test Object"); 
    Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>();

    public GameObject platform;
    public float speedRight;
    public float speedLeft;
    public float speedUp;
    bool jumpcounter = false;
   

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetKeyDown("space") & jumpcounter == false)
        {
            RigidBody2D.AddForce(Vector2.up);
            
           
        }
 
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector2.right * speedRight * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector2.left * speedLeft * Time.deltaTime;
        }
    }
    void LateUpdate()
     {
         jumpcounter = false;
     }
	
}
