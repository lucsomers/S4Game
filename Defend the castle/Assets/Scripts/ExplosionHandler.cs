using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField] private float MaxLifeTime;

    private float currentLifeTime;

    // Update is called once per frame
    void Update()
    {
        currentLifeTime += Time.deltaTime;

        if (currentLifeTime >= MaxLifeTime)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
