using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerRotation : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletForce;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float maxDownTime = 0.4f;
    private float currentDownTime = 0;

    private PhotonView PV;

    private Vector3 mousePos;
    private Camera cam;

    private bool Shoot;
    private bool timeToShoot;

    [HideInInspector]
    public bool isdeath = false;

    private void Start()
    {
        cam = Camera.main;
        PV = GetComponent<PhotonView>();
        currentDownTime = maxDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            RotateTowardMouse();

            Shoot = Input.GetMouseButtonDown(0);

            SetDownTime();

            if (Shoot && !isdeath && timeToShoot)
            {
                PV.RPC("ShootBullet", RpcTarget.All, transform.rotation);
            }
        }
    }

    private void SetDownTime()
    {
        if (currentDownTime >= maxDownTime)
        {
            timeToShoot = true;

            if (Shoot)
            {
                currentDownTime = 0;
            }
        }
        else
        {
            currentDownTime += Time.deltaTime;
            timeToShoot = false;
        }
    }

    [PunRPC]
    private void ShootBullet(Quaternion rotation)
    {
        playerTransform.rotation = rotation;

        GameObject ob = Instantiate(bulletPrefab, shootPoint.position, playerTransform.rotation);

        Rigidbody2D rd = ob.GetComponent<Rigidbody2D>();
        rd.AddForce(playerTransform.up * -1 * bulletForce, ForceMode2D.Impulse);
        muzzleFlash.SetActive(true);
    }

    private void RotateTowardMouse()
    {
        // Get Angle in Radians
        float AngleRad = Mathf.Atan2(mousePos.y - playerTransform.position.y, mousePos.x - playerTransform.position.x);
        // Get Angle in Degrees
        float AngleDeg = (180 / Mathf.PI) * AngleRad + 90;
        // Rotate Object
        playerTransform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}
