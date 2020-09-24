using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    [SerializeField] private float maxLifeTime = 0;

    private float schrinkAmount = 0;
    private float currentLifeTime = 0;

    private void Start()
    {
        schrinkAmount = transform.localScale.x / maxLifeTime * 0.01f;
    }

    private void Update()
    {
        if (maxLifeTime <= currentLifeTime)
        {
            //Kill self
            GameObject.Destroy(gameObject);
        }
        else
        {
            currentLifeTime += Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x - schrinkAmount, transform.localScale.y -schrinkAmount, transform.localScale.z - schrinkAmount);
            }
            else
            {
                transform.localScale = new Vector3(0,0,0);
            }
        }
    }
}
