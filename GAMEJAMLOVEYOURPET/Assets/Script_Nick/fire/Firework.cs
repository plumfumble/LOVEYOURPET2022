using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.up * speed) * Time.deltaTime);
    }
}
