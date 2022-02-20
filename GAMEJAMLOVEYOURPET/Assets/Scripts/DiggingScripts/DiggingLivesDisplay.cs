using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingLivesDisplay : MonoBehaviour
{
    [SerializeField] List<GameObject> lives;

    public void UpdateLives(int remainingLives)
    {
        for (int i = 0; i < lives.Count; i++)
        {
            if (i >= remainingLives)
            {
                lives[i].SetActive(false);
            }
            else
            {
                lives[i].SetActive(true);
            }
        }
    }
}
