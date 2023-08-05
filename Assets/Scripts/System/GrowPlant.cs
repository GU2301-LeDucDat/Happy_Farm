using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPlant : MonoBehaviour
{
    [SerializeField]
    private GameObject[] plantPrefabs;
    
    private void Start()
    {
    }

    public void growSeed()
    {
        foreach (GameObject plant in plantPrefabs)
        {
            if (plant.TryGetComponent<Cabbage>(out Cabbage cabbage))
            {
                cabbage.growCabbage();
            }
            else if (plant.TryGetComponent<Tomato>(out Tomato tomato))
            {
                tomato.growTomato();
            }
        }
    }

    public void harvestPlant()
    {
        foreach (GameObject plant in plantPrefabs)
        {
            if (plant.TryGetComponent<Cabbage>(out Cabbage cabbage))
            {
                cabbage.harvestCabbage();
            } else
            if (plant.TryGetComponent<Tomato>(out Tomato tomato))
            {
                tomato.harvestTomato();
            }
        }
    }

}
