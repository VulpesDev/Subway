using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Movement : FP
{
    [Header("Movement Settings")]
    [SerializeField] float acc = 5f;
    [SerializeField] float maxSpeed = 1.4f, timeModifier = 100f;
    float horizontal, vertical;

    Vector3 camStartPos;

    [Header("Walk_Sim Settings")]
    [SerializeField] float upWalkEffect = 0.05f;
    [SerializeField] float downWalkEffect = 0.2f, metersToSkip = 0.5f;
    Vector3 lastPos, currentPos;

    void Start()
    {
        camStartPos = cam.transform.localPosition;
        currentPos = transform.position; lastPos = currentPos;
    }
    void Update()
    {
        Movement(); // Movement of Player
        StepSim(); // Simulating Steps
    }
    bool goUp = false;
    bool once;
    float maxYup = 0.37f;
    void StepSim()
    {
        currentPos = transform.position;
        if (Mathf.Abs(rb.velocity.x) >= 0.01f || Mathf.Abs(rb.velocity.z) >= 0.01f)
        {
            once = false;
            if (Mathf.Abs(currentPos.x - lastPos.x) >= metersToSkip || Mathf.Abs(currentPos.z - lastPos.z) >= metersToSkip)
            {
                goUp = false;
                // MusicManager.StepSounds();
                lastPos = currentPos;
            }
        }
        else
        {
            goUp = false;
            if (!once)
            {
               // MusicManager.StepSounds();
                once = true;
            }
        }
        if (goUp)
        {
            if(cam.transform.localPosition.y <= maxYup)
            cam.transform.localPosition += new Vector3(0, upWalkEffect * Time.deltaTime, 0);
        }
        else
        {
            if (cam.transform.localPosition.y > camStartPos.y)
                cam.transform.localPosition -= new Vector3(0, downWalkEffect * Time.deltaTime, 0);
            else
                goUp = true;
        }

    }
    void Movement()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (vertical >= 0.5f) // client is pressing "w"
        {
            //Move forwards

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(transform.forward * acc * Time.deltaTime * timeModifier);
        }
        else if (vertical <= -0.5f) // client is pressing "s"
        {
            //Move backwards

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(-transform.forward * acc * Time.deltaTime * timeModifier);
        }

        if (horizontal >= 0.5f) // client is pressing "d"
        {
            //Move right

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(transform.right * acc * Time.deltaTime * timeModifier);
        }
        else if (horizontal <= -0.5f) // client is pressing "a"
        {
            //Move left

            if (Mathf.Abs(rb.velocity.x) <= maxSpeed && Mathf.Abs(rb.velocity.z) <= maxSpeed)
                rb.AddForce(-transform.right * acc * Time.deltaTime * timeModifier);
        }
    }
}
