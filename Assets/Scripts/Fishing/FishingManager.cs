using UnityEngine;

public class FishingManager : MonoBehaviour
{
    public static FishingManager instance;
    
    [Header("Hideouts")]
    public FishIA fishIA;
    [HideInInspector] public FishData fishData;
    [Tooltip("Ordre dans lequel le poisson va se cacher derrier un rocher")]
    public Hideout[]  hideouts;
    public int currentHideout;
    
    [Header("landing net")]
    public bool isCurrentLanding;

    public Texture2D landingCursor;
    public Texture2D defaultCursor;

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
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }

    public void Instanciate()
    {
        InstanciateHideout();
        
        fishData = GameManager.instance.days[GameManager.instance.currentDay].fishData;
        fishIA = FishIA.instance;
    }
    
    //Instancie les cailloux
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

    //Change le cailloux sous lequel et le poisson
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

    //Définit un nouveau cailloux
    public void NewHideout()
    {
        
        //Verifit si le poisson a été capturer
        if (hideouts[currentHideout].isLanding)
        {
            GameManager.instance.FishingToCapture();
        }
        else
        {
            RemoveLanding();
        }
        
        hideouts[currentHideout].SetFish(true,   fishIA);
    }

    public void TakeLanding()
    {
        RemoveLanding();
        
        isCurrentLanding = true;
        Cursor.SetCursor(landingCursor, Vector2.zero, CursorMode.Auto);
    }

    public void RemoveLanding()
    {
        foreach (Hideout hideout in hideouts)
        {
            hideout.SetLanding(false);
        }
    }

    public void PlaceLanding(Hideout hideout)
    {
        isCurrentLanding = false;
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
        
        hideout.SetLanding(true);
    }
}
