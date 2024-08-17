using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 0.1f; 
    public Vector2 minBounds; 
    public Vector2 maxBounds; 

    private Vector3 lastMousePosition;

    private void Update()
    {
        
        if (Input.GetMouseButton(0)) 
        {
      
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 direction = mousePosition - lastMousePosition;

        
            Vector3 newPosition = transform.position - direction * speed;

    
            newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
            newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

            transform.position = newPosition;
        }

        lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
