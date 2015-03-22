using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{

    public platform.activateColorEnum colour;
    private List<character> nearbyPlayers;
    public Transform Exit;

    private Animator animator;

	// Use this for initialization
	void Start ()
	{
//	    animator = transform.parent.GetComponent<Animator>();
	    nearbyPlayers = new List<character>();
	}
	
	// Update is called once per frame
    private void Update()
    {
        Color tempColour = platform.dictionaryColour[colour];
        List<character> results = nearbyPlayers.FindAll(item => item.curColor == tempColour);
        if (GameManager.Instance.characters.Count != 0 && results.Count == 1)
        {
            results = GameManager.Instance.characters;
        }
        foreach (character player in results)
        {
            if (Input.GetButtonDown("Player" + player.PlayerNum + "Y"))
            {
                ActivateDoor(results);

            }
        }
    }

    private void ActivateDoor(List<character> results)
    {
        print("Door ACTIVATES");
        //animate door
        //animator.SetTrigger("Open");
        foreach (character player in results)
        {
            player.transform.position = Exit.position;
        }
    }
    /*
    IEnumerator RevertCollision(Collider player)
    {
        yield return new WaitForSeconds(1.5f);
        Physics.IgnoreCollision(player, transform.parent.GetComponent<Collider>(), false);
    }
    */
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
