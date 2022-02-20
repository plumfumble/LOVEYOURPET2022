using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwimmingPlayerControl : MonoBehaviour
{
    [SerializeField] Transform[] lanePositons;
    [SerializeField] List<float> speedUpPoints;
    [SerializeField] List<float> setSpeedPoints;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip changeLaneSound;
    [SerializeField] AudioClip crashSound;

    int currentLane;

    float duration;
    int index;

    bool ending;

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
        audioSource.PlayOneShot(changeLaneSound);
        transform.DOMove(lanePositons[currentLane].position, setSpeedPoints[index]);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ending)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                //Debug.Log("Time Lasted: " + duration + "/ Experience Gained: " + (int)duration / 5);
                audioSource.PlayOneShot(crashSound);
                PetSave.pet.surfstat += (int)duration / 5;
                ending = true;
                //Debug.Log("You Lose!!");
            }
        }
        
    }
}
