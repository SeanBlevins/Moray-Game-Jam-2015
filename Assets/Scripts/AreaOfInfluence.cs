using UnityEngine;
using System.Collections;

public class AreaOfInfluence : MonoBehaviour {

    GameManager GM;

    Color baseColor;
    Color curColor;
    platform curPlatform = null;

    ArrayList platforms = new ArrayList();

	// Use this for initialization
	void Start () {

        GM = GameManager.Instance;

        baseColor = GetComponentInParent<character>().baseColor;
        curColor = baseColor;

        GetComponent<SpriteRenderer>().color = curColor;
	}
	
	// Update is called once per frame
	void Update () {
	
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
            //Combine colors
            GM.characters.Add(GetComponentInParent<character>());
            GM.colors.Add(curColor);
            GM.updateCharacters();
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
            print("Break up");
            GM.removeFromGroup(GetComponentInParent<character>());
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

            foreach (var item in platforms)
            {
                platform platform = (platform)item;
                platform.activatePlatform(curColor);
            }
        }
    }
}
