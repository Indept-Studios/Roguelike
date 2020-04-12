using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : MonoBehaviour
{
    public int numberOfPrefabs;
    public GameObject[] prefabPool;

    void Start()
    {
        prefabPool = new GameObject[numberOfPrefabs];
        prefabCreation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void prefabCreation()
    {
        for (int i = 0; i < prefabPool.Length; i++)
        {
            Instantiate(prefabPool[i]);
        }
    }
}
