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
    public TMP_InputField nameinput;
    public TextMeshProUGUI moneycounter,
                petname,
                statsmenuname;
    public GameObject errorPopup,
                        newPetMenu;

    public void Awake()
    {
        if (!File.Exists($"{Application.persistentDataPath}/save.json"))
            newPetMenu.SetActive(true);
        else
            LoadGame();
    }
    public void Start()
    {
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
    public void goToFire()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            //change scene
        }
    }

    public void goToPlant()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            //change scene
        }
    }

    public void goToFly()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            //change scene
        }
    }

    public void goToSurf()
    {
        if (PetSave.pet.energy < 2)
            onError("energy");
        else
        {
            PetSave.pet.energy -= 2;
            //change scene
        }
    }

    public void adoptPet()
    {
        Debug.Log(PetSave.pet);
        PetSave.pet.setupNewGame(nameinput.GetComponent<TextMeshPro>().text);
        GUIupdate();
    }

    public void onError(string notenough)
    {
        errorPopup.SetActive(true);
        GetComponentInChildren<TextMeshProUGUI>().text = "You need more " + notenough + "!";
    }

    public void GUIupdate()
    {
        petname.text = PetSave.pet.petname;
        statsmenuname.text = PetSave.pet.petname + "'s Stats";
        moneycounter.text = PetSave.pet.money.ToString();
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
    }
}
