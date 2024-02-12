using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [Header("General Setup Settings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;
    
    [Tooltip("How fast ship moves up and down")]  [SerializeField] float controlSpeed = 10f;
    [Tooltip("How far player moves horizontally")] [SerializeField] float xRange = 10f;
    [Tooltip("How far player moves vertically")] [SerializeField] float yRange = 7f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] GameObject[] lasers; //in C# si dichiara così che GameObject sarà un Array di oggetti

    [Header("Screen position based tuning")]
    [SerializeField] float positionPitchFactor = 0.5f;
    [SerializeField] float positionYawFactor = -1.5f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -7f;
    [SerializeField] float controlRollFactor = -15f;
    float xThrow, yThrow;
   
   

    void OnEnable() 
    {
        movement.Enable();
        fire.Enable();
    }

    void OnDisable() 
    {
        movement.Disable();
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float VerticalThrow = Input.GetAxis("Vertical");
    }

   void ProcessRotation()
{   
    // Calcola l'inclinazione (pitch), la virata (yaw) e il rollio (roll) dell'oggetto in base alla posizione e all'input del giocatore.

    // Calcola l'inclinazione dovuta alla posizione dell'oggetto lungo l'asse Y moltiplicato per un fattore di inclinazione basato sulla posizione.
    float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
    
    // Calcola l'inclinazione dovuta all'input di controllo (ad esempio, input dell'utente tramite joystick o tastiera) moltiplicato per un fattore di inclinazione basato sul controllo.
    float pitchDueToControlThrow = yThrow * controlPitchFactor;

    // Somma le inclinazioni dovute alla posizione e all'input di controllo per ottenere l'inclinazione finale lungo l'asse Y.
    float pitch = pitchDueToPosition + pitchDueToControlThrow;

    // Calcola la virata (yaw) dell'oggetto in base alla sua posizione lungo l'asse X moltiplicato per un fattore di virata basato sulla posizione.
    float yaw = transform.localPosition.x * positionYawFactor;

    // Calcola il rollio (roll) dell'oggetto in base all'input di controllo (ad esempio, input dell'utente tramite joystick o tastiera) moltiplicato per un fattore di rollio basato sul controllo.
    float roll = xThrow * controlRollFactor;

    // Applica la rotazione calcolata all'oggetto utilizzando Quaternion.Euler per ottenere una rotazione specificata da angoli di Eulero.
    transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
}

void ProcessTranslation()
{
    //New Input
    // Legge l'input di movimento del giocatore lungo gli assi X e Y.
    xThrow = movement.ReadValue<Vector2>().x;
    yThrow = movement.ReadValue<Vector2>().y;

    // Calcola lo spostamento laterale lungo l'asse X basato sull'input di movimento e sulla velocità di controllo.
    float xOffset = xThrow * Time.deltaTime * controlSpeed;
    
    // Calcola la nuova posizione X grezza sommando lo spostamento laterale al valore corrente della posizione X dell'oggetto.
    float rawXPos = transform.localPosition.x + xOffset;
    
    // Limita la nuova posizione nel Range X
    float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

    // Calcola lo spostamento verticale lungo l'asse Y basato sull'input di movimento e sulla velocità di controllo.
    float yOffset = yThrow * Time.deltaTime * controlSpeed;
    
    // Calcola la nuova posizione Y grezza sommando lo spostamento verticale al valore corrente della posizione Y dell'oggetto.
    float rawYPos = transform.localPosition.y + yOffset;
    
    // Limita la nuova posizione nel Range Y.
    float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

    // Aggiorna la posizione locale dell'oggetto con la nuova posizione X e Y calcolata, mantenendo la stessa posizione lungo l'asse Z.
    transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
}


    void ProcessFiring()
{   
    //old input
    //if (Input.GetButton("Fire1"))
     //New Input
    if(fire.ReadValue<float>() > 0.5)
        {
            SetLasersActive(true); //leggere dopo setlaseractive... qui è true
        }
        else
        {
             SetLasersActive(false); //leggere dopo setlaseractive... qui è false
        }
    }

     void SetLasersActive(bool isActive) //essendo questa un bool quando la chiami potra essere solo true or false
    {
        foreach (GameObject laser in lasers) //laser del gruppo di lasers, birillo del gruppo di birilli
        { 
            var emissionModule = laser.GetComponent<ParticleSystem>().emission; //gli diamo una variabile per comodità e prendiamo emission che fa parte di ParticleSystem
            emissionModule.enabled = isActive; //Emission.enabled vuol dire è attivo quindi =  isActive, quando la passiamo decidiamo se è true o false
        } 
    }
}
