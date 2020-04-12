using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanTakeDamage : MonoBehaviour
{
    [SerializeField] private float maxHitpoints;
    [SerializeField] private float hitpoints = 10f;
    [SerializeField] private float regenerationrateInSeconds = 3f;
    [SerializeField] private float regenerationPerTick = 1f;
    [SerializeField] private bool isPlayerControlled = false;

    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerRegeneration();
    }

    void PlayerRegeneration()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= regenerationrateInSeconds)
        {
            if (hitpoints < maxHitpoints)
            {
                hitpoints += regenerationPerTick;
            }
            elapsedTime = 0f;
        }
    }

    void NPCRegeneration()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= regenerationrateInSeconds)
        {
            if (hitpoints < maxHitpoints)
            {
                hitpoints += regenerationPerTick;
            }
            elapsedTime = 0f;
        }
    }
}
