using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class Schooter : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform shootPoint;

    private Vector2 direction;
    private Vector3 mousePos;

    private bool shootButtonActive;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        shootButtonActive = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        if (shootButtonActive)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Bullet"), shootPoint.position, shootPoint.rotation);
        }
    }
}
