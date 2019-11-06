using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Call the destroy function of ObjectPooling ans return it to the pool
        ObjectPooling.instance.ReturnToPool(other.gameObject);
    }
}
