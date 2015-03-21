using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaOfInfluence : MonoBehaviour {

    GameManager GM;

    public Color baseColor;
    public Color curColor;

    public List<platform> platforms = new List<platform>();
    public List<character> linkedCharacters = new List<character>();

	// Use this for initialization
	void Start () {

        GM = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void initColor(Color initColor)
    {
        baseColor = initColor;
        curColor = baseColor;

        GetComponent<SpriteRenderer>().color = curColor;
    }

    void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.GetComponent<Collider>().tag == "PlatformTrigger")
        {
            colliderInfo.GetComponentInParent<platform>().activatePlatform(curColor);            

            colliderInfo.GetComponentInParent<platform>().characters.Add(GetComponentInParent<character>());

            colliderInfo.GetComponentInParent<platform>().checkConnections();

            platforms.Add(colliderInfo.GetComponentInParent<platform>());
        }

        if (colliderInfo.GetComponent<Collider>().tag == "AreaTrigger")
        {
            //Combine colors
            linkedCharacters.Add(colliderInfo.GetComponent<character>());
            if (!GM.characters.Contains(GetComponentInParent<character>()))
            {
                GM.characters.Add(GetComponentInParent<character>());
                GM.colors.Add(baseColor);
                GM.updateCharacters();
            }
        }

    }

    void OnTriggerExit(Collider colliderInfo)
    {
        if (colliderInfo.GetComponent<Collider>().tag == "PlatformTrigger")
        {
            colliderInfo.GetComponentInParent<platform>().characters.Remove(GetComponentInParent<character>());

            colliderInfo.GetComponentInParent<platform>().checkConnections();

            platforms.Remove(colliderInfo.GetComponentInParent<platform>());
        }

        if (colliderInfo.GetComponent<Collider>().tag == "AreaTrigger")
        {
            //print("Break link");
            
            linkedCharacters.Remove(colliderInfo.GetComponent<character>());

            if (linkedCharacters.Count == 0)
            {
                GM.removeFromGroup(GetComponentInParent<character>());
                
            }
        }
    }

    public void changeColor(Color newColor)
    {       
        
        if (!newColor.Equals(curColor))
        {            
            curColor = newColor;
            GetComponent<SpriteRenderer>().color = curColor;

            foreach (var platform in platforms)
            {
                //platform.activatePlatform(curColor);
                platform.checkConnections();
            }
        }
        //print(" ");
    }
}
