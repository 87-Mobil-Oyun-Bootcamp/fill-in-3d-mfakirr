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

    int sumFillCubes = 0;

    FillCounter fillCounter = default;

    private void OnEnable()
    {
        fillCounter = fillCounter = GameObject.FindGameObjectWithTag("GameController").
            GetComponent<FillCounter>();

       

        for (int x = 0; x < mySprite.height; x++)
        {
            for (int y = 0; y < mySprite.width; y++)
            {
                Color color = mySprite.GetPixel(x, y);

                if (color.a == 0)
                {
                    sumFillCubes++;
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
        fillCounter.sumCubes = mySprite.height* mySprite.width - sumFillCubes;
    }
}