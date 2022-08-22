using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP : MonoBehaviour
{

    protected Rigidbody rb;
    protected GameObject cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            Cursor.lockState = CursorLockMode.None;
            //MenuManager.LoadScene(0);
        }
    }
}
