using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Day[] days;
    public int currentDay;
    
    public FishingManager fishingManager;
    public CaptureManager captureManager;
    
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[GameManager] More than one FishingManager in scene!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        captureManager.gameObject.SetActive(false);
        fishingManager.gameObject.SetActive(false);
        
        
        MapToFising();
    }

    public void MapToFising()
    {
        fishingManager.gameObject.SetActive(true);
        fishingManager.Instanciate();
    }
    
    public void FishingToCapture()
    {
        fishingManager.gameObject.SetActive(false);
        captureManager.gameObject.SetActive(true);
        
        captureManager.Instanciat();
    }

    public void CaptureToFishing()
    {
        captureManager.StopAllCoroutines();
        captureManager.gameObject.SetActive(false);
        
        fishingManager.gameObject.SetActive(true);
        //fishingManager.Instanciate();
    }
}

[System.Serializable]
public class Day
{
    public FishData fishData;
    public CaptureData captureData;
}
