using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] private float force;

    [SerializeField] private float lifetime;

    private Rigidbody rb;

    private float currentTime = 0;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }
}
