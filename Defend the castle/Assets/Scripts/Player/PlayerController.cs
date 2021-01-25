using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float moveSpeed = 6;
    [SerializeField] private float diagnalMovementLimiter = 0.7f;
    [Header("Link")]
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody2D rigidBody;

    private PlayerMovement playerMovement;
    private PlayerInput playerInput;
    private PlayerCollision playerCollision;
    private PlayerAttack playerAttack;
    private PlayerClass playerClass;

    private void Start()
    {
        playerMovement = GetComponentInChildren<PlayerMovement>();
        playerInput = GetComponentInChildren<PlayerInput>();
        playerCollision = GetComponentInChildren<PlayerCollision>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        playerClass = GetComponentInChildren<PlayerClass>();
    }

    public PlayerMovement PlayerMovement { get => playerMovement; private set => playerMovement = value; }
    public PlayerInput PlayerInput { get => playerInput; private set => playerInput = value; }
    public PlayerCollision PlayerCollision { get => playerCollision; private set => playerCollision = value; }
    public PlayerAttack PlayerAttack { get => playerAttack; private set => playerAttack = value; }
    public Camera Cam { get => cam; private set => cam = value; }
    public Rigidbody2D RigidBody { get => rigidBody; private set => rigidBody = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float DiagnalMovementLimiter { get => diagnalMovementLimiter; private set => diagnalMovementLimiter = value; }
    public PlayerClass PlayerClass { get => playerClass; private set => playerClass = value; }
}
