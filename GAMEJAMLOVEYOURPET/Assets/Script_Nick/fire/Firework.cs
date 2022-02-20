using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField] Rigidbody2D body;
    public float speed;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.up * speed) * Time.deltaTime);
    }
}
