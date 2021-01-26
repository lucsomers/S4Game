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

    private bool ability1 = false;
    private bool ability2 = false;
    private bool ability3 = false;

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
        ability1 = Input.GetKey(skillData.Skill1);
        ability2 = Input.GetKey(skillData.Skill2);
        ability3 = Input.GetKey(skillData.Skill3);

        //Mouse
        mousePos = playerController.Cam.ScreenToWorldPoint(Input.mousePosition);
        leftMouseButtonDown = Input.GetMouseButton(0);
        rightMouseButtonDown = Input.GetMouseButton(1);
    }

    public float X_axis { get => x_axis; private set => x_axis = value; }
    public float Y_axis { get => y_axis; private set => y_axis = value; }
    public bool Ability1 { get => ability1; private set => ability1 = value; }
    public bool Ability2 { get => ability2; private set => ability2 = value; }
    public bool Ability3 { get => ability3; private set => ability3 = value; }
    public bool LeftMouseButtonDown { get => leftMouseButtonDown; private set => leftMouseButtonDown = value; }
    public bool RightMouseButtonDown { get => rightMouseButtonDown; private set => rightMouseButtonDown = value; }
    public Vector2 MousePos { get => mousePos; private set => mousePos = value; }
}
