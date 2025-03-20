using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public Transform background;
    public float speed = 0.1f;
    public float mouseSpeed = 15f;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Mobile Camera Movement
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(-touchDeltaPosition.x * speed * Time.deltaTime, -touchDeltaPosition.y * speed * Time.deltaTime, 0);
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                background.position -= new Vector3(0,
                                           Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed * 0.8f,
                                           0);
                // Camera Movement
                transform.position -= new Vector3(0,
                                           Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed,
                                           0);
                // Camera Limitations
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -35f, 8f), transform.position.z);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                background.position -= new Vector3(0,
                                           Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed * 0.8f,
                                           0);
                // Camera Movement
                transform.position -= new Vector3(0,
                                           Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseSpeed,
                                           0);
                // Camera Limitations
                transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -35f, 8f), transform.position.z);
            }
        }
        
    }
}
