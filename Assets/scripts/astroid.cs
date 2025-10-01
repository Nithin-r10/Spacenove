using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astroid : MonoBehaviour
{
    [SerializeField]
   private int speed = 3;
    public GameObject explotion;
    private SpawnManager spawnManager;
  
    
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("spawnmanager").GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
           
            Instantiate(explotion,transform.position,Quaternion.identity);
            Destroy(this.gameObject,0.5f);
            
            spawnManager.startspwn();
            Destroy(collision.gameObject);
            
        }
        
    }
}
