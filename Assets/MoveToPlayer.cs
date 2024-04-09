using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoveToPlayer : MonoBehaviour
{
    public Vector3 posInit;
    public Transform target;
    public Action<MoveToPlayer> Esconderse;
    [SerializeField] float speed = 5f;
    private Rigidbody rb;
    private void Awake()
    {
        posInit = transform.position;
        if (target == null)
            target= transform;
        // Obtener la referencia al Rigidbody del objeto
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 horizontalDirection = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;

        // Calcular la velocidad en la dirección hacia el objetivo
        Vector3 velocity = horizontalDirection * speed;

        // Aplicar la velocidad al Rigidbody del objeto
        rb.velocity = velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Esconderse?.Invoke(this);
        }
    }
}
