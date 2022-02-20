using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Slider[] statsliders; //0 = fire, 1 = plant, 2 = fly, 3 = surf, 4 = exp, 5 = happiness, 6 = energy
    public GameObject nameinput;
    InputField t_nameinput;
    public GameObject moneycounter,
                petname,
                statsmenuname;
    TextMeshProUGUI t_moneycounter,
                t_petname,
                t_statsmenuname;
    public GameObject errorPopup,
                        newPetMenu,
                        mainGUI,
                        BGGUI;
    bool doesOwnPet;

    public void Awake()
    {

        t_moneycounter = moneycounter.GetComponent<TextMeshProUGUI>();
        t_petname = petname.GetComponent<TextMeshProUGUI>();
        t_statsmenuname = statsmenuname.GetComponent<TextMeshProUGUI>();
        t_nameinput = nameinput.GetComponent<InputField>();
    }
    public void Start()
    {
        if(doesOwnPet)
            GUIupdate();
    }

    public void feedPet()
    {
        if (PetSave.pet.money < 5)
            onError("money");
        else
        {
            PetSave.pet.money -= 5;
            PetSave.pet.energy += 5;
            GUIupdate();
        }
    }

    public void playWithPet()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            SceneManager.LoadScene("CatchingScene");
        }
    }

    public void goToFire()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            SceneManager.LoadScene("FireScene");
        }
    }

    public void goToPlant()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            SceneManager.LoadScene("beansgame");
        }
    }

    public void goToFly()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            SceneManager.LoadScene("flappyfriend");
        }
    }

    public void goToSurf()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            SceneManager.LoadScene("SwimmingScene");
        }
    }
    public void goToTreasure()
    {
        SceneManager.LoadScene("DiggingScene");
    }
    public void adoptPet()
    {
        Debug.Log(t_nameinput.text);
        PetSave.pet = new PetStats();
        PetSave.pet.setupNewGame(t_nameinput.text);
        GUIupdate();
    }

    public void onError(string notenough)
    {
        errorPopup.SetActive(true);
        errorPopup.GetComponentInChildren<TextMeshProUGUI>().text = "You need more " + notenough + "!";
    }

    public void GUIupdate()
    {
        Debug.Log(t_petname.text);
        t_petname.text = PetSave.pet.petname;
        t_statsmenuname.text = PetSave.pet.petname + "'s Stats";
        t_moneycounter.text = PetSave.pet.money.ToString();
        statsliders[0].value = PetSave.pet.firestat;
        statsliders[1].value = PetSave.pet.plantstat;
        statsliders[2].value = PetSave.pet.flystat;
        statsliders[3].value = PetSave.pet.surfstat;
        statsliders[4].value = PetSave.pet.expstat;
        statsliders[5].value = PetSave.pet.happiness;
        statsliders[6].value = PetSave.pet.energy;
    }
    
    public void SaveButton()
    {
        string json = JsonUtility.ToJson(PetSave.pet);
        File.WriteAllText($"{Application.persistentDataPath}/save.json", json);
    }

    public void LoadGame()
    {
        string gamesave = File.ReadAllText($"{Application.persistentDataPath}/save.json", System.Text.Encoding.UTF8);
        PetStats loadedfile = JsonUtility.FromJson<PetStats>(gamesave);
        Debug.Log(Application.persistentDataPath);
        PetSave.pet = loadedfile;
        GUIupdate();
    }

    public void PlayButton()
    {
        if (!File.Exists($"{Application.persistentDataPath}/save.json"))
        {
            newPetMenu.SetActive(true);
            doesOwnPet = false;
        }
        else
        {
            LoadGame();
            mainGUI.SetActive(true);
            BGGUI.SetActive(true);
        }
    }
}