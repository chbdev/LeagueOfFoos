using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_Time;
    private bool m_Running;

    public Timer(float time)
    {
        SetTime(time);
    }

    private void Update()
    {
        m_Time -= Time.deltaTime;
        m_Time = Mathf.Clamp(m_Time, 0.0f, float.MaxValue);
    }

    public void SetTime(float time)
    {
        m_Time = time;
    }
    public void Play()
    {
        m_Running = true;
    }
    public void Stop()
    {
        m_Running = false;
    }
    public bool IsElapsed()
    {
        return m_Time <= 0.0f;
    }
}
