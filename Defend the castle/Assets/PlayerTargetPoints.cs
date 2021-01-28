using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetPoints : MonoBehaviour
{
    private PlayerController playerController;

    private List<Transform> targetPoints = new List<Transform>();

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();

        SetupTargetList();
    }

    public Transform GetRandomTargetPoint()
    {
        return targetPoints[UnityEngine.Random.Range(0,targetPoints.Count)];
    }

    private void SetupTargetList()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            targetPoints.Add(t);
        }
    }
}
