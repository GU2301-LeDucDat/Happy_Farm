using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 0.5f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlantSeed();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HarvestPlant();
        }
        
    }

    public void PlantSeed()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Mud mud))
            {
                mud.Trong();
            }
            if (collider.TryGetComponent(out ItemCanCollect item))
            {
                item.PickUp();
            }

        }
    }

    public void HarvestPlant()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out Mud mud))
            {
                mud.ThuHoach();
            }
        }
    }
}
