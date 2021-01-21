using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class Entity : MonoBehaviour
{
//public 
//protected
    protected float m_Hp;
    protected NavMeshAgent m_NavMesAgent;
//private

    void Awake()
    {
        m_NavMesAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(m_NavMesAgent);
    }

    public virtual void HandleDamage(float damage, Damages damageType)
    {
        m_Hp -= damage;
    }

    public virtual void HandleStun(float time)
    {
        Debug.Log(this.name + " has been stunned for " + time + " seconds");
        float prevSpeed = m_NavMesAgent.speed;
        float prevAngSpeed = m_NavMesAgent.angularSpeed;
        m_NavMesAgent.speed = 0.0f;
        m_NavMesAgent.angularSpeed = 0.0f;
        StartCoroutine(ChampionHelper.ApplyAfterTime(time,
            () =>
            {
                m_NavMesAgent.speed = prevSpeed;
                m_NavMesAgent.angularSpeed = prevAngSpeed;
            }
        ));
    }

    public void SetDestination(Vector3 pos)
    {
        m_NavMesAgent.SetDestination(pos);
    }
}
