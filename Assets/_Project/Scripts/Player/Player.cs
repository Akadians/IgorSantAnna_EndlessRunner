using DG.Tweening;
using System.Collections;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private float _jumpForce;
    [SerializeField] private UI_Controller _UIController;
    [SerializeField] [Range(0, 20)] private float _limiter;
    [SerializeField] [Range(0, 10)] private float _sideMoveSpeed;
    [SerializeField] private bool _moving = false;

    private bool _rightSide = true;
    private Rigidbody _rigB;
    private Animator _anim;

    public void Jump()
    {
        _rigB.AddForce(Vector3.up * _jumpForce);
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
            Debug.Log("Dead");
            EndGame();            
        }
    }

    private void Initializations()
    {
        _rigB = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
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
            _rigB.transform.DOMoveX(_limiter, _sideMoveSpeed).OnComplete(() =>
            {
                _rightSide = false;
                _moving = false;
            });

        }
    }
    private void RightMove()
    {
        if (_rightSide == false && _moving == false)
        {
            _moving = true;
            _rigB.transform.DOMoveX(_limiter, _sideMoveSpeed).OnComplete(() =>
            {
                _rightSide = true;
                _moving = false;
            });

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
            Game_Controller.Instance.GameOver();
            StopCoroutine(GameOverDelay());
        }        
    }
}
