using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shape : MonoBehaviour
    {
        void Start()
        {
            // Set a random color for the shape
            Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow };
            GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        }
    }
