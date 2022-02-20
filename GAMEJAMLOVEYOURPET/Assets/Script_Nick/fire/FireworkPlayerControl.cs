using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkPlayerControl : MonoBehaviour
{
    public float velocity = 5f;
    readonly Vector3 offset = new Vector3(30000, 3800, 0);
    [SerializeField]
    private Camera mainCamera;
    [SerializeField] GameObject fireworkPrefab;
    public bool mousenotin = false;
    float angle;
    public static int numberOfFireworks;
    private void Start()
    {
        numberOfFireworks = 5;
    }

    void Update()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(mainCamera.ScreenToViewportPoint(Input.mousePosition));
        float stuff = mouseWorldPosition.x - 0.5f;
        float rythym = stuff * 15f;
        float control = rythym - transform.position.x;

        control = Mathf.Clamp(control, -1, 1);
        if (mousenotin == false)
        {
            transform.position = transform.position + new Vector3(control * velocity * Time.deltaTime, 0, 0);
        }
        // Set angle
        //this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y)
        {
            mousenotin = true;
        }
        else
        {
            mousenotin = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Firing");
            if (numberOfFireworks > 0)
            {
                ShootFirework();
            }
        }
    }

    void ShootFirework()
    {
        Instantiate(fireworkPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        numberOfFireworks--;
    }


}
