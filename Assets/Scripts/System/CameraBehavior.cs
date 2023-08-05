using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float inputX = -8.63f;
    public float inputY = 7.44f;
    public float inputZ = 10.02f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        moveWithPlayer();
    }
    private void moveWithPlayer()
    {
        transform.position = player.transform.position + new Vector3(inputX, inputY, inputZ);
    }
}
