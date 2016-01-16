using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    
    public float speedRight;
    public float speedLeft;
    public float speedUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetKeyDown("space") & transform.position.y <= .2 )
        {

            
            transform.position += Vector3.up * speedUp * Time.deltaTime;
        }
 
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speedRight * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speedLeft * Time.deltaTime;
        }
 
         
   
     
	
	}
}
