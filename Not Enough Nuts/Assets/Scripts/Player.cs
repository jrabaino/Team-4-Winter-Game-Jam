using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int nutCount = 0;
    private int nutGoal = 5;

    private Transform bulletSpawn;
    private Object bulletPrefab;


	// Use this for initialization
	void Start () 
    {
        bulletSpawn = this.transform.FindChild("BulletSpawn");
        bulletPrefab = Resources.Load("bullet");
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
