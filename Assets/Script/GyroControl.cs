using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
   // public bool IsFlat = true;
    private Rigidbody rigi;

    private void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        /*Vector3 tite = Input.acceleration;

        if (IsFlat == true)
            tite = Quaternion.Euler(0, 0, 0)*tite;*/
      


        rigi.AddForce(Input.acceleration*30);
    }
}
