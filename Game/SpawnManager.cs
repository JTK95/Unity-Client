using System.Collections;
using System.Collections.Generic;
using Client;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
	public GameCanvas gameCanvas;
	public GameObject playerPrefab;
	public GameObject mainCameraPrefab;

	Transform[] spawnPoints;
	
	void Start()
	{
		// spawn 자식 수 만큼 할당
		spawnPoints = new Transform[transform.childCount];
		for(int i=0; i<spawnPoints.Length; ++i)
		{
			spawnPoints[i] = transform.GetChild(i);
		}

		this.Spawn();
	}

	void Spawn()
	{
		int randIndex = Random.Range(0, spawnPoints.Length);
		var player = Instantiate(playerPrefab, spawnPoints[randIndex].position, new Quaternion(0, 0, 0, 0)).GetComponent<PlayerHealth>();
		player.HpSlider = gameCanvas.hpBar;
		Instantiate(mainCameraPrefab, new Vector3(spawnPoints[randIndex].position.x - 7, 12.33f, spawnPoints[randIndex].position.z), Quaternion.Euler(58.85f, 75.54401f, -1.472f));
	}
}
