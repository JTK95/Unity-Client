using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour 
{
    // event
    public static EventManager current;
    public GameCanvas canvas;
    
    public GameObject gameOverText;

    void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    void Start()
    {
        gameOverText.SetActive(false);
    }
    public void GameOver()
	{
        gameOverText.SetActive(true);
    }
}
