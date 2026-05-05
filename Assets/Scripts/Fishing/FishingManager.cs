using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public static FishingManager instance;
    
    public FishIA fishIA;
    public FishData fishData;
    [Tooltip("Ordre dans lequel le poisson va se cacher derrier un rocher")]
    public Hideout[]  hideouts;
    public int currentHideout;

    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("[FishingManager] More than one FishingManager in scene!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        InstanciateHideout();
        
        fishIA = FishIA.instance;
    }
    
    void InstanciateHideout()
    {
        foreach (Hideout hideout in hideouts)
        {
            hideout.SetFish(false);
        }
        
        currentHideout = 0;
        hideouts[currentHideout].SetFish(true,  fishIA);
        fishIA.transform.position = hideouts[currentHideout].transform.position;
    }

    public void ChangeHideout()
    {
        hideouts[currentHideout].SetFish(false);
        currentHideout++;
        if (currentHideout >= hideouts.Length)
        {
            currentHideout = 0;
        }
        fishIA.Move(hideouts[currentHideout].transform.position);
    }

    public void NewHideout()
    {
        hideouts[currentHideout].SetFish(true,   fishIA);
    }
}
