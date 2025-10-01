using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class Uimanager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoretext;
    [SerializeField]
    private Image _Liveimage;
    public Sprite[]  livesprites;
    [SerializeField]
    private TMP_Text Gameover;
    [SerializeField]    
    private TMP_Text presssR;
    private Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "score:" + 0;
        Gameover.gameObject.SetActive(false); ;
        presssR.gameObject.SetActive(false); ;
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Manager>();
    }
    public void updatescore(int playerscore)
    {
        scoretext.text = "score : " + playerscore;
        Debug.Log("score is working");
    }
    public void uppdatelife(int currnetLives)
    {
        _Liveimage.sprite = livesprites[currnetLives];
        if (currnetLives == 0)
        {
            manager.isgameover();
            gameoversequance();
           
        }
    }
    public void gameoversequance()
    {
        Gameover.gameObject.SetActive(true);
        presssR.gameObject.SetActive(true);
        StartCoroutine(Gameoverflicker());
    }
    IEnumerator Gameoverflicker()
    {
        while (true)
        {
            Gameover.text = "GAME OVER";
            presssR.text = "press R to restart ";
            yield return new WaitForSeconds(0.5f);
            Gameover.text = "";
            presssR.text = "";
            yield return new WaitForSeconds(0.5f);
           
        }
       
    }

   
}
