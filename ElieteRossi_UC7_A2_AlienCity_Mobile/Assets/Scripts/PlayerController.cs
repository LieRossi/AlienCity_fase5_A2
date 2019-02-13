﻿using UnityEngine;
using System.Collections;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    public float MoveSpeed;
    public float RotationSpeed;
    CharacterController cc;
    private Animator anim;
    protected Vector3 gravidade = Vector3.zero;
    protected Vector3 move = Vector3.zero;
    private bool jump = false;


    public float moveSpeed = 1f;
    public Joystick joystick;

    private Vector3 auxV;
    private Vector3 auxH;
    private Vector3 V;
    private Vector3 H;
    private Vector3 movement;

    //public GameObject p1;
    //public GameObject p2;



    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Parado");

        //p1.gameObject.GetComponent<Animation>().Stop();
        //p2.gameObject.GetComponent<Animation>().Stop();
    }

    void Update()
    {
        float auxV = Input.GetAxis("Vertical");
        float auxH = Input.GetAxis("Horizontal");
        Vector3 move = auxV * transform.TransformDirection(Vector3.forward) * MoveSpeed;// move para frente/tras
        transform.Rotate(new Vector3(0, auxH * RotationSpeed * Time.deltaTime, 0));// rotaciona para os lados

        if (!cc.isGrounded)
        {
            gravidade += Physics.gravity * Time.deltaTime;
        }
        else
        {
            gravidade = Vector3.zero;
            if (jump)
            {
                gravidade.y = 6f;
                jump = false;
            }
        }
        move += gravidade;
        cc.Move(move * Time.deltaTime);
        Anima();
        //BotaoPular();



        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);

        if (moveVector != Vector3.zero)
        {
            float V = joystick.Vertical;
            float H = joystick.Horizontal;

            transform.Translate(moveVector * Time.deltaTime * MoveSpeed);//move para frente/tras
            transform.Rotate(new Vector3(0, H * RotationSpeed * Time.deltaTime, 0) * MoveSpeed);// rotaciona para os lados


        }
    }

    void Anima()
    {
        if (!Input.anyKey)
        {
            anim.SetTrigger("Parado");
        }
        else
        {
            if (Input.GetKeyDown("space"))
            {
                anim.SetTrigger("Pula");
                jump = true;
            }
            else
            {
                anim.SetTrigger("Corre");

            }
        }
    }

    public void BotaoPular()
    {
        if (!jump)
        {
            anim.SetTrigger("Pula");
            jump = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pedra") || (other.gameObject.CompareTag("trigger")))
        {
            Handheld.Vibrate();
        }

        if (other.gameObject.CompareTag("triggerplat"))
        {
            Handheld.Vibrate();
            // p1.gameObject.GetComponent<Animation>().Play();
            //p2.gameObject.GetComponent<Animation>().Play();

        }
    }

    /*void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("trigger"))
        {
            Handheld.Vibrate();
        }

    }*/
}


