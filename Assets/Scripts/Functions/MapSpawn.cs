using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private MapRandomizer map;
    void Awake()
    {
        Initializations(); 
    }
        
    void Update()
    {
        
    }

    private void Initializations()
    {
        //map.MapGen();
    }
}
