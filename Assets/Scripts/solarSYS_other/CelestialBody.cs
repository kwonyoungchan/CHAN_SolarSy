using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    public Vector3 initialAcc;
    public Vector3 currentVelocity { get; private set; }

    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        currentVelocity = initialVelocity;
    }
    public void UpdateVelocity(CelestialBody[] allBodys)
    { 
        foreach(CelestialBody otherBody in allBodys)
        {
            if (otherBody != this)
            {
                // r ����
                float sqrDst = (otherBody.rb.position - rb.position).sqrMagnitude;
                // ���� ���� ����
                Vector3 forceDir = (otherBody.rb.position - rb.position).normalized;
                //���� �� ����
                Vector3 force = forceDir * Universe.gravitationalConstant * mass * otherBody.mass / (sqrDst);
                //���ӵ� ����
                Vector3 acc = force/mass ;
                //�ӵ� ����
                currentVelocity += acc * Time.fixedDeltaTime;
                
            }
        }
      
    }
    public void UpdateVelocity()
    {
        currentVelocity += initialAcc * Time.fixedDeltaTime;
    }
    public void UpdatePosition()
    {
        rb.position += currentVelocity * Time.fixedDeltaTime;
    }
}
