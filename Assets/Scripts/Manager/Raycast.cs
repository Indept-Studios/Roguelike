using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public float _RaycastRange;

    [HideInInspector] public static Vector3 RAYCASTHITPOINT;
    [HideInInspector] public static GameObject OLDTARGET;

    private Camera _RaycastCamera;

    void Start()
    {
        _RaycastCamera = Camera.main;
    }

    private void Update()
    {
        CheckRaycastHit();
    }

    private void CheckRaycastHit()
    {
        RaycastHit raycastHit;

        Ray ray = _RaycastCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit, _RaycastRange))
        {
            //Raycast hit a target
            GameObject newTarget = raycastHit.collider.gameObject;

            if (newTarget != null)
            {

                //Raycast hit a interactable target
                if (raycastHit.distance <= _RaycastRange)
                {
                    RAYCASTHITPOINT = raycastHit.point;

                    //Raycast in hit range
                    if (newTarget == OLDTARGET)
                    {
                        //Raycasttarget hasn´t change
                        foreach (IInteractable IInteractableScript in OLDTARGET.GetComponentsInParent<IInteractable>())
                        {
                            IInteractableScript.OnHover();
                        }
                        return;
                    }
                    else if (OLDTARGET != null)
                    {
                        //Raycasttarget has changed, "OnEndHover" on old, "OnStartHover" on new 
                        foreach (IInteractable IInteractableScript in OLDTARGET.GetComponentsInParent<IInteractable>())
                        {
                            IInteractableScript.OnEndHover();
                        }

                        OLDTARGET = newTarget;

                        foreach (IInteractable IInteractableScript in OLDTARGET.GetComponentsInParent<IInteractable>())
                        {
                            IInteractableScript.OnStartHover();
                        }
                        return;
                    }
                    else
                    {
                        //Raycast get´s first target
                        OLDTARGET = newTarget;
                        foreach (IInteractable IInteractableScript in OLDTARGET.GetComponentsInParent<IInteractable>())
                        {
                            IInteractableScript.OnStartHover();
                        }
                        return;
                    }
                }
            }
        }

        if (OLDTARGET != null)
        {
            //Raycasttarget is old target, no new is hitten
            foreach (IInteractable IInteractableScript in OLDTARGET.GetComponentsInParent<IInteractable>())
            {
                IInteractableScript.OnEndHover();
            }

            OLDTARGET = null;

            return;
        }
    }
}