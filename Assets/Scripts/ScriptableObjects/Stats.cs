using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Naves", menuName = "ScriptableObject/Naves/StatsNave", order = 1)]
public class Stats : ScriptableObject
{   
    [SerializeField] public int VidaMax;
    [SerializeField] public float velocityY;
    [SerializeField] public float velocityX;
    public void SetStatss(Stats stat)
    {
        VidaMax = stat.VidaMax;
        velocityX = stat.velocityX;
        velocityY = stat.velocityY;
    }
}
