using UnityEngine;

public class InitCrafting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            EventController.onCraftStarted?.Invoke(transform.gameObject, other.transform.gameObject);
        }
    }
}
