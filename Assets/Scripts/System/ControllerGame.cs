using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ControllerGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ContactWithServer();
    }

    void ContactWithServer()
    {
        if (Input.GetKeyDown(KeyCode.Home))
        {
            TransactionServer.Instance.SendMessage(new Message() { type = "play", data = "data" });
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            TransactionServer.Instance.SendMessage(new Message() { type = "CloseMenu", data = "menu A" });
        }
    }
}
