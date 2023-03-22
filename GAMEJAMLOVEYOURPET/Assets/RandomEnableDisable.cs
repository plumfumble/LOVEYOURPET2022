using UnityEngine;

public class RandomEnableDisable : MonoBehaviour
{
    public GameObject[] objects; // Array of gameplay objects to enable or disable

    void Start()
    {
        foreach (GameObject obj in objects)
        {
            // Generate a random number from 0 to 15
            int randomNum = Random.Range(0, 10);

            // If the random number is even, enable the object
            if (randomNum == 1)
            {
                obj.SetActive(true);
            }
            // Otherwise, disable the object
            else
            {
                obj.SetActive(false);
            }
        }
    }
}