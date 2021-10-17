using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLottery : MonoBehaviour
{
    //[SerializeField] private SceneDebuffs debuffs;
    private int randomEffect;

    public void RandomDebuff()
    {
        randomEffect = Random.Range(0, 4);
       // debuffs.Touched(randomEffect);
    }
}


