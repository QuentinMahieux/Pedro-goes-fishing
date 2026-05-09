using UnityEngine;

[CreateAssetMenu(fileName = "WalkData", menuName = "Scriptable Objects/WalkData")]
public class WalkData : ScriptableObject
{
    [Header("Bucket")]
    public float speed = 2f;
    public float rotationIntensity = 0.001f;

    [Header("Player")] 
    public float playerIntensity = 0.005f;

}
