using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LevelCubes : MonoBehaviour
{
    Color myRealColor = default;

    Collider myCollider = default;

    void Start()
    {
        myRealColor = GetComponent<Renderer>().material.color;

        GetComponent<Renderer>().material.color = Color.white;

        myCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GiveColor")
        {
            GetComponent<Renderer>().material.color = myRealColor;
            Destroy(other.gameObject);
            myCollider.enabled = false;
        }
    }
}
