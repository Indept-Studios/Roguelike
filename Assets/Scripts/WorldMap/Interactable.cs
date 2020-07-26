using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Interactable : MonoBehaviour
{
    Vector2 oldscale;

    void Start()
    {
        if (GetComponent<BoxCollider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
    }

    void Update()
    {

    }

    private void OnMouseEnter()
    {

        if (gameObject.GetComponent<Creature>())
        {
            oldscale = transform.localScale;
            transform.localScale = new Vector2(1.5f, 1.5f);
        }
        else
        {
            Debug.Log("Hover on Enter geht, nicht Creature");
        }

    }

    private void OnMouseExit()
    {
        if (gameObject.GetComponent<Creature>())
        {
            transform.localScale = oldscale;
        }
        else
        {
            Debug.Log("Hover Exit geht auch, nicht Creature");
        }
    }
    private void OnMouseOver()
    {
        Debug.Log("Hover geht auch, nicht Creature");
    }
}
