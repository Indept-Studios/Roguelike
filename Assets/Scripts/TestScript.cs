using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{
    public void OnEndHover()
    {
        Debug.Log("endHover");
    }

    public void OnHover()
    {
        Debug.Log("onHover");
    }

    public void OnStartHover()
    {
        Debug.Log("startHover");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
