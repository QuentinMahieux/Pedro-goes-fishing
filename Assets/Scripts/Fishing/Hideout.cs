using JetBrains.Annotations;
using UnityEngine;

public class Hideout : MonoBehaviour
{
    public FishIA fishIa;

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
}
