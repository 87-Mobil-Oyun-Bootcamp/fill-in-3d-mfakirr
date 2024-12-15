using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LevelCubes : MonoBehaviour
{
    Color myRealColor = default;

    Collider myCollider = default;

    FillCounter fillCounter = default;

    void Start()
    {
        myRealColor = GetComponent<Renderer>().material.color;

        GetComponent<Renderer>().material.color = Color.white;

        myCollider = GetComponent<BoxCollider>();

        fillCounter = GameObject.FindGameObjectWithTag("GameController").
            GetComponent<FillCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GiveColor")
        {
            other.gameObject.SetActive(false);

            myCollider.enabled = false;

            Invoke("GiveTheRealColor", 0.4f);
        }
    }

    void GiveTheRealColor()
    {
        fillCounter.counter++;

        Instantiate(fillCounter.DoSomeParticul, transform.position, Quaternion.identity);

        GetComponent<Renderer>().sharedMaterial.color = myRealColor;
    }
}
