using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwimmingPlayerControl : MonoBehaviour
{
    [SerializeField] Transform[] lanePositons;
    [SerializeField] List<float> speedUpPoints;
    [SerializeField] List<float> setSpeedPoints;

    int currentLane;

    float duration;
    int index;

    void Start()
    {
        currentLane = 1;
    }

    void Update()
    {

        for (int i = 0; i < speedUpPoints.Count; i++)
        {
            if (duration > speedUpPoints[i])
            {
                index = i;
            }
            else
            {
                break;
            }
        }

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

    void FixedUpdate()
    {
        duration += Time.deltaTime;
    }
    
    void UpdateLane()
    {
        transform.DOMove(lanePositons[currentLane].position, setSpeedPoints[index]);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("You Lose!!");
        }
    }
}
