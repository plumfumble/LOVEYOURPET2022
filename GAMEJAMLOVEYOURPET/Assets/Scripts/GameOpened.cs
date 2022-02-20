using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOpened : MonoBehaviour
{
    public static GameOpened Instance;

    public bool Opened { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null)
        { Instance = this; }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
