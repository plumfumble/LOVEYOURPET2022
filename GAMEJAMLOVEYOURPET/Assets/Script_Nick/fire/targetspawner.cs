using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetspawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    public float launchrate = 1f;
    float speed = 3;
    float i;
    public float height;


    // Update is called once per frame
    void Update()
    {
        if (time > queueTime)
        {
            queueTime = Random.Range(launchrate/2, launchrate*2);
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

            time = 0;
            i = Time.deltaTime * 10f;
            speed = speed + i;
            go.GetComponent<target>().addspeed(speed);
            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}
