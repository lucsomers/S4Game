using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkMovement : MonoBehaviour
{
    [SerializeField] private GameObject BloodParticles;
    [Header("Movement")]
    [SerializeField] private float stepTimer;
    [SerializeField] private float stepSize;

    private Vector2 destination;

    private float currentStepTime = 0;

    public void SetDestination(Vector2 newDestination)
    {
        destination = newDestination;
    }

    // Update is called once per frame
    void Update()
    {
        if (destination != null)
        {
            if (stepTimer <= currentStepTime)
            {
                Vector2 mypos = new Vector2(transform.position.x, transform.position.y);

                mypos = Vector2.MoveTowards(mypos, destination, stepSize * Time.deltaTime);
                transform.position = mypos;
                currentStepTime = 0;
            }
            else
            {
                currentStepTime += Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            //Kill both
            Destroy(collision.gameObject);
            Destroy(gameObject);

            //spawn particles on both
            GameObject tempBloodParticles = Instantiate(BloodParticles);
            tempBloodParticles.transform.position = transform.position;

            GameObject tempBloodParticlesCharacter = Instantiate(BloodParticles);
            tempBloodParticlesCharacter.transform.position = collision.transform.position;
        }
    }
}
