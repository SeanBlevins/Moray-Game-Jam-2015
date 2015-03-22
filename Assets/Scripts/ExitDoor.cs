using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    private List<character> nearbyPlayers;

	// Use this for initialization
	void Start () {

        nearbyPlayers = new List<character>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (nearbyPlayers.Find(item => item.curColor == Color.white))
	    {
	        GameManager.Instance.CompleteLevel();
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;
        character player = other.GetComponent<character>();
        nearbyPlayers.Add(player);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player") return;
        character player = other.GetComponent<character>();
        nearbyPlayers.Remove(player);
    }
}
