using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaOfInfluence : MonoBehaviour {

    GameManager GM;

    public Color baseColor;
    public Color curColor;

    List<platform> platforms = new List<platform>();
    List<character> linkedCharacters = new List<character>();

	// Use this for initialization
	void Start () {

        GM = GameManager.Instance;

        //baseColor = GetComponentInParent<character>().baseColor;
        //curColor = baseColor;

        //<SpriteRenderer>().color = curColor;
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

            platforms.Add(colliderInfo.GetComponentInParent<platform>());
        }

        if (colliderInfo.GetComponent<Collider>().tag == "AreaTrigger")
        {
            Ray ray = new Ray(transform.position, colliderInfo.transform.position - transform.position);
            float distance = Vector3.Distance(transform.position, colliderInfo.transform.position);
            if (Physics.Raycast(ray, Vector3.Distance(transform.position, colliderInfo.transform.position)))
            {
                //Combine colors
                GM.characters.Add(GetComponentInParent<character>());
                GM.colors.Add(curColor);
                GM.updateCharacters();
                GM.addToGroup(GetComponentInParent<character>());
            }
            //Combine colors
            linkedCharacters.Add(colliderInfo.GetComponent<character>());
            if (!GM.characters.Contains(GetComponentInParent<character>()))
            {
                print(baseColor);
                GM.characters.Add(GetComponentInParent<character>());
                GM.colors.Add(baseColor);
                GM.updateCharacters();
            }
            
            //GM.addToGroup(GetComponentInParent<character>());
        }

    }

    void OnTriggerStay(Collider colliderInfo)
    {
        if (colliderInfo.GetComponent<Collider>().tag == "Platform")
        {
            //print(gameObject.name + " and " + colliderInfo.GetComponent<Collider>().name + " are still colliding");
        }

    }

    void OnTriggerExit(Collider colliderInfo)
    {
        if (colliderInfo.GetComponent<Collider>().tag == "PlatformTrigger")
        {
            print(gameObject.name + " and " + colliderInfo.GetComponent<Collider>().name + " are no longer colliding");
            colliderInfo.GetComponentInParent<platform>().deactivatePlatform();
            platforms.Remove(colliderInfo.GetComponentInParent<platform>());

            //curPlatform = null;
        }

        if (colliderInfo.GetComponent<Collider>().tag == "AreaTrigger")
        {
            print("Break link");
            
            linkedCharacters.Remove(colliderInfo.GetComponent<character>());

            if (linkedCharacters.Count == 0)
            {
                print("Remove from group");
                GM.removeFromGroup(GetComponentInParent<character>());
                
            }
            //GM.characters.Remove(GetComponentInParent<character>());
            //GM.colors.Remove(curColor);
            //GM.updateCharacters();
            //GM.addToGroup(GetComponentInParent<character>());
        }
    }

    public void changeColor(Color newColor)
    {
        if (!newColor.Equals(curColor))
        {
            //print("list");
            curColor = newColor;
            GetComponent<SpriteRenderer>().color = curColor;

            foreach (var platform in platforms)
            {
                platform.activatePlatform(curColor);
            }
        }
    }
}
