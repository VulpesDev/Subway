using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;
    GameObject viewPoint;
    [SerializeField]float speed;
    Rigidbody rb;
    bool infocus;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        viewPoint = player.transform.GetChild(0).GetChild(1).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFocus()
    {
        if (!infocus)
        {
            rb.isKinematic = true;
            infocus = true;
            StartCoroutine(Focus());
        }
        else
        {
            rb.isKinematic = false;
            infocus = false;
        }
    }
    IEnumerator Focus()
    {
        while (infocus)
        {
            transform.position = Vector3.Lerp(transform.position, viewPoint.transform.position, Time.deltaTime * speed);
            yield return new WaitForEndOfFrame();
        }
    }


}
