using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ability : MonoBehaviour
{
//public 
    public float m_CdTime;
//protected
    protected Champion m_Owner;
//private
    [SerializeField] private KeyCode m_AssociatedKey;
    private Timer m_CooldownTimer = new Timer(0.0f);
    //TODO @carlos: Check if there is a generic type for actions 
    private UnityAction<GameObject> m_Action;

    private void Start()
    {
        SetAction(GetInternalAction());
    }
    private void Update()
    {
        m_CooldownTimer.Update(Time.deltaTime);
    }
    public bool IsReady()
    {
        return m_CooldownTimer.IsElapsed() && m_CooldownTimer.IsRunning();
    }
    public void Trigger(GameObject target)
    {
        m_Action(target);
        m_CooldownTimer.SetTime(m_CdTime);
        m_CooldownTimer.Play();
    }

    protected virtual UnityAction<GameObject> GetInternalAction() { return null; }
    public KeyCode GetAssociatedKey() { return m_AssociatedKey; }
    public void SetAction(UnityAction<GameObject> newValue) { m_Action = newValue; }
    public void SetOwner(Champion newValue) { m_Owner = newValue; }

    
}
