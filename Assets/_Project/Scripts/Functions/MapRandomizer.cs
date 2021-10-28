using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRandomizer : MonoBehaviour, IPooledObject
{
    [SerializeField] private int _value;
    [SerializeField] private List<string> _maps = new List<string>();
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();

    private MapType _mapType;
    private int _offSet;
    public void Initializations()
    {        
        StartMap();
    }

    public void OnObjectSpawn()
    {
        StartMap();
    }

    public void MapGen()
    {
        _value = Random.Range(0, System.Enum.GetValues(typeof(MapType)).Length);
        
        switch ((MapType)_value)
        {
            case MapType.CITY_MAP:

                ObjectPooler.Instance.SpawnFromPool("01", new Vector3(0, 0, _offSet), transform.localRotation);
                _offSet += 90;
                break;

            case MapType.FARM_MAP:

                ObjectPooler.Instance.SpawnFromPool("02", new Vector3(0, 0, _offSet), transform.localRotation);
                _offSet += 90;
                break;

            case MapType.JAPAN_MAP:

                ObjectPooler.Instance.SpawnFromPool("03", new Vector3(0, 0, _offSet), transform.localRotation);
                _offSet += 90;
                break;            
        }
    }

    private void Start()
    {
        Initializations();
    }

    private void StartMap()
    {
        for (int i = 0; i < _maps.Count; i++)
        { 
            GameObject instantiatedMap = Instantiate(_prefabs[i], new Vector3(0, 0, i * 90), transform.rotation);            
            _offSet += 90;

            /*
            if (instantiatedMap.TryGetComponent(out MapSpawn mapSpawn))
            {
                mapSpawn.Initialize(this);
            }
            */
        }
    }
}
