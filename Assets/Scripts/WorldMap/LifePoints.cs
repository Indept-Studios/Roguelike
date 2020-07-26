using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoints : MonoBehaviour
{
    [SerializeField] private float maxHitpoints;
    [SerializeField] private float currentHitpoints = 10f;
    [SerializeField] private float regEverySeconds = 3f;
    [SerializeField] private float regPerTick = 1f;
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
        if (elapsedTime >= regEverySeconds)
        {
            if (currentHitpoints < maxHitpoints)
            {
                currentHitpoints += regPerTick;
            }
            elapsedTime = 0f;
        }
    }

    public void ChangeLifeValue(float changeValue)
    {
        currentHitpoints += changeValue;
    }
}
