using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nutCount = 0;
    private int nutGoal = 5;

    private Transform bulletSpawn;
    private Object bulletPrefab;
    private Rigidbody2D rigidbody_2d;


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


    public void ShootNuts()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletSpawn.position;

        if (bullet.transform.position.x > this.transform.position.x)
        {
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.AddForce(new Vector2(1000, 120));
        }
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
