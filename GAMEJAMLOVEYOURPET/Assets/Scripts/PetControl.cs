using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControl : MonoBehaviour
{
    public Material Body,
                    Wings,
                    Tail,
                    Sprout,
                    Fins;
    public GameObject oWings,
                    oTail,
                    oSprout,
                    oFins,
                    oBabyBody,
                    oAdultBody;

    public void UPDATEPET()
    {
        Debug.Log((float)PetSave.pet.happiness);
        Body.SetFloat("Fly", ((float)PetSave.pet.flystat) / 100);
        Body.SetFloat("Fire", ((float)PetSave.pet.firestat) / 100);
        Body.SetFloat("Plant", ((float)PetSave.pet.plantstat) / 100);
        Body.SetFloat("Water", ((float)PetSave.pet.surfstat) / 100);
        Body.SetFloat("Happiness", ((float)PetSave.pet.happiness) / 100);


        if (PetSave.pet.isevolve)
        {
            Body.SetInt("IsEvolve", 1);
            oBabyBody.SetActive(false);
            oAdultBody.SetActive(true);

            if (PetSave.pet.isgoodadult)
            {
                Body.SetInt("isGoodAdult", 1);
            }
            else
            {
                Body.SetInt("isGoodAdult", 0);
            }

            if (PetSave.pet.flyadult)
            {
                oWings.SetActive(true);
                Wings.SetFloat("Fly", ((float)PetSave.pet.flystat) / 100);
                Wings.SetFloat("Fire", ((float)PetSave.pet.firestat) / 100);
                Wings.SetFloat("Plant", ((float)PetSave.pet.plantstat) / 100);
                Wings.SetFloat("Water", ((float)PetSave.pet.surfstat) / 100);
                Wings.SetFloat("Happiness", ((float)PetSave.pet.happiness) / 100);
            }
            if (PetSave.pet.fireadult)
            {
                oTail.SetActive(true);
                Tail.SetFloat("Fly", ((float)PetSave.pet.flystat )/ 100);
                Tail.SetFloat("Fire", ((float)PetSave.pet.firestat )/ 100);
                Tail.SetFloat("Plant", ((float)PetSave.pet.plantstat) / 100);
                Tail.SetFloat("Water", ((float)PetSave.pet.surfstat) / 100);
                Tail.SetFloat("Happiness", ((float)PetSave.pet.happiness) / 100);
            }
            if (PetSave.pet.plantadult)
            {
                oSprout.SetActive(true);
                Sprout.SetFloat("Fly", ((float)PetSave.pet.flystat) / 100);
                Sprout.SetFloat("Fire", ((float)PetSave.pet.firestat) / 100);
                Sprout.SetFloat("Plant", ((float)PetSave.pet.plantstat) / 100);
                Sprout.SetFloat("Water", ((float)PetSave.pet.surfstat) / 100);
                Sprout.SetFloat("Happiness", ((float)PetSave.pet.happiness )/ 100);
            }
            if (PetSave.pet.surfadult)
            {
                oFins.SetActive(true);
                Fins.SetFloat("Fly", ((float)PetSave.pet.flystat )/ 100);
                Fins.SetFloat("Fire", ((float)PetSave.pet.firestat )/ 100);
                Fins.SetFloat("Plant", ((float)PetSave.pet.plantstat ) / 100);
                Fins.SetFloat("Water", ((float)PetSave.pet.surfstat) / 100);
                Fins.SetFloat("Happiness", ((float)PetSave.pet.happiness )/ 100);
            }
        }
    }
}
