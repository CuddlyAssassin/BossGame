using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public Transform defaultLooking;

    public Transform ballObject;

    public float rangeSet;
    public float lookRange;
    public float damping;
    public float smoothSpeed = 0.125f;

    bool ballNear = false;
    public Vector3 offset;


    void FixedUpdate()
    {
        lookRange = Vector3.Distance(ballObject.position, transform.position);

        LookAtMe();

        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        LookAtObject();
    }

    void LookAtObject()
    {
        if (ballNear == false)
        {
            Quaternion rotation = Quaternion.LookRotation(defaultLooking.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        } else
        {
            Quaternion rotation = Quaternion.LookRotation(ballObject.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }

    void LookAtMe()
    {
        if (lookRange < rangeSet)
        {
            ballNear = true;
        }

        if (lookRange > rangeSet)
        {
            ballNear = false;
        }
    }

}
