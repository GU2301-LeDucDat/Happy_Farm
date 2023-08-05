using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehavior : MonoBehaviour
{
    private float speed;
    [SerializeField]
    private Animator PlayerAnimation;
    [SerializeField]
    private NavMeshAgent NavAgent;
    private bool enableJoyStick;
    private Vector2 joyStickVal;

    private float vertical;
    private float horizontal;
    private void Start()
    {
        speed = 0f;
        PlayerAnimation = GetComponent<Animator>();
        NavAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        MovingUsingKeyBoard();
        HandleAnimtion();
        //MovingUsingJoyStick();
    }

    private void MovingUsingKeyBoard()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 position = new Vector3(horizontal, 0, vertical);
        if(position != Vector3.zero)
        {
            PlayerAnimation.SetBool("Walk", true);
            transform.rotation = Quaternion.LookRotation(position);
        } else { PlayerAnimation.SetBool("Walk", false); }
        
        transform.Translate(Time.deltaTime * position * 7, Space.World);
    }

    private void HandleAnimtion()
    {
        speed = NavAgent.velocity.magnitude;
        PlayerAnimation.SetFloat("Speed", speed);
    }

    private void MovingUsingJoyStick()
    {
        if (enableJoyStick)
        {
            PlayerAnimation.SetBool("Walk", true);
            if (speed < NavAgent.speed) { speed += 0.01f; }
            NavAgent.destination = new Vector3(transform.position.x + joyStickVal.x * speed,
                transform.position.y,
                transform.position.z + joyStickVal.y * speed);
        }
        else { 
            speed = 0;
            PlayerAnimation.SetBool("Walk", false);
        }
        PlayerAnimation.SetFloat("Speed", speed);
    }

    public void OnDown()
    {
        enableJoyStick = true;
    }

    public void OnUp() 
    {
        enableJoyStick = false;
        joyStickVal = Vector2.zero;
    }

    public void OnSet(Vector2 val)
    {
        if (enableJoyStick)
        {
            joyStickVal = val;
        }
    }
}
