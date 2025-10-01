using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public GameObject laserprefab;
    public GameObject lasterholder;
    private float firerate = 0.5f;
    float canfire = -1f;
    [SerializeField]
    private int live = 3;
    private SpawnManager spawnManager;
    public bool istripleshot;
    public GameObject tripleshotprefab;
    public GameObject tripleshotholder;
    public bool isspeedActive;
    private float speedmultipleyer = 2;
    private bool isshieldActive;
    public GameObject shieldVisualiser;
    [SerializeField]
    private int score;
    private Uimanager UImanager;
    public GameObject leftengine, rightengine;
    public AudioClip lasersoundclip;
    public AudioSource audioSource;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.position = new Vector3(0,0, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        UImanager = GameObject.FindGameObjectWithTag("uimanager").GetComponent<Uimanager>();
        if (spawnManager == null)
        {
            Debug.LogError("spawn manager null");
        }
        if (UImanager == null)
        {
            Debug.LogError("uimanager is null");
        }
        if(audioSource == null)
        {
            Debug.LogError("audio source is null");
        }
        else
        {
            audioSource.clip = lasersoundclip;
        }
    }

    // Update is called once per frame
    void Update()

    {
        Movement();
        if (Input.GetKey(KeyCode.Space) && Time.time > canfire)
        {
            firelaser();
        }

    }
    void Movement()
    {

        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        
        Vector3 Direction = new Vector3(horizontalinput, verticalinput, 0);
        transform.Translate(Direction * speed * Time.deltaTime);


        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-11, transform.position.y, 0);
        }
        else if (transform.position.x <= -11)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }
    void firelaser()
    {
        
            canfire = Time.time + firerate;
          if (istripleshot == true)
         {
            Instantiate(tripleshotprefab,tripleshotholder.transform.position , Quaternion.identity);
         }
        else
         {
            Instantiate(laserprefab, lasterholder.transform.position, Quaternion.identity);
         }
          audioSource.Play();
         
            
        
    }
    public void Damage()
    {
        if(isshieldActive == true)
        {
            shieldVisualiser.SetActive(false);
            isshieldActive = false;
            return;
        }
        live--;
        
        if(live == 2)
        {
          leftengine.SetActive(true);   
        }
        else if(live == 1)
        {
            rightengine.SetActive(true);
        }
        UImanager.uppdatelife(live);
        if (live < 1)
        {
            
            Destroy(this.gameObject);
            spawnManager.onplayerDeath();
          

        }
    }
     public void trileshotactive()
    {
        istripleshot = true;
        StartCoroutine(Tripleshotpowerdownroutine());
    }
    IEnumerator Tripleshotpowerdownroutine()
    {
        yield return new WaitForSeconds(5);
        istripleshot = false;
    }
    public void speedBoostACive()
    {
        isspeedActive = true;
        speed *= speedmultipleyer;
        StartCoroutine(speedpowerupRoutine());
    }
    IEnumerator speedpowerupRoutine()
    {
       
        yield return new WaitForSeconds(5);
       isspeedActive = false;
        speed /= speedmultipleyer;
      
    }
    public void shieldActive()
    {
        isshieldActive = true;
        shieldVisualiser.SetActive(true);
    }
   public void addscore(int points)
    {
        score += points;
        UImanager.updatescore(score);
        Debug.Log("score is updating in the player movement");
    }
    
}
