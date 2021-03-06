using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCounter : MonoBehaviour
{
    public int counter  = 0;

    public int sumCubes = 0;

    public ParticleSystem DoSomeParticul = default;

    private void Start()
    {
        
    }


    private void LateUpdate()
    {
        if (counter>sumCubes)
        {
            //GameManager.gm.DoSomeAnim();
        }

        if(sumCubes == counter)
        { GameManager.gm.LevelIsDone(); }
    }
}
