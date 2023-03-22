using System.Collections;
using UnityEngine;

public class EnableDisableGameObjects : MonoBehaviour
{
    public GameObject[] objectsToEnableDisable;
    public float delay = 1f;

    //private void Start()
    //{
    //    StartCoroutine(EnableDisableObjectsWithDelay());
    //}
    private void OnEnable()
    {
        StartCoroutine(EnableDisableObjectsWithDelay());
    }
    private IEnumerator EnableDisableObjectsWithDelay()
    {
        while (true) // infinite loop
        {
            foreach (GameObject obj in objectsToEnableDisable)
            {
                if(obj.activeSelf)
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
                
                yield return new WaitForSeconds(delay);
                
            }
        }
    }
}
