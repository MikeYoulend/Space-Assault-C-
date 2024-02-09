using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 7f;

    [SerializeField] float positionPitchFactor = -2f;

    float xThrow, yThrow;
   

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
        ProcessTranslation();
        ProcessRotation();

        //float horizontalThrow = Input.GetAxis("Horizontal");
        //float VerticalThrow = Input.GetAxis("Vertical");
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow;
        float yaw = 0f;
        float roll = 0f;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3
        (clampedXPos,
        clampedYPos,
        transform.localPosition.z);
    }
}
