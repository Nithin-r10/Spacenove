using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject container;
    private bool stopspwn;
    
    [SerializeField]
    private GameObject []powerups;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void startspwn()
    {
        StartCoroutine(spwnenemyRoutine());
        StartCoroutine(spwnpowerroutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator spwnenemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (stopspwn == false)
        {
           
            Vector3 rand = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newenemy =   Instantiate(enemy,rand, Quaternion.identity);
            newenemy.transform.parent = container.transform;
            yield return new WaitForSeconds(5f);

        }
    }
    IEnumerator spwnpowerroutine()
    {
        yield return new WaitForSeconds(3f);
        while (stopspwn == false)
        {
            int Randompowerups = Random.Range(0, 3);
            Vector3 randomSpwn = new Vector3(Random.Range(-8, 8), 7, 0);
            Instantiate(powerups[Randompowerups], randomSpwn, Quaternion.identity);
            yield return new WaitForSeconds(8);
        }

    }
    public void onplayerDeath()
    {
        stopspwn = true;
        Debug.Log("stopped enemy spawn");
    }
   
}
