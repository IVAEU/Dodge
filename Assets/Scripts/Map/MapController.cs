using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public float mapRadius = 0;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, mapRadius);
        float line = Mathf.Sqrt(Mathf.Pow(mapRadius, 2) + Mathf.Pow(mapRadius, 2));
        Gizmos.DrawWireCube(transform.position, new Vector3(line,line,0));
    }
}
