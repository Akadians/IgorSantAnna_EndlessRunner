using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLottery : MonoBehaviour
{
    private int index;
    public List<string> EffectList;
    private int capacity;
    

    public string Effect;
    
    public string RandomEffect()
    {
        capacity = EffectList.Capacity;
        index = Random.Range(0, capacity);
        Effect = EffectList[index];
        return Effect;
    }
}
