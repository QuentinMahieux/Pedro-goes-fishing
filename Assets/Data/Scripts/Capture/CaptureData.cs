using UnityEngine;

[CreateAssetMenu(fileName = "CaptureData", menuName = "Scriptable Objects/CaptureData")]
public class CaptureData : ScriptableObject
{
    public float timeTotal = 5f;
    public Target[] targets;
}

[System.Serializable]
public class Target
{
    public float timeTarget;
    public float WindowTarget = 0.5f;
    public GameObject targetObject;
}
