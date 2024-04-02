using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivePlayer : MonoBehaviour
{
    [SerializeField] public Stats myStats;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            myStats.VidaMax = myStats.VidaMax - 25;
            Destroy(other.gameObject);
        }
    }
}
