using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private Player player;

    private Animator animator;
    private int AnimationState;

    private int direction = 4;

    private int idle = 0;
    private int right = 3;
    private int left = 4;

    private Rigidbody2D rigidbody_2d;

    public int steps;
    private int count;

    private bool pursuit = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();

        rigidbody_2d = this.GetComponent<Rigidbody2D>();

        animator = this.GetComponent<Animator>();

        if (steps != 0)
        {
            animator.SetInteger("AnimationState", 2);
        }
        else
        {
            animator.SetInteger("AnimationState", 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!pursuit)
        {
            if (steps != 0)
            {
                //Debug.Log(direction);
                if (direction == right)
                {
                    //Debug.Log("Right");
                    //rigidbody_2d.AddForce(transform.right * 10);
                    transform.Translate(0.05f, 0.0f, 0.0f);

                    count++;

                    if (count > steps)
                    {
                        direction = left;

                        Vector3 theScale = this.transform.localScale;
                        theScale.x *= -1;
                        this.transform.localScale = theScale;
                    }
                }

                else if (direction == left)
                {
                    //Debug.Log("Left");
                    //rigidbody_2d.AddForce(-transform.right * 10);
                    transform.Translate(-0.05f, 0.0f, 0.0f);
                    count--;

                    if (count < 0)
                    {
                        direction = right;

                        Vector3 theScale = this.transform.localScale;
                        theScale.x *= -1;
                        this.transform.localScale = theScale;
                    }
                }
            }
        }


        if ((((player.transform.position.x < transform.position.x) && (transform.position.x - player.transform.position.x < 4 && transform.position.x - player.transform.position.x > 1)) || 
            ((player.transform.position.x > transform.position.x) && (player.transform.position.x - transform.position.x < 4 && player.transform.position.x - transform.position.x > 1))) && 

            (((player.transform.position.y < transform.position.y) && (transform.position.y - player.transform.position.y < 8)) || 
            ((player.transform.position.y > transform.position.y) && (player.transform.position.y - transform.position.y < 8))))
        {

            animator.SetInteger("AnimationState", 1);

            if (player.transform.position.x > transform.position.x)
            {
                if (direction == left)
                {
                    Vector3 theScale = this.transform.localScale;
                    theScale.x *= -1;
                    this.transform.localScale = theScale;
                }
                direction = right;
                transform.Translate(0.05f, 0.0f, 0.0f);
            }
            else
            {
                if (direction == right)
                {
                    Vector3 theScale = this.transform.localScale;
                    theScale.x *= -1;
                    this.transform.localScale = theScale;
                }
                direction = left;
                transform.Translate(-0.05f, 0.0f, 0.0f);
            }
            pursuit = true;
        }
        else
        {
            if (steps != 0)
            {
                animator.SetInteger("AnimationState", 2);
            }
            else
            {
                animator.SetInteger("AnimationState", 0);
            }
            pursuit = false;
        }

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
            player.LoseYourShit();
        }
    }
}
