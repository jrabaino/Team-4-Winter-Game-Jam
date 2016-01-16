using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nutCount = 0;
    private int nutGoal = 5;
    private Transform bulletSpawn;
    private Object bulletPrefab;
    private Rigidbody2D rigidbody_2d;
    private int jumpcounter = 0;

    public float jump;
    public float moveright;
    public float moveleft;


	// Use this for initialization
	void Start () 
    {
        bulletSpawn = this.transform.FindChild("BulletSpawn");
        bulletPrefab = Resources.Load("bullet");

        rigidbody_2d = this.GetComponent<Rigidbody2D>();
        

	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKeyDown(KeyCode.E))
        {
            ShootNuts();
        }
        

          
	}
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            rigidbody_2d.AddForce(transform.up * jump);
            jumpcounter++;
            

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody_2d.AddForce(transform.right * moveright);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody_2d.AddForce( - transform.right * moveleft);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Platform")
        {
            jumpcounter = 0;
        }
    }
    
    public void ShootNuts()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletSpawn.position;
    }

    public int GetNutCount()
    {
        return nutCount;
    }

    public int GetNutGoal()
    {
        return nutGoal;
    }







}
