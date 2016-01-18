using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
    public AudioSource Title_Song;
	// Use this for initialization
	void Start () {

        Title_Song.Play();
	}
    public void onClick()
    {
        Title_Song.Stop();
        Application.LoadLevel("Level1");
    }
	// Update is called once per frame
	void Update () {
	
	}
}
