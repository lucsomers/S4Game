using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviourPunCallbacks
{
    [SerializeField] private const int maxHealth = 3;
    [SerializeField] private GameObject graphic;

    private PlayerRotation rotationScript;

    private int currentHealth = 0;

    private PhotonView PV;
    private float RespawnTimer = 3;

    private void Start()
    {
        PV = GetComponent<PhotonView>();
        rotationScript = GetComponent<PlayerRotation>();
        currentHealth = maxHealth;
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            PlayerIsDeath();
        }
    }

    private void PlayerIsDeath()
    {
        PV.RPC("PlayerDisable", RpcTarget.All);
        StartCoroutine(TimeEnabled());
    }

    private IEnumerator TimeEnabled()
    {
        yield return new WaitForSeconds(RespawnTimer);

        PV.RPC("PlayerEnable", RpcTarget.All);
    }

    [PunRPC]
    private void PlayerDisable()
    {
        rotationScript.isdeath = true;
        graphic.SetActive(false);
    }

    [PunRPC]
    private void PlayerEnable()
    {
        currentHealth = maxHealth;
        transform.position = GameSetupController.instance.GetSpawnPoint(); 
        rotationScript.isdeath = false;
        graphic.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PV.IsMine)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage(1);
                Destroy(collision.gameObject);
            }
        }
    }
}
