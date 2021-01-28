﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Link")]
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rigidBody;

    private PlayerMovement playerMovement;
    private PlayerTargetPoints playerTargetPoints;
    private PlayerInput playerInput;
    private PlayerCollision playerCollision;
    private PlayerHealth playerHealth;

    private PlayerPrimaryAttack playerPrimaryAttack;
    private PlayerSecondaryAttack playerSecondaryAttack;
    private PlayerAbility1 playerAbility1;
    private PlayerAbility2 playerAbility2;
    private PlayerAbility3 playerAbility3;

    private PlayerClass playerClass;
    private UI_Update ui_update;

    private void Awake()
    {
        playerMovement = GetComponentInChildren<PlayerMovement>();
        playerTargetPoints = GetComponentInChildren<PlayerTargetPoints>();
        playerInput = GetComponentInChildren<PlayerInput>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
        playerHealth = GetComponentInChildren<PlayerHealth>();
        playerClass = GetComponentInChildren<PlayerClass>();
        ui_update = GetComponentInChildren<UI_Update>();

        playerPrimaryAttack = GetComponentInChildren<PlayerPrimaryAttack>();
        playerSecondaryAttack = GetComponentInChildren<PlayerSecondaryAttack>();
        playerAbility1 = GetComponentInChildren<PlayerAbility1>();
        playerAbility2 = GetComponentInChildren<PlayerAbility2>();
        playerAbility3 = GetComponentInChildren<PlayerAbility3>();
    }

    public PlayerMovement PlayerMovement { get => playerMovement; private set => playerMovement = value; }
    public PlayerInput PlayerInput { get => playerInput; private set => playerInput = value; }
    public PlayerCollision PlayerCollision { get => playerCollision; private set => playerCollision = value; }
    public Camera Cam { get => cam; private set => cam = value; }
    public Rigidbody2D RigidBody { get => rigidBody; private set => rigidBody = value; }
    public PlayerClass PlayerClass { get => playerClass; private set => playerClass = value; }
    public UI_Update Ui_update { get => ui_update; private set => ui_update = value; }
    public PlayerPrimaryAttack PlayerPrimaryAttack { get => playerPrimaryAttack; set => playerPrimaryAttack = value; }
    public PlayerSecondaryAttack PlayerSecondaryAttack { get => playerSecondaryAttack; set => playerSecondaryAttack = value; }
    public PlayerPrimaryAttack PlayerPrimaryAttack1 { get => playerPrimaryAttack; set => playerPrimaryAttack = value; }
    public PlayerSecondaryAttack PlayerSecondaryAttack1 { get => playerSecondaryAttack; set => playerSecondaryAttack = value; }
    public PlayerAbility1 PlayerAbility1 { get => playerAbility1; set => playerAbility1 = value; }
    public PlayerAbility2 PlayerAbility2 { get => playerAbility2; set => playerAbility2 = value; }
    public PlayerAbility3 PlayerAbility3 { get => playerAbility3; set => playerAbility3 = value; }
    public PlayerHealth PlayerHealth { get => playerHealth; set => playerHealth = value; }
    public PlayerTargetPoints PlayerTargetPoints { get => playerTargetPoints; private set => playerTargetPoints = value; }
}