using UnityEngine;
using System.Collections;

public class BackgroundTiling : MonoBehaviour
{
    public Sprite[] SpriteList;
    public GameObject prefabTile;
    public int gridRows;
    public int gridColumns;
    public float width;
    public float height;

	// Use this for initialization
	void Start ()
    {
        SpriteList = Resources.LoadAll<Sprite>("Mona_Lisa");

	    width = height =SpriteList[0].bounds.max.x - SpriteList[0].bounds.min.x;
	    for (int j = 0; j < gridRows; j++)
	    {
	        for (int i = 0; i < gridColumns; i++)
	        {
	            GameObject go = (GameObject) Instantiate(prefabTile, new Vector3(j*width, -i*height), Quaternion.identity);
	            go.GetComponent<SpriteRenderer>().sprite = SpriteList[i*gridRows + j];
	        }
	    }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
