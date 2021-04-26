using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegisterEvent : MonoBehaviour
{
	public static RegisterEvent current;

	public GameObject registerFail;

	void Awake()
    {
		if(current == null)
        {
			current = this;
        }
    }

	void Start () 
	{
		registerFail.SetActive(false);
	}

	public void RegisterFail()
    {
        Debug.Log("안들어옴");
		registerFail.SetActive(true);
	}
}
