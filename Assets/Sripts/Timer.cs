using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private bool _isTimerStarted = false;

    private void OnEnable()
    {
        EventController.onTimerStarted += StartTimer;
    }

    private void OnDisable()
    {
        EventController.onTimerStarted -= StartTimer;
    }

    private void StartTimer(float time)
    {
        _isTimerStarted= true;
        StartCoroutine(StartCountdown(time));
    }

    private IEnumerator StartCountdown(float time)
    {
        yield return new WaitForSeconds(time);
        ReadyForSpawn();
    }
    private void ReadyForSpawn()
    {
        _isTimerStarted = false;
        EventController.onTimerOver?.Invoke();
    }
}
