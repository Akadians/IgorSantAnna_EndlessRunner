using DG.Tweening;
using System.Collections;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    public bool canPick;

    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _floorMask;    
    [SerializeField] private UIController _UIController;
    [SerializeField] [Range(0, 10)] private float _limiter;
    [SerializeField] [Range(0, 5)] private float _moveTimeInSeconds;
    [SerializeField] private bool _moving = false;

    private bool _rightSide = true;
    private Rigidbody _rigB;
    private Animator _anim;

    public void Initializations()
    {
        _rigB = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        canPick = true;
    }

    public void ChangeLine(MoveType move)
    {
        switch (move)
        {
            case MoveType.LEFT:

                LeftMove();
                break;
            case MoveType.RIGHT:

                RightMove();
                break;            
        }
    }    

    private void Start()
    {
        Initializations();
    }

    private void FixedUpdate()
    {
        Moviment();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out DeathEncounter death))
        {            
            EndGame();            
        }
    }    

    private void Moviment()
    {
        _rigB.transform.position += Vector3.forward * _speed * Time.deltaTime;
    }

    private void LeftMove()
    {
        if (_rightSide == true && _moving == false)
        {
            _moving = true;
            _rigB.transform.DOMoveX(-_limiter, _moveTimeInSeconds).OnComplete(() =>
            {
                _rightSide = false;
                _moving = false;
            });
            return;
        }
    }
    private void RightMove()
    {
        if (_rightSide == false && _moving == false)
        {
            _moving = true;
            _rigB.transform.DOMoveX(_limiter, _moveTimeInSeconds).OnComplete(() =>
            {
                _rightSide = true;
                _moving = false;
            });
            return;
        }
    }

    private bool GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * .5f, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, .1f, _floorMask))
        {
            return true;
        }
        return false;
    }

    private void EndGame()
    {
        _speed = 0;
        _anim.SetBool("isDead", true);
        StartCoroutine(GameOverDelay());
        IEnumerator GameOverDelay() 
        {
            yield return new WaitForSeconds(1.5f);
            GameController.instance.GameOver();
            StopCoroutine(GameOverDelay());
        }        
    }
}
