using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
public class SensitivePlayer : MonoBehaviour
{
    [SerializeField] public Stats myStats;
    public Action Muerte;
    private void Awake()
    {
        Muerte = UpdateLife;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Muerte?.Invoke();
            
            other.gameObject.SetActive(false);
        }
    }
    public void UpdateLife()
    {
        myStats.VidaMax = myStats.VidaMax - 25;
        if (myStats.VidaMax <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
