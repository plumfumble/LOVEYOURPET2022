using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwimmingPlayerControl : MonoBehaviour
{
    [SerializeField] Transform[] lanePositons;
    int currentLane;

    void Start()
    {
        currentLane = 1;
    }

    void Update()
    {
        int prevLane = currentLane;
        // Left Click
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentLane > 0)
            {
                currentLane--;
            }
        }

        // Right Click
        if (Input.GetButtonDown("Fire2"))
        {
            if (currentLane < 2)
            {
                currentLane++;
            }
        }

        if (prevLane != currentLane)
        {
            UpdateLane();
        }
    }
    
    void UpdateLane()
    {
        transform.DOMove(lanePositons[currentLane].position, 0.5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You Lose!!");
        }
    }
}
