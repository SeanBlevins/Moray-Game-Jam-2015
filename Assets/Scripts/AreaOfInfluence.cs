using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AreaOfInfluence : MonoBehaviour {

    GameManager GM;

    public Color baseColor;
    public Color curColor;

    List<platform> platforms = new List<platform>();
    public List<character> linkedCharacters = new List<character>();
    public LayerMask mask;

	// Use this for initialization
	void Start () {

        GM = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.forward * -0.25f);
        
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
            colliderInfo.transform.parent.GetComponent<platform>().activatePlatform(curColor);

            colliderInfo.transform.parent.GetComponent<platform>().characters.Add(GetComponentInParent<character>());

            colliderInfo.transform.parent.GetComponent<platform>().checkConnections();

            platforms.Add(colliderInfo.transform.parent.GetComponent<platform>());
        }
        

        if (colliderInfo.GetComponent<Collider>().tag == "AreaTrigger")
        {
            
            Collider thisParent = transform.parent.GetComponent<Collider>();
            Collider thatParent = colliderInfo.transform.parent.GetComponent<Collider>();
            character thatChar = colliderInfo.transform.parent.GetComponent<character>();
            
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
                    //Combine colors
                    linkedCharacters.Add(thatChar);
                    if (!GM.characters.Contains(GetComponentInParent<character>()))
                    {
                        //print(baseColor);
                        GM.characters.Add(GetComponentInParent<character>());
                        GM.colors.Add(baseColor);
                        GM.updateCharacters();
                    }
                }
                else
                {
                    //print(hit.collider.tag);
                }
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
            character thatChar = colliderInfo.transform.parent.GetComponent<character>();

            linkedCharacters.Remove(thatChar);
            //LineRenderer colorLine = transform.parent.GetComponent<LineRenderer>();
            //colorLine.enabled = false;

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
    }
}
