using UnityEngine;

[CreateAssetMenu(fileName = "PhysicsConstants", menuName = "Physics/Constants")]
public class PhysicsConstants : ScriptableObject
{
    public float gravitationalConstant = 9.8f; // Ускорение свободного падения
    public float universalGravitationalConstant = 6.67e-11f; // Гравитационная постоянная
}