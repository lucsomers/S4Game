using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviourPunCallbacks
{
    [SerializeField] private float lifeTime = 2;

    private float currentLifeTime;

    // Start is called before the first frame update
    void Start()
    {
        currentLifeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= lifeTime)
        {
            GameObject.Destroy(gameObject);
        }
    }

    [PunRPC]
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
