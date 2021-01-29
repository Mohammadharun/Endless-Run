using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.x < -3.5)
        {
            Destroy(gameObject);
        }
    }
}
