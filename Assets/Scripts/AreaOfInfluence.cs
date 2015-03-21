using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaOfInfluence : MonoBehaviour {

    GameManager GM;

    public Color baseColor;
    public Color curColor;

    List<platform> platforms = new List<platform>();
    List<character> linkedCharacters = new List<character>();
    public LayerMask mask;

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
            
            Collider thisParent = transform.parent.GetComponent<Collider>();
            Collider thatParent = colliderInfo.transform.parent.GetComponent<Collider>();
            
            Ray ray = new Ray(thisParent.transform.position,
                thatParent.transform.position - thisParent.transform.position);
            float distance = Vector3.Distance(thisParent.transform.position, thatParent.transform.position);
            Debug.DrawRay(ray.origin, ray.direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                //Combine colors
                if (hit.collider.tag == "Player")
                {
                    GM.characters.Add(GetComponentInParent<character>());
                    GM.colors.Add(curColor);
                    GM.updateCharacters();
                    GM.addToGroup(GetComponentInParent<character>());

                    //Combine colors
                    linkedCharacters.Add(colliderInfo.GetComponent<character>());
                    if (!GM.characters.Contains(GetComponentInParent<character>()))
                    {
                        print(baseColor);
                        GM.characters.Add(GetComponentInParent<character>());
                        GM.colors.Add(baseColor);
                        GM.updateCharacters();
                    }
                }
            }

            //GM.addToGroup(GetComponentInParent<character>());
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
