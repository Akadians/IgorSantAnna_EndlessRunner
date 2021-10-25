using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private string _map;
    [SerializeField] private MapRandomizer mapRandomizerGen;

    //public void Initialize(MapRandomizer map)
    //{
    //    mapRandomizerGen = map;
    //    ObstaculeSpawn();
    //}

    private void Start()
    {
        mapRandomizerGen = FindObjectOfType<MapRandomizer>().GetComponent<MapRandomizer>();
        ObstaculeSpawn();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            StartCoroutine(ReturnPool());
        }
    }
    private IEnumerator ReturnPool()
    {
        Debug.Log("Touched");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(_map, this.gameObject);
        mapRandomizerGen.MapGen();
        StopCoroutine("ReturnPool");        
    }
    private void ObstaculeSpawn()
    {
        int typeGenerator = Random.Range(0, 3);
        transform.GetChild(typeGenerator).gameObject.SetActive(true);
    }
}
