using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapUser : MonoBehaviour 
{
	public System.UInt16 UID { get; set; }

	public void Move(float xpos, float zpos)
    {
		gameObject.transform.position = new Vector3(xpos, 65.718f, zpos);
    }

	public void DeleteCharacter()
	{
		Destroy(gameObject);
	}
}