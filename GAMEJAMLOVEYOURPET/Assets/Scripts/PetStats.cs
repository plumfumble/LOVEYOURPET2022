using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PetStats
{
    public string petname;
    public int happiness,
                        energy,
                        money,
                        firestat,
                        plantstat,
                        flystat,
                        surfstat,
                        expstat;

    public void setupNewGame(string newname)
    {
        if (newname == "")
            petname = "Your Pet";
        else
            petname = newname;
        happiness = 0;
        energy = 5;
        money = 0;
        firestat = 0;
        plantstat = 0;
        flystat = 0;
        surfstat = 0;
        expstat = 0;
    }
 }
