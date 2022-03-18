using UnityEngine;

[RequireComponent(typeof(PhysicBody))]
public class Rocket : MonoBehaviour
{
    private PhysicBody physicBody;

    public float massFuel;
    public float impulse;
    public float effectiveExhaustVelocity;

    private void Awake()
    {
        physicBody = GetComponent<PhysicBody>();
    }

    private void Start()
    {
        physicBody.mass += massFuel;  
    }

    private void FixedUpdate()
    {
        if (massFuel > CurrentExhaustMassFlow())
        {
            massFuel -= CurrentExhaustMassFlow();
            physicBody.mass -= CurrentExhaustMassFlow();
            physicBody.AddForce(ForceVector());
        }
    }

    private float CurrentExhaustMassFlow()
    {
        float exhaustMassFlow;

        exhaustMassFlow = impulse / effectiveExhaustVelocity;
        return exhaustMassFlow * Time.deltaTime;
    }

    private Vector3 ForceVector()
    {
        return new Vector3(0, 1, 0) * impulse;
    }
}
