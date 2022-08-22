using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Interaction : FP
{
    [SerializeField] Transform rayTr;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerCode;
    void Start()
    {

    }
    void Update()
    {
        RaycastHit ray;
        bool hit = Physics.Raycast(rayTr.position, rayTr.forward, out ray, distance, layerCode.value);
        if (hit)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ray.collider.tag == "Observable")
                {
                    Debug.Log("Clicked");
                    ray.collider.gameObject.GetComponent<Observable>().startFocus();
                }
            }
        }
        Debug.DrawRay(rayTr.position, rayTr.forward * distance, Color.red);
    }
}
