using UnityEngine;
using System.Collections;

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

    bool active = false;    
    public Color activateColor;

    public activateColorEnum activateColorEn;

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

        deactivatePlatform();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void activatePlatform(Color col)
    {
        if (col.Equals(activateColor))
        {            
            active = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Renderer>().material.color = Color.white;
            Color trans = new Color();
            trans = GetComponent<Renderer>().material.color;
            trans.a = 0.25f;
            GetComponent<Renderer>().material.color = trans;
        }
        else
        {
            active = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Renderer>().material.color = activateColor;
        }
    }

    public void deactivatePlatform()
    {       
        active = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Renderer>().material.color = activateColor;
    }
}
