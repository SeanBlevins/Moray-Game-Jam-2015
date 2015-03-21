using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class platform : MonoBehaviour {

    public enum activateColorEnum
    {
        RED = 1,
        BLUE,
        YELLOW,
        PURPLE,
        ORANGE,
        GREEN,
        WHITE
    }

    public bool active = false;    
    public Color activateColor;

    public activateColorEnum activateColorEn;

    public List<character> characters = new List<character>();

	// Use this for initialization
	void Start () {

        switch (activateColorEn)
        {
            case activateColorEnum.RED:
                activateColor = Color.red;
                break;
            case activateColorEnum.BLUE:
                activateColor = Color.blue;
                break;
            case activateColorEnum.YELLOW:
                activateColor = Color.yellow;
                break;
            case activateColorEnum.PURPLE:
                activateColor = new Color(0.7f, 0f, 1f, 1f);
                break;
            case activateColorEnum.ORANGE:
                activateColor = new Color(1f, 0.65f, 0f, 1f);
                break;
            case activateColorEnum.GREEN:
                activateColor = Color.green;
                break;
            case activateColorEnum.WHITE:
                activateColor = Color.white;
                break;
            default:
                break;
        }

        GetComponent<Renderer>().material.color = activateColor;
        deactivatePlatform();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            
        }
        else
        {

        }
	
	}

    public void activatePlatform(Color col)
    {
        
        if (col.Equals(activateColor))
        {
            //print("ACTIVATE: " + col);
            active = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Renderer>().material.color = activateColor;
            
            
        }
        else
        {
            //print("DEACTIVATE: " + col);
            active = false;
            GetComponent<BoxCollider>().enabled = false;
            Color trans = new Color();
            trans = GetComponent<Renderer>().material.color;
            trans.a = 0.25f;

            GetComponent<Renderer>().material.color = trans;
        }
    }

    public void deactivatePlatform()
    {       
        active = false;
        GetComponent<BoxCollider>().enabled = false;
        Color trans = new Color();
        trans = GetComponent<Renderer>().material.color;
        trans.a = 0.25f;

        GetComponent<Renderer>().material.color = trans;
    }

    public void checkConnections()
    {
        active = false;
        deactivatePlatform();
        foreach (var character in characters)
        {
            //print(character);
            if (character.curColor == activateColor)
            {
                active = true;
                activatePlatform(character.curColor);
                break;
            }
        }
    }
}
