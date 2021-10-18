using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour
{
    private Rigidbody RigB;
    private Animator Anim;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask floorMask;
    void Start()
    {
        Initializations();
    }

    
    void Update()
    {
        Moviment();
    }

    private void Initializations()
    {
        RigB = GetComponent<Rigidbody>();
        Anim = GetComponent<Animator>();
    }
    private void Moviment()
    {
        RigB.transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    private bool GroundCheck()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * .1f, Color.red);

        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, .1f, floorMask))
        {
            return true;
        }
        return false;
    }
}
