using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingBackground : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform setPosition;
    [SerializeField] List<Transform> swimmingBackground;

    public float speed = 10;
    private void Update()
    {
        foreach(Transform t in swimmingBackground)
        {
            if (t.position.y < player.position.y && !t.GetComponent<SpriteRenderer>().isVisible)
            {
                t.position = setPosition.position;
            }
        }
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
