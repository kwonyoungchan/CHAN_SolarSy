using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBodySimulation : MonoBehaviour
{
    CelestialBody[] bodies;
    private void Awake()
    {
        bodies = FindObjectsOfType<CelestialBody>();

    }
    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity();
            bodies[i].UpdateVelocity(bodies);
        }
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition();
        }

    }
}
