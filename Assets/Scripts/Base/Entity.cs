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
    protected NavMeshAgent m_NavMeshAgent;
//private

    protected void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(m_NavMeshAgent, "There is an Entity without a NavMeshAgent");
    }

    public virtual void HandleDamage(float damage, Damages damageType)
    {
        m_Hp -= damage;
    }

    public virtual void HandleStun(float time)
    {
        Debug.Log(this.name + " has been stunned for " + time + " seconds");
        float prevSpeed = m_NavMeshAgent.speed;
        float prevAngSpeed = m_NavMeshAgent.angularSpeed;
        m_NavMeshAgent.speed = 0.0f;
        m_NavMeshAgent.angularSpeed = 0.0f;
        StartCoroutine(ChampionHelper.ApplyAfterTime(time,
            () =>
            {
                m_NavMeshAgent.speed = prevSpeed;
                m_NavMeshAgent.angularSpeed = prevAngSpeed;
            }
        ));
    }

    public void SetDestination(Vector3 pos)
    {
        m_NavMeshAgent.SetDestination(pos);
    }
}
