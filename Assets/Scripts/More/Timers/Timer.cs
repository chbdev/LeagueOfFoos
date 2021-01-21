using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    private float m_Time;
    private bool m_Running = true;

    public Timer(float time)
    {
        SetTime(time);
    }
    public void Update(float dt)
    {
        if(m_Running)
        {
            m_Time -= dt;
            m_Time = Mathf.Clamp(m_Time, 0.0f, float.MaxValue);
        }
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
    public bool IsRunning()
    {
        return m_Running;
    }
}
