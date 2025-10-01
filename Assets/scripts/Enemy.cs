using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    float speed = 4f;
    private PlayerMovement _player;
    public Animator anima;
    [SerializeField]
    private AudioSource audioplayer;



     void Start()
    {
        audioplayer = GetComponent<AudioSource>();


        if (!_player)
        {
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        }
       
       anima = GetComponent<Animator>();
        
        if(anima == null )
        {
            Debug.LogError("animator component is missing");
        }
    }

    void Update()
    {
       
      
        transform.Translate(Vector3.down* speed *Time.deltaTime);
        if (transform.position.y <= -5f)
        {
            float randomx = Random.Range(-8, 8);    
            transform.position = new Vector3(randomx, 7, 0);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 0;
            anima.SetTrigger("onenemydeth");
            audioplayer.Play();
            Destroy(this.gameObject,2.5f);

        }
        if (collision.tag == "laser")
        {
            speed = 0;
            anima.SetTrigger("onenemydeth");
            audioplayer.Play();
            Destroy(this.gameObject,2.5f);
            
            Destroy(collision.gameObject);
            
            
                _player.addscore(10);
                Debug.Log("score is updating in enemy script");
            
        }
        PlayerMovement play = collision.GetComponent<PlayerMovement>();
        if (play != null)
        {
            play.Damage();
        }
    }
}
