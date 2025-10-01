using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerups : MonoBehaviour
{
    public float speed = 3;
    [SerializeField]
    private int powerupid;

   
    public AudioClip clip;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
          AudioSource.PlayClipAtPoint(clip,transform.position);
            if (player != null)
            {


                switch (powerupid)
                {
                    case 0:
                        {
                            player.trileshotactive();
                        }
                        break;
                    case 1:
                        {
                            player.speedBoostACive();
                          
                        }
                        break;
                    case 2:
                        {
                            player.shieldActive();

                        }
                        break;
                     default:
                        {
                            Debug.Log("no other case");
                            break;
                        }
                }
                Destroy(this.gameObject);
            }
        }
    }
    
       
}
