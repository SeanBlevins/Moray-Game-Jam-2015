using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


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

    public static Dictionary<activateColorEnum, Color> dictionaryColour = new Dictionary<activateColorEnum, Color>
    {
        {activateColorEnum.RED, Color.red},
        {activateColorEnum.BLUE, Color.blue},
        {activateColorEnum.YELLOW, Color.yellow},
        {activateColorEnum.PURPLE, new Color(0.7f, 0f, 1f, 1f)},
        {activateColorEnum.ORANGE, new Color(1f, 0.65f, 0f, 1f)},
        {activateColorEnum.GREEN, Color.green},
        {activateColorEnum.WHITE, Color.white}
    };

    public bool active = false;    
    public Color activateColor;

    public activateColorEnum activateColorEn;

    public List<character> characters = new List<character>();

	// Use this for initialization
	void Start ()
	{
        GetComponent<Renderer>().material.color = dictionaryColour[activateColorEn];
        deactivatePlatform();
	}
	
	// Update is called once per frame
	void Update () {
        
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
