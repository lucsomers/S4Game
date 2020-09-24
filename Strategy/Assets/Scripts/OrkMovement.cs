using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrkMovement : MonoBehaviour
{
    [SerializeField] private GameObject BloodParticles;
    [Header("Movement")]
    [SerializeField] private float stepTimer;
    [SerializeField] private float stepSize;
    [SerializeField] private float detectionRadius;

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

            CheckForVillage();
        }

        
    }

    private void CheckForVillage()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        if (colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Village") || collider.CompareTag("Miner") || collider.CompareTag("WoodCutter"))
                {
                    SetDestination(collider.transform.position);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Character"))
        {
            Character tempCharacter = collision.collider.GetComponent<Character>();

            if (!tempCharacter.IsKnight)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                tempCharacter.HealthDown(1);
            }

            GameObject tempBloodParticlesCharacter = Instantiate(BloodParticles);
            tempBloodParticlesCharacter.transform.position = collision.transform.position;
            
            GameObject tempBloodParticles = Instantiate(BloodParticles);
            tempBloodParticles.transform.position = transform.position;

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
