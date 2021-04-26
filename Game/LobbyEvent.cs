using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyEvent : MonoBehaviour {

	public static LobbyEvent current;

	public GameObject connectRoomFail;

	void Awake()
	{
		if (current == null)
		{
			current = this;
		}
	}

	void Start () {
		connectRoomFail.SetActive(false);
	}
	
	public void ConnectRoomFail()
    {
		connectRoomFail.SetActive(true);
    }
}
