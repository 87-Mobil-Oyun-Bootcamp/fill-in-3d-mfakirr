using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
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
                print("b");
                if (color.a == 0)
                {
                    continue;
                }

                blockPos = new Vector3(
                    spriteSize * (x - (mySprite.width * .5f)),
                    spriteSize * .5f,
                    spriteSize * (y - (mySprite.height * .5f)));

                GameObject cubeObj = Instantiate(Cube, transform);
                cubeObj.transform.localPosition = blockPos;

                cubeObj.GetComponent<Renderer>().material.color = color;
                cubeObj.transform.localScale = Vector3.one * spriteSize;
            }

        }
    }
}