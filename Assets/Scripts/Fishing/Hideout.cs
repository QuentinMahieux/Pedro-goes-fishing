using JetBrains.Annotations;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    public FishIA fishIa;
    public GameObject landingObject;
    public bool isLanding;

    void OnEnable()
    {
        landingObject.SetActive(false);
        isLanding = false;
    }
    public void Raising()
    {
        if (!fishIa) return;
        FishingManager.instance.ChangeHideout();
    }

    public void SetFish(bool isSet, [CanBeNull] FishIA fish = null)
    {
        if(isSet) fishIa = fish;
        else fishIa = null;
    }

    public void SetLanding(bool isSet)
    {
        isLanding = isSet;
        landingObject.SetActive(isSet);
    }
}
