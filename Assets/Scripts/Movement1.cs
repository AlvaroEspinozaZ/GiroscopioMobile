using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement1 : MonoBehaviour
{
    [SerializeField] private float velocityForward=0;
    [SerializeField] private Stats myStats;
    [SerializeField] private Transform target;    
    public bool movimiento;
    [SerializeField] private float inclinacion=0;
    private Vector3 angulos;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;

    void Start()
    {
       
    }

    void Update()
    {
        if (movimiento)
        {
            // // Obtener la rotación del giroscopio del dispositivo
            // Vector3 rotationRate = Input.gyro.rotationRateUnbiased;

            // // Ajustar la rotación de la nave en el eje X según la rotación del giroscopio
            //transform.position =new Vector3(transform.position.x ,rotationRate.z * velocity * Time.deltaTim, transform.position.z);;
            if (Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x + (myStats.velocityX * Time.deltaTime), transform.position.y +(myStats.velocityY * Time.deltaTime), transform.position.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x - (myStats.velocityX * Time.deltaTime), transform.position.y - (myStats.velocityY * Time.deltaTime), transform.position.z);
            }
        }
        Rotation();
    }
    void Rotation()
    {
        angulos.y = angulos.y + velocityForward * Time.deltaTime;
        //rotation z-> x -> y
        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.z * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.z * 0.5f);
        qz.Set(0, 0, anguloSen, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.x * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.x * 0.5f);
        qx.Set(anguloSen, 0, 0, anguloCos);

        anguloSen = Mathf.Sin(Mathf.Deg2Rad * angulos.y * 0.5f);
        anguloCos = Mathf.Cos(Mathf.Deg2Rad * angulos.y * 0.5f);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * qx * qz;

        transform.rotation = r;
    }

    
}
