using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm { get; private set; }

    public Animator myCubesBlinkAnim = default;


    private void Start()
    {
        gm = this;
    }

    public void DoSomeAnim()
    {      
        /*  GameObject[] LeftCubes = GameObject.FindGameObjectsWithTag("FillCubes");

        for (int i = 0; i <LeftCubes.Length; i++)
        {

        }*/
    }

    public void LevelIsDone()
    {
        //level is end
        print("ok");
    }
}
