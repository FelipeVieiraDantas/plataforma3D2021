using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 5, groundLayer))
        {
            Quaternion slopeRotation = Quaternion.FromToRotation(transform.up, hit.normal);
            transform.rotation = Quaternion.Slerp(transform.rotation, slopeRotation * transform.rotation, 10 * Time.deltaTime);
            //transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        Debug.DrawLine(transform.position, transform.position - transform.up*5, Color.red);
    }
}
