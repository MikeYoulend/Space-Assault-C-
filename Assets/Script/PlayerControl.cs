using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 10f;

    void OnEnable() 
    {
        movement.Enable();
    }

    void OnDisable() {
        movement.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float YThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float newXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3 
        (newXPos, 
        transform.localPosition.y, 
        transform.localPosition.z);
        
       //float horizontalThrow = Input.GetAxis("Horizontal");
       
       //float VerticalThrow = Input.GetAxis("Vertical");
    }
}
