using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Drive : MonoBehaviour {

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    private float rotationSpeed = 30.0f;
    [SerializeField]
    private float jumpSpeed = 5.0f;

    bool isgrounded = true;

    void Update()
    {
        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;
        float jumping = Input.GetAxis("Jump") * jumpSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        jumping *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        transform.Translate(0, jumping, 0);

    }
}
