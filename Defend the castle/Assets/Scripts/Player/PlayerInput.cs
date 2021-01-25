using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController playerController;

    private InputData skillData = new InputData();

    private float x_axis = 0;
    private float y_axis = 0;

    private bool skill1 = false;
    private bool skill2 = false;
    private bool skill3 = false;

    private bool leftMouseButtonDown = false;
    private bool rightMouseButtonDown = false;

    private Vector2 mousePos;

    private void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    void Update()
    {
        //Movement
        x_axis = Input.GetAxisRaw("Horizontal");
        y_axis = Input.GetAxisRaw("Vertical");

        //SKills
        skill1 = Input.GetKey(skillData.Skill1);
        skill2 = Input.GetKey(skillData.Skill2);
        skill3 = Input.GetKey(skillData.Skill3);

        //Mouse
        mousePos = playerController.Cam.WorldToScreenPoint(Input.mousePosition);
        leftMouseButtonDown = Input.GetMouseButton(0);
        rightMouseButtonDown = Input.GetMouseButton(1);
    }

    public float X_axis { get => x_axis; private set => x_axis = value; }
    public float Y_axis { get => y_axis; private set => y_axis = value; }
    public bool Skill1 { get => skill1; private set => skill1 = value; }
    public bool Skill2 { get => skill2; private set => skill2 = value; }
    public bool Skill3 { get => skill3; private set => skill3 = value; }
    public bool LeftMouseButtonDown { get => leftMouseButtonDown; private set => leftMouseButtonDown = value; }
    public bool RightMouseButtonDown { get => rightMouseButtonDown; private set => rightMouseButtonDown = value; }
    public Vector2 MousePos { get => mousePos; private set => mousePos = value; }
}
