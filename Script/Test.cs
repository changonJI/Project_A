using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Transform target1;
    public Transform target2;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector3.Distance(target1.position, target2.position);

        Debug.Log(Vector3.Distance(target1.position, target2.position));
    }
}
