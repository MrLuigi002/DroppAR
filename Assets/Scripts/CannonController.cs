using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject cannonCylinder;

    void Start()
    {
        
    }

    
    void Update()
    {
        cannonCylinder.transform.LookAt(target.transform.position, Vector3.up);
    }
}
