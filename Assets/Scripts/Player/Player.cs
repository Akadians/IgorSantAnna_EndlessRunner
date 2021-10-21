using System.Collections;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _floorMask;
    [SerializeField] private float _jumpForce;
    [SerializeField] [Range(0, 20)] private float _limiter;
    [SerializeField] [Range(0, 10)] private float _sideMoveSpeed;
    [SerializeField] [Range(-1, 1)] private int _position;
    [SerializeField] private bool _moving = false;
    private Rigidbody _rigB;
    private Animator _anim;

    public void Jump()
    {


        _rigB.AddForce(Vector3.up * _jumpForce);

    }
    public void ChangeLine(string side)
    {
        if (side == "Left")
        {
            Debug.Log("Esquerda");
            StartCoroutine(LeftMove(_position));
        }
        else if (side == "Right")
        {
            StartCoroutine(RightMove(_position));
            Debug.Log("Direita");
        }
    }

    private void Start()
    {
        Initializations();
    }

    private void Update()
    {
        Moviment();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            //Endgame();
            Debug.Log("Dead");
            _speed = 0;
            _anim.SetBool("isDead", true);
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

    private IEnumerator LeftMove(int position)
    {
        if (position >= 0 && _moving == false)
        {
            for (float i = 0; i < _limiter; i += 0.1f)
            {
                _moving = true;
                _rigB.transform.position += Vector3.left * Time.deltaTime * _sideMoveSpeed;
                yield return null;
            }
        }

        StopCoroutine("LeftMove");
        _position--;
        _moving = false;
    }
    private IEnumerator RightMove(int position)
    {
        if (position <= 0 && _moving == false)
        {
            for (float i = 0; i < _limiter; i += 0.1f)
            {
                _moving = true;
                _rigB.transform.position += Vector3.right * Time.deltaTime * _sideMoveSpeed;
                yield return null;
            }
        }

        StopCoroutine("RightMove");
        _position++;
        _moving = false;
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
}