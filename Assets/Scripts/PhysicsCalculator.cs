using UnityEngine;

public static class PhysicsCalculator
{
    public static float CalculateForce(float mass, float acceleration)
    {
        return mass * acceleration;
    }

    public static float CalculateImpulse(float mass, float speed)
    {
        return mass * speed;
    }

    public static float CalculatePressure(float density, float gravity, float height)
    {
        return density * gravity * height;
    }

    public static float CalculateGravitationalForce(float mass1, float mass2, float distance, float gravitationalConstant)
    {
        return gravitationalConstant * (mass1 * mass2) / (distance * distance);
    }

    public static float CalculateFinalVelocity(float initialVelocity, float acceleration, float time)
    {
        return initialVelocity + acceleration * time;
    }
}