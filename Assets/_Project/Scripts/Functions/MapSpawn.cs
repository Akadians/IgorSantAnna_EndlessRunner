using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private string _map;
    [SerializeField] private MapRandomizer _mapRandomizerGen;

    /*
    public void Initialize(MapRandomizer map)
    {
        mapRandomizerGen = map;
        ObstaculeSpawn();
    }
    */

    public void Initializations()
    {        
        _mapRandomizerGen = FindObjectOfType<MapRandomizer>().GetComponent<MapRandomizer>();
        ObstaculeSpawn();
    }
    private void Start()
    {
        Initializations();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            StartCoroutine(ReturnPool());
        }
    }
    private IEnumerator ReturnPool()
    {        
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(_map, this.gameObject);
        _mapRandomizerGen.MapGen();
        StopCoroutine("ReturnPool");        
    }
    private void ObstaculeSpawn()
    {
        int typeGenerator = Random.Range(0, 3);
        transform.GetChild(typeGenerator).gameObject.SetActive(true);
    }
}
