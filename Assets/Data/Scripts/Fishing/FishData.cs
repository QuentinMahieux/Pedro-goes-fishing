using UnityEngine;

[CreateAssetMenu(fileName = "FishData", menuName = "Scriptable Objects/FishData")]
public class FishData : ScriptableObject
{
    [Header("Information")]
    public string fishName;
    public string description;
    public Sprite sprite;
    
    [Header("Variables")]
    public float speed = 5f;
}
