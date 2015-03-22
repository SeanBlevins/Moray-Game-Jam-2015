using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public enum GameState { wait, rotate, check }
public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null; 
    public event OnStateChangeHandler OnStateChange;
	//public GameState gameState { get; private set; }
    protected GameManager() { }

    public int CurrentLevel;
    public List<character> characters = new List<character>();
    public List<Color> colors = new List<Color>();
    
    Color groupColor;

    private LineRenderer line;

    // Singleton pattern implementation
    public static GameManager Instance
    {
        get
        {
            _instance = Object.FindObjectOfType(typeof(GameManager)) as GameManager;
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	    if (Application.loadedLevel == 0)
	    {
	        DontDestroyOnLoad(gameObject);
	        Application.LoadLevel(1);
	    }
	    if (FindObjectsOfType<GameManager>().Length > 1)
	    {
	        Destroy(gameObject);
	    }

	    CurrentLevel = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    for (int x = 0; x < characters.Count; x++)
	    {
            line.SetPosition(x, characters[x].transform.position);
            line.enabled = true;
	    }

	    if (characters.Count == 3)
	    {
            line.SetPosition(3, characters[0].transform.position);
	    }
	    
	}

    public void addToGroup(character ch)
    {
        //print("Color Mix " + ch);
        characters.Add(ch);
        //print("Color     " + ch.baseColor);
        colors.Add(ch.baseColor);
    
        updateCharacters();
    }

    public void removeFromGroup(character ch)
    {
        characters.Remove(ch);
        colors.Remove(ch.baseColor);
        updateCharacters();

        ch.curColor = ch.baseColor;
        ch.updateColor();
    }

    public void updateCharacters()
    {
        line.SetVertexCount(characters.Count);
        
        if(characters.Count == 3)
        {
            groupColor = Color.white;
            line.SetVertexCount(characters.Count + 1);
            
        }
        else
        {
            if(colors.Contains(Color.red) && colors.Contains(Color.blue))
            {
                //Purple - new Color(0.7f, 0f, 1f, 1f);
                groupColor = new Color(0.7f, 0f, 1f, 1f);
            }
            else if (colors.Contains(Color.red) && colors.Contains(Color.yellow))
            {
                //Orange - new Color(1f, 0.65f, 0f, 1f);
                groupColor = new Color(1f, 0.65f, 0f, 1f);
            }
            else
            {
                //Green
                groupColor = Color.green;
            }

        }

        foreach (var character in characters)
        {            
            character.curColor = groupColor;
            character.updateColor();
        }

        line.SetColors(groupColor, groupColor);
    }

    internal void CompleteLevel()
    {
        if (CurrentLevel == Application.levelCount)
        {
            CurrentLevel = 0;
            Application.LoadLevel(0);
        }
        else
        {
            CurrentLevel++;
            Application.LoadLevel(CurrentLevel);
        }
    }
}
