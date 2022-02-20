using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DiggingGameController : MonoBehaviour
{

    [SerializeField] GameObject itemPrefab;
    [SerializeField] GameObject trapPrefab;
    [Header("Spawning")]

    [SerializeField] Transform itemSpawnPoint;

    [SerializeField] float timeToSpawn;
    [SerializeField] float minTimeToSpawn;
    [SerializeField] float setTimeToSpawn;
    [SerializeField] List<float> speedUpPoints;
    [SerializeField] List<float> setTimeSpawnPoints;
    [SerializeField] DiggingLivesDisplay livesDisplay;

    [Header("Speed")]

    [SerializeField] float itemSpeed;
    [SerializeField] float itemSpeedCap;
    [SerializeField] List<float> itemSpeedPoints;

    [SerializeField] List<float> setLifetimePoints;

    [Header("Settings")]
    [SerializeField] float setTrapSpawn;
    bool spawnTraps;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gemSound;
    [SerializeField] AudioClip boomSound;

    float duration;
    int speedUpIndex;

    int gems = 0;
    bool endGame;
    int lives = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (duration > setTrapSpawn) spawnTraps = true;

        for (int i = 0; i < speedUpPoints.Count; i++)
        {
            if (duration > speedUpPoints[i]) speedUpIndex = i;
            else
            {
                break;
            }
        }
    }

    void FixedUpdate()
    {
        if (!endGame)
        {
            if (timeToSpawn > 0)
            {
                timeToSpawn -= Time.deltaTime;
            }
            else
            {
                timeToSpawn = setTimeSpawnPoints[speedUpIndex];
                SpawnItem();
            }
            duration += Time.deltaTime;
        }
    }

    void SpawnItem()
    {
        GameObject go;
        DigItem di;
        if (spawnTraps)
        {
            if (Random.value > 0.3f)
            {
                go = Instantiate(itemPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))), this.transform);
                di = go.GetComponent<DigItem>();
                di.SetStats(itemSpeedPoints[speedUpIndex], setLifetimePoints[speedUpIndex]);
                di.OnMissed += LoseLife;
                di.OnClick += AddValue;
            }
            else
            {
                go = Instantiate(trapPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))), this.transform);
                di = go.GetComponent<DigItem>();
                di.SetStats(itemSpeedPoints[speedUpIndex], setLifetimePoints[speedUpIndex]);
                di.OnClick += ClickBomb;
            }
        }
        else
        {
            go = Instantiate(itemPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180))), this.transform);
            di = go.GetComponent<DigItem>();
            di.SetStats(itemSpeedPoints[speedUpIndex], setLifetimePoints[speedUpIndex]);
            di.OnMissed += LoseLife;
            di.OnClick += AddValue;
        }
        
    }

    void AddValue()
    {
        audioSource.PlayOneShot(gemSound);
        gems++;
    }

    void ClickBomb()
    {
        audioSource.PlayOneShot(boomSound);
        LoseLife();
    }
    void LoseLife()
    {
        Debug.Log("??");
        lives--;
        livesDisplay.UpdateLives(lives);
        if (lives <= 0)
        {
            List<DigItem> gos = FindObjectsOfType<DigItem>().ToList();
            foreach (DigItem di in gos)
            {
                Destroy(di.gameObject);
            }
            //Debug.Log("Time Lasted: " + duration + "/ Gems Gained: " + gems);
            endGame = true;
            StartCoroutine(ReturnHome(1.5f));
            PetSave.pet.money += gems;
            //Debug.Log("You Lose!");
            
        }
    }

    IEnumerator ReturnHome(float duration)
    {
        yield return new WaitForSeconds(duration);
        Debug.Log("worjing! :)");
        SceneManager.LoadScene("Main Menu");
    }
}
