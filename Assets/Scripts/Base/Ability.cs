using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour
{
//public 
    public float m_CdTime;
//private
    [SerializeField] private KeyCode m_AssociatedKey;
    private Timer m_CooldownTimer = new Timer(0.0f);
    private UnityAction m_Action;

    private void Update()
    {
        m_CooldownTimer.Update(Time.deltaTime);
    }
    public bool IsReady()
    {
        return m_CooldownTimer.IsElapsed() && m_CooldownTimer.IsRunning();
    }
    public void Trigger()
    {
        m_Action();
        m_CooldownTimer.SetTime(m_CdTime);
        m_CooldownTimer.Play();
    }
    public KeyCode GetAssociatedKey() { return m_AssociatedKey; }
    public void SetAction(UnityAction newValue) { m_Action = newValue; }

    
}
