using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathVFX;

    void OnParticleCollision(GameObject other) 
    {
        ///Instatiate clona un oggetto 
        ///transform.position perchè è la posizione di Enemy
        ///Quaternion.identity fa si che la copia rimanga cosi senza rotazioni o movivementi
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject); //distruggiamo il gameObject a cui diamo questo script  
    }
    

}
