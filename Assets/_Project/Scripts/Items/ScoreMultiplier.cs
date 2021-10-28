using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour, IPooledObject
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _flag;
    [SerializeField] private GameObject _child;

    private int _multiplier = 2;

    public void Initializations()
    {
        _player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player) && _player.canPick == true)
        {
            _player.canPick = false;
            PickUp();
        }
    }

    private void PickUp()
    {
        GameController.instance.scoreMultiplicator *= _multiplier;
        _flag.SetActive(true);
        _child.SetActive(false);
        StartCoroutine(EffectEvent());
    }

    public void OnObjectSpawn()
    {
        PickUp();
    }

    private IEnumerator EffectEvent()
    {
        yield return new WaitForSeconds(2f);
        GameController.instance.scoreMultiplicator /= _multiplier;
        _player.canPick = true;
        ObjectPooler.Instance.ReturnToPool("Bonnus", gameObject);
        StopCoroutine(EffectEvent());
    }

    private void Start()
    {
        Initializations();
    }
}
