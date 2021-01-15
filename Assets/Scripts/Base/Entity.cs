using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public abstract class Entity : MonoBehaviour
{
//public 
//protected
    protected float m_Hp;
    protected NavMeshAgent m_NavMesAgent;
//private

    void Start()
    {
        m_NavMesAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(m_NavMesAgent);
    }

    public virtual void HandleDamage(float damage)
    {
        m_Hp -= damage;
    }

    public virtual void HandleStun(float time)
    {

    }
}
