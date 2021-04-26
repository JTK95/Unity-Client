using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginEvent : MonoBehaviour {

	public static LoginEvent current;

	public GameObject loginFail;

	void Awake()
    {
		if(current == null)
        {
			current = this;
        }
    }

	void Start () 
	{
		loginFail.SetActive(false);
	}
	
	public void LoginFail()
    {
		loginFail.SetActive(true);
    }
}
