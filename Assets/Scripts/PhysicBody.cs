using UnityEngine;

public class PhysicBody : MonoBehaviour
{
    public float mass;
    [HideInInspector] public Vector3 velocity;

    private void FixedUpdate()
    {
        SetVelocity();
    }

    public void AddForce(Vector3 forceVector)
    {
        Vector3 accelerationVector = forceVector / mass;
        velocity += accelerationVector * Time.deltaTime;
    }

    private void SetVelocity()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
