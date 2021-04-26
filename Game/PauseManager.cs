using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseManager : MonoBehaviour
{
    Canvas canvas;

	void Awake ()
    {
        canvas = GetComponent<Canvas>();
	}
	
	public void Pause ()
    {
        canvas.enabled = !canvas.enabled;
        if(canvas.enabled)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
}
