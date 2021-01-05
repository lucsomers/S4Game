using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    [SerializeField] private float maxMuzzleFlashTime = 0.5f;

    private float currentTime = 0;

    private void OnEnable()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime <= maxMuzzleFlashTime)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= maxMuzzleFlashTime)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
