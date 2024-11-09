using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    private Animator _anim;


    void Start()
    {
        //get the animator
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //input from player
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * y; //get the direction of movement
            //GetAnimationToPlay(move);
            controller.Move(move * baseSpeed * Time.deltaTime); //move player with the speed value

            //check the direction of movement for the animator
            if (Input.GetAxis("Vertical") > 0) 
            {
                _anim.SetBool("Run", true);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunBack", false);
            } else if (Input.GetAxis("Vertical") < 0)
            {
                _anim.SetBool("Run", false);
                _anim.SetBool("Idle", false);
                _anim.SetBool("RunBack", true);
            }

            
            //rotate player towards right or left
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, Time.deltaTime);
            
        } else
        {
            //stop movement animations and start Idle when no input
            _anim.SetBool("Idle", true);
            _anim.SetBool("Run", false);
            _anim.SetBool("RunBack", false);
        }
    }
}
