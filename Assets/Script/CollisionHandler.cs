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
      void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        GetComponent<PlayerControl>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }

    void ReloadLevel()
    {
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(currentSceneIndex);
    }
}
