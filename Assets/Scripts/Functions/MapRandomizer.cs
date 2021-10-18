using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomizer : MonoBehaviour, IPooledObject
{
    private int value;
    [SerializeField] private List<string> maps = new List<string>();
    [SerializeField] private List<GameObject> prefabs = new List<GameObject>();
    private int offSet;

    private void Start()
    {
        StartMap();
    }

    public void MapGen()
    {

        value = Random.Range(0, 3);
        switch (value)
        {
            case 0:
                ObjectPooler.Instance.SpawnFromPool("01", new Vector3 (0,0,offSet), transform.localRotation);
                offSet += 90;

                break;
            case 1:
                ObjectPooler.Instance.SpawnFromPool("02", new Vector3(0, 0,offSet), transform.localRotation);
                offSet += 90;

                break;
            case 2:
                ObjectPooler.Instance.SpawnFromPool("03", new Vector3(0, 0, offSet), transform.localRotation);
                offSet += 90;

                break;

            default:
                break;
        }
    }

    private void StartMap()
    {
        for (int i = 0; i < maps.Count; i++)
        {
            
            //ObjectPooler.Instance.SpawnFromPool(maps[i], new Vector3(0, 0, i * 90), transform.rotation);
            Instantiate(prefabs[i], new Vector3(0, 0, i * 90), transform.rotation);
            Debug.Log(prefabs[i]);
            offSet += 90;
        }
    }

    public void OnObjectSpawn()
    {
        StartMap();
    }
}
