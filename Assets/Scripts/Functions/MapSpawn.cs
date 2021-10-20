using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{
    [SerializeField] private string mapName;
    private void Start()
    {
        Initializations();
    }

    [SerializeField] private MapRandomizer mapGen;
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
        ObjectPooler.Instance.ReturnToPool(mapName, this.gameObject);
        StopCoroutine("ReturnPool");
        mapGen.MapGen();
    }

    private void Initializations()
    {
        mapGen = FindObjectOfType<MapRandomizer>().GetComponent<MapRandomizer>();
        ObstaculeSpawn();
    }

    private void ObstaculeSpawn()
    {
        int typeGenerator = Random.Range(0, 3);
        transform.GetChild(typeGenerator).gameObject.SetActive(true);
    }
}
