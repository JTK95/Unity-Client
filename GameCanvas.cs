using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    public static GameCanvas instance;
    public GameObject canvasPrefab;
    private UICanvas canvas;

    public UICanvas UICanvas { get { return canvas; } }
    public Slider hpBar { get { return canvas.hpBar; } }
    public GameObject gameOver { get { return canvas.gameOver; } }

    void Awake()
    {
        instance = this;
        canvas   = Instantiate(canvasPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0)).GetComponent<UICanvas>();
    }
}
