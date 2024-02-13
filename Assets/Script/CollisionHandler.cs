using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
      //void OnCollisionEnter(Collision other) 
      //{Debug.Log(this.name + "--Collided with--" + other.gameObject.name);}

      //void OnTriggerEnter(Collider other) 
      //{Debug.Log($"{this.name} **Triggered By** {other.gameObject.name}"); //è la stessa cosa di sopra}
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem deathParticles;


   
    void OnTriggerEnter(Collider other)
    {
        
        StartCrashSequence();
    }

    void StartCrashSequence()
    {   
        
        deathParticles.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<PlayerControl>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    { 
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }
}
