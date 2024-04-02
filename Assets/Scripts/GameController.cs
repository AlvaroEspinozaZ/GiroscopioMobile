using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    [SerializeField] Slider BarraVida;
    [SerializeField] Text Score;
    [SerializeField] Text Vida;
    //[SerializeField] private Stats myStats;
    float scoreTime=0;
    [SerializeField] private GameObject posInit;
    [SerializeField] private GameObject[] target;
    Transform targetFijo;
    [SerializeField] private GameObject[] Enemys;
    [SerializeField] private float vidaEnPorcentaj=0;
    private void Awake()
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].activeSelf)
            {
                targetFijo = target[i].transform;
            }
        }
    }
    void Start()
    {
        StartCoroutine(SpamearEnmys());
       
    }

    // Update is called once per frame
    void Update()
    {
       
        scoreTime += Time.deltaTime;
        Score.text = "Score: " + (int)scoreTime;
        vidaEnPorcentaj = (targetFijo.GetComponent<SensitivePlayer>().myStats.VidaMax/ 100f);
        Vida.text = vidaEnPorcentaj.ToString("P0");
        BarraVida.value = vidaEnPorcentaj;
        if(targetFijo.GetComponent<SensitivePlayer>().myStats.VidaMax <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    IEnumerator SpamearEnmys()
    {
        Debug.Log("dasdqw");        
        Vector3 position = new Vector3(posInit.transform.localPosition.x+ 1, posInit.transform.position.y, posInit.transform.localPosition.z +1);
        int id = Random.Range(0, 2);
        float intervalo = Random.Range(1.2f, 4.3f);
        GameObject tmp = Instantiate(Enemys[id], posInit.transform.position, Quaternion.identity);
        tmp.GetComponent<MoveToPlayer>().target = targetFijo;
        Destroy(tmp, 6f);
        yield return new WaitForSecondsRealtime(intervalo);
        StartCoroutine(SpamearEnmys());
    }
}
