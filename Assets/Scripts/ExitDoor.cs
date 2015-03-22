using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    public List<character> nearbyPlayers;
    public LayerMask mask;

	// Use this for initialization
	void Start () {

        nearbyPlayers = new List<character>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (nearbyPlayers.Find(item => item.curColor == Color.white))
	    {
            //print("complete level");
	        //GameManager.Instance.CompleteLevel();
	    }

	    bool allWhite = true;

	    if (nearbyPlayers.Count == 3)
	    {
            foreach (var playa in nearbyPlayers)
	        {
	            if (playa.curColor != Color.white)
	            {
	                allWhite = false;
	                break;
	            }
	        }
	    }
	    else
	    {
	        allWhite = false;
	    }

	    if (allWhite)
	    {
            print("complete level");
            GameManager.Instance.CompleteLevel();
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        print("trig enter");
        print(other.tag);
        if (other.tag != "Player") return;
        character player = other.GetComponent<character>();
        nearbyPlayers.Add(player);
    }

    void OnTriggerExit(Collider other)
    {
        print("trig exit");
        print(other.tag);
        if (other.tag != "Player") return;
        character player = other.GetComponent<character>();
        nearbyPlayers.Remove(player);
    }
}
