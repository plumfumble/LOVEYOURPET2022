using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firescoremanager : MonoBehaviour
{
    [SerializeField]
    public static int score = 0;
    //public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        //scoreText.text = "0";
    }
}
