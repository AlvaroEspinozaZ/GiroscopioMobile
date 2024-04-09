using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Slider BarraVida;
    [SerializeField] Text Score;
    [SerializeField] Text Vida;
    //[SerializeField] private Stats myStats;
    float scoreTime=0;
    [SerializeField] private GameObject posInit;
    [SerializeField] private GameObject[] target;
    [SerializeField] Transform targetFijo;
    [Header("ObjectPullingEnemy")]
    [SerializeField] private GameObject[] Enemys;
    [SerializeField] private Transform padre;
    [SerializeField] private int idObj;
    [SerializeField] private float numeroEnemysInObj=10;
    [SerializeField] private List<GameObject> enemysObjInScene = new List<GameObject>();
    [Header("PorcentajeVida")]
    [SerializeField] private float vidaEnPorcentaj=0;
    [SerializeField] bool spamear = false;
    private void Awake()
    {
        DecidirQueNaveEsElObjetivo();
    }
   
    void Start()
    {
        CrearLosObjetosDelObjectPulling();
        StartCoroutine(ActivarEnemysObjectPulling());
       
    }
   
    // Update is called once per frame
    void Update()
    {
       
        scoreTime += Time.deltaTime;
        Score.text = "Score: " + (int)scoreTime;
        //Vida en UI
        vidaEnPorcentaj = (targetFijo.GetComponent<SensitivePlayer>().myStats.VidaMax/ 100f);
        Vida.text = vidaEnPorcentaj.ToString("P0");
        BarraVida.value = vidaEnPorcentaj;
    }
    void DecidirQueNaveEsElObjetivo()
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (target[i].activeInHierarchy)
            {
                Debug.Log("Esta activo " + target[i].activeInHierarchy);
                targetFijo = target[i].transform;
            }
        }
    }
    void CrearLosObjetosDelObjectPulling()
    {
        for (int i = 0; i < numeroEnemysInObj; i++)
        {
            int id = Random.Range(0, 2);
            GameObject objeto = Instantiate(Enemys[id], posInit.transform.position, Quaternion.identity, padre);
            objeto.GetComponent<MoveToPlayer>().target = targetFijo;
            objeto.GetComponent<MoveToPlayer>().Esconderse += PosicionPadre;
            objeto.SetActive(false);
            enemysObjInScene.Add(objeto);
        }
    }
    IEnumerator SpamearEnmys()
    {        
        Vector3 position = new Vector3(posInit.transform.localPosition.x+ 1, posInit.transform.position.y, posInit.transform.localPosition.z +1);
        int id = Random.Range(0, 2);
        float intervalo = Random.Range(1.2f, 4.3f);
        if (spamear) {
            GameObject tmp = Instantiate(Enemys[id], posInit.transform.position, Quaternion.identity);
            tmp.GetComponent<MoveToPlayer>().target = targetFijo;
            Destroy(tmp, 6f);
        }        
        yield return new WaitForSecondsRealtime(intervalo);
        StartCoroutine(SpamearEnmys());
    }

    IEnumerator ActivarEnemysObjectPulling()
    {
        idObj = (idObj + 1) % enemysObjInScene.Count;
        enemysObjInScene[idObj].SetActive(true);
        float intervalo = Random.Range(1.2f, 4.3f);       
        StartCoroutine(Esconder(enemysObjInScene[idObj]));
        yield return new WaitForSecondsRealtime(intervalo);
        StartCoroutine(ActivarEnemysObjectPulling());
    }
    IEnumerator Esconder(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(6f);
        obj.SetActive(false);
        obj.transform.position = posInit.transform.position;
    }
    void PosicionPadre(MoveToPlayer enemysObjInScene)
    {
        enemysObjInScene.gameObject.transform.position = posInit.transform.position; 
    }
}
