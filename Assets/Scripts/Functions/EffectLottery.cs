using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLottery : MonoBehaviour
{
    //[SerializeField] private SceneDebuffs debuffs;
    private int _randomEffect;

    public void RandomDebuff()
    {
        _randomEffect = Random.Range(0, 4);       
    }
}


