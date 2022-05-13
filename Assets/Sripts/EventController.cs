using System;
using UnityEngine;

public static class EventController
{
    public static Action<float> onTimerStarted;
    public static Action onTimerOver;
    public static Action<GameObject> onPickedIngredient;
    public static Action<GameObject, GameObject> onCraftStarted;
    public static Func<GameObject> onGeneratedIngredient;
}
