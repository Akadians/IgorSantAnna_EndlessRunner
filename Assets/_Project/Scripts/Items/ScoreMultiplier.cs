using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour, IPooledObject
{
    [SerializeField] private UIController _UIController;
    [SerializeField] private GameObject _object;

    private Player _player;
    private int _multiplier = 2;

    public void Initializations()
    {
        _UIController = FindObjectOfType<UIController>().GetComponent<UIController>();
    }
    public void OnObjectSpawn()
    {
        PickUp();
    }

    private void Start()
    {
        Initializations();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (player.canPick == true)
            {
                _player = player;
                _player.canPick = false;
                PickUp();
            }
        }
    }

    private void PickUp()
    {
        _UIController.ScoreMultiplierIcon(true);
        GameController.instance.scoreMultiplicator *= _multiplier;        
        _object.SetActive(false);
        StartCoroutine(EffectEvent());
    }    

    private IEnumerator EffectEvent()
    {
        yield return new WaitForSeconds(2f);
        GameController.instance.scoreMultiplicator /= _multiplier;        
        ObjectPooler.instance.ReturnToPool("Bonnus", gameObject);
        _UIController.ScoreMultiplierIcon(false);
        _player.canPick = true;
        StopCoroutine(EffectEvent());
    }    
}
