using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    enum PlayerState { Normal, Climbing };

    PlayerState state = PlayerState.Normal;

    private int nutCount = 0;
    private int nutGoal = 0;
    private Transform bulletSpawn;
    private Object bulletPrefab;
    private Rigidbody2D rigidbody_2d;
    private int jumpcounter = 0;
    private bool treeTrigger = false;

    public float jump;
    public float moveright;
    public float moveleft;


    private Animator animator;
    private int AnimationState;

    private int direction = 4;

    private int idle = 0;
    private int right = 3;
    private int left = 4;

    private int jumpState = 0;

    public Camera mainCamera;


	// Use this for initialization
	void Start () 
    {
        bulletSpawn = this.transform.FindChild("BulletSpawn");
        bulletPrefab = Resources.Load("BulletNut");

        rigidbody_2d = this.GetComponent<Rigidbody2D>();
        

        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	
	    
    void Update()
    {
        
            
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (nutCount != 0)
            {
                ShootNuts();
                nutCount--;
            }
        }


        
            if (Input.GetKeyDown("space") && jumpcounter < 2)
            {
                animator.SetInteger("AnimationState", 1);
                jumpcounter += 1;
                rigidbody_2d.AddForce(transform.up * jump);

                jumpState = 1;

            }
        
        else if (state == PlayerState.Climbing)
        {
            if (Input.GetKeyDown("space"))
            {
                
               rigidbody_2d.AddForce(transform.up * jump * 3/4);


            }
        }
        if  (Input.GetKey(KeyCode.D))
            {
                animator.SetInteger("AnimationState", 2);
                rigidbody_2d.AddForce(transform.right * moveright);

                if (direction != right)
                {
                    direction = right;
                    Vector3 theScale = this.transform.localScale;
                    theScale.x *= -1;
                    this.transform.localScale = theScale;
                }
            }
        if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("AnimationState", 2);
                rigidbody_2d.AddForce(-transform.right * moveleft);

                if (direction != left)
                {
                    direction = left;
                    Vector3 theScale = this.transform.localScale;
                    theScale.x *= -1;
                    this.transform.localScale = theScale;
                }
            }
        if (jumpState == 0)
            {
                animator.SetInteger("AnimationState", 0);
            }

            Vector3 playerInfo = this.transform.transform.position;
            mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - 10);
        
            
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
<<<<<<< HEAD
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Platform" || coll.gameObject.tag == "Tree" || coll.gameObject.tag == "SquirrelKing" || coll.gameObject.tag == "Wall")
=======
        if (coll.gameObject.tag == "Platform")
>>>>>>> origin/master
        {
            Transform Yposition = coll.gameObject.GetComponent<Transform>();
            if (this.transform.position.y >= Yposition.position.y)
            {
                jumpcounter = 0;
            }

            animator.SetInteger("AnimationState", 0);
            jumpState = 0;
        }

        if (coll.gameObject.tag == "Nut" || coll.gameObject.tag == "bullet")
        {
            Destroy(coll.gameObject);
            nutCount++;
            rigidbody_2d.gravityScale += .10f;
        }
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Tree")
        {
            state = PlayerState.Climbing;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        jumpcounter = 2;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        state = PlayerState.Normal;
        jumpcounter = 0;
    }
    
    
    
   public void ShootNuts()
    {
        this.transform.gameObject.tag = "NotPlayer";
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletSpawn.position;

        if (bullet.transform.position.x > this.transform.position.x)
        {
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(new Vector2(1000, 120));
        }
        else
        {
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(new Vector2(-1000, 120));
        }
<<<<<<< HEAD
        this.transform.gameObject.tag = "Player";
=======
        rigidbody_2d.gravityScale -= .10f;
>>>>>>> origin/master
    }

    public void climbTree()
    {
        state = PlayerState.Climbing;

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
