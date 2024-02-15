using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent; //transform perchè è l'unica cosa presente nell'Empty
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;
    ScoreBoard scoreBoard;

    void Start() 
    {
        //non usare FindAny.. in Update, prende troppe risorse
        //ad ogni enemy che compare gli passa lo script ScoreBoard
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    

    
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        //Non mettiamo = a 0 perchè potrebbe creare dei problemi
        if (hitPoints < 1) 
        {
            KillEnemy();
        }
        
    }

    void ProcessHit()
    {   
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent; //daremo come parent Il parent sopra agli Enemy
        hitPoints--; //HitPoints = HitPoints - 1;
         //Callback di una void public (ScoreBoard)
        scoreBoard.IncreaseScore(scorePerHit);
    }

    void KillEnemy()
    {
        ///Instatiate clona un oggetto 
        ///transform.position perchè è la posizione di Enemy
        ///Quaternion.identity fa si che la copia rimanga cosi senza rotazioni o movivementi
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent; //daremo come parent Il parent sopra agli Enemy
        Destroy(gameObject); //distruggiamo il gameObject a cui diamo questo script  
    }

  

}
