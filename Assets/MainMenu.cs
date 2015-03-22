using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject a;
	public int levelIndex;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetAxis("Player1Start") > 0f || Input.GetAxis("Player2Start") > 0f || Input.GetAxis("Player3Start") > 0f )
		{
            print("B");
			Application.LoadLevel(levelIndex);
		}
	}
}
