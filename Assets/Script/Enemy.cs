using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other) 
    {
            Destroy(gameObject); //distruggiamo il gameObject a cui diamo questo script
            Debug.Log($"{this.name}im hit by {other.gameObject.name}");
    }
    

}
