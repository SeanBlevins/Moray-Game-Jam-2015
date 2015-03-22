using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    public List<character> nearbyPlayers;

	// Use this for initialization
	void Start () {

        nearbyPlayers = new List<character>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (nearbyPlayers.Find(item => item.curColor == Color.white))
	    {
            print("complete level");
	        GameManager.Instance.CompleteLevel();
	    }
	}

    void OnTriggerEnter(Collider other)
    {
        print("trig enter");
        print(other.tag);
        if (other.tag != "AreaTrigger") return;
        character player = other.transform.parent.GetComponent<character>();
        nearbyPlayers.Add(player);
    }

    void OnTriggerExit(Collider other)
    {
        print("trig exit");
        print(other.tag);
        if (other.tag != "AreaTrigger") return;
        character player = other.transform.parent.GetComponent<character>();
        nearbyPlayers.Remove(player);
    }
}
