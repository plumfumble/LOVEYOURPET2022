using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TourneyManager : MonoBehaviour
{
    public int tourneypoints;
    public static int loadthis;
    void Start()
    {
        loadthis = Random.Range(0, 3);
        tourneypoints =0;
        if (loadthis == 0) 
        {
            SceneManager.LoadScene("FireScene");
        }
        if (loadthis == 1)
        {
            SceneManager.LoadScene("Swimming Scene");
        }
        if (loadthis == 2)
        {
            SceneManager.LoadScene("flappyfriend");
        }
        if (loadthis == 3)
        {
            SceneManager.LoadScene("beansgame");
        }
        
    }
    
}
