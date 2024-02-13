using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathVFX;
   [SerializeField] Transform parent; //transform perchè è l'unica cosa presente nell'Empty

    void OnParticleCollision(GameObject other) 
    {
        ///Instatiate clona un oggetto 
        ///transform.position perchè è la posizione di Enemy
        ///Quaternion.identity fa si che la copia rimanga cosi senza rotazioni o movivementi
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent; //daremo come parent Il parent sopra agli Enemy
        Destroy(gameObject); //distruggiamo il gameObject a cui diamo questo script  
    }
    

}
