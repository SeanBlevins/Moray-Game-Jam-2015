using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject a;
	public int levelIndex;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Player1Start") == 1.0f || Input.GetAxis("Player2Start") == 1.0f || Input.GetAxis("Player3Start") == 1.0f )
		{
			Application.LoadLevel(levelIndex);
		}
	}
}
