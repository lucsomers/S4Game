using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageRandom : MonoBehaviour
{
    [SerializeField] private float MinSwitchTime;
    [SerializeField] private float MaxSwitchTime;

    private Animator animator;

    private Random rand = new Random();

    private float NextAnimation = 0;
    private float currentWaitingTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentWaitingTime += Time.deltaTime;

        if (currentWaitingTime >= NextAnimation)
        {
            animator.SetInteger("Random", Random.Range(1, 4));
            SetNextWaitTime();
            StartCoroutine(ResetRandom());
        }
    }

    private IEnumerator ResetRandom()
    {
        yield return 10;
        animator.SetInteger("Random", 0);
    }

    private void SetNextWaitTime()
    {
        NextAnimation = Random.Range(MinSwitchTime, MaxSwitchTime);
        currentWaitingTime = 0;
    }
}
