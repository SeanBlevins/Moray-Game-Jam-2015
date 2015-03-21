using UnityEngine;
using System.Collections;

public class platform : MonoBehaviour {


    bool active = false;    
    public Color activateColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (active)
        {
            
            GetComponent<Renderer>().material.color = Color.white;            
        }
        else
        {
            GetComponent<Renderer>().material.color = activateColor;            
        }
	
	}

    public void activatePlatform(Color col)
    {
        if (col.Equals(activateColor))
        {            
            active = true;
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            active = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void deactivatePlatform()
    {       
        active = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
