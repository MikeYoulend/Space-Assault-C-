using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;
    ScoreBoard scoreBoard;
    GameObject ParentGameObject;

    void Start()
    {
        //non usare FindAny.. in Update, prende troppe risorse
        //ad ogni enemy che compare gli passa lo script ScoreBoard
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //Con questo abbiamo dato al vfx delle navicelle un posto dove andare nella gerarchia
        ParentGameObject = GameObject.FindWithTag("SpawnAtRuntime"); 
        AddRigidbody();
    }

    private void AddRigidbody()
    {
        //Definiamo rb
        //prendiamo questo gameObject e aggiungiamoci RigidBody
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        //Disattiviamo la gravità
        rb.useGravity = false;
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
        vfx.transform.parent = ParentGameObject.transform; //la posizione sarà la stessa del ParentGameObject
        hitPoints--; //HitPoints = HitPoints - 1;
         
    }

    void KillEnemy()
    {
        //Callback di una void public (ScoreBoard)
        scoreBoard.IncreaseScore(scorePerHit);
        ///Instatiate clona un oggetto 
        ///transform.position perchè è la posizione di Enemy
        ///Quaternion.identity fa si che la copia rimanga cosi senza rotazioni o movivementi
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = ParentGameObject.transform; //daremo come parent Il parent sopra agli Enemy
        Destroy(gameObject); //distruggiamo il gameObject a cui diamo questo script  
    }

  

}
