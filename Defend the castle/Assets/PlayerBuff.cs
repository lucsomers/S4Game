using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuff : MonoBehaviour
{
    private float currentSpeed;
    private float defaultSpeed;
    private PlayerController playerController;

    private void Start()
    {
        defaultSpeed = playerController.PlayerClass.CurrentPlayerClass.MoveSpeed;
        currentSpeed = defaultSpeed;
    }
}
