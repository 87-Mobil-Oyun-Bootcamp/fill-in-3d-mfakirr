using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class CubeSpawners : MonoBehaviour
{  
    //it is spesific code i manualley arrange something in scene

    [SerializeField]
    GameObject Cube = default;

    Vector3 blockPos = Vector3.zero;

    [SerializeField]
    Texture2D mySprite = default;

    [SerializeField]
    float spriteSize = 0;

    private void OnEnable()
    {
        for (int x = 0; x < mySprite.height; x++)
        {
            for (int y = 0; y < mySprite.width; y++)
            {
                Color color = mySprite.GetPixel(x, y);
                
                if (color.a == 0)
                {
                    continue;
                }

                blockPos = new Vector3(
                    spriteSize * .5f,
                    spriteSize * (x - (mySprite.width * .5f)),
                    spriteSize * (y - (mySprite.height * .5f)));

                GameObject cubeObj = Instantiate(Cube, transform);
                cubeObj.transform.localPosition = blockPos;
             
                    cubeObj.GetComponent<Renderer>().material.color =
                        Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                cubeObj.transform.localScale = Vector3.one * spriteSize;
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //my cubes don have gravity ı will give them when my  player touch the collider
            int children = transform.childCount;
            for (int i = 0; i < children; ++i)
            {
                transform.GetChild(i).GetComponent<Rigidbody>().useGravity = enabled;
            }
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

}
