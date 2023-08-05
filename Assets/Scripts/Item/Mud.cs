using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mud : MonoBehaviour
{
    [SerializeField]
    private GameObject UIPlant;
    private GrowPlant GrowSystem;
    private InteractUI _InteractUI;
    // Start is called before the first frame update
    void Start()
    {
        GrowSystem = GetComponent<GrowPlant>();
        _InteractUI = UIPlant.GetComponent<InteractUI>();
    }

    private void OnTriggerStay(Collider other)
    {
        _InteractUI.DisplayUIPlant(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _InteractUI.DisplayUIPlant(false);
    }

    public void Trong()
    {
        GrowSystem.growSeed();
    }
    public void ThuHoach()
    {
        GrowSystem.harvestPlant();
    }
}
