using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Squirrel").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
