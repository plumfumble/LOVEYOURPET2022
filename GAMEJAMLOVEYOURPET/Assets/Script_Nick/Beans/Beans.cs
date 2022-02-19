using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.down * speed) * Time.deltaTime);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<Renderer>().enabled = false;
    }
}
