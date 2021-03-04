using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Patrol : MonoBehaviour
{
//public
    public GameObject[] m_PatrolPositions;
    public float m_ReachedDistance = 1.0f;
//private
    private int m_CurrentIndex = -1;
    private GameObject m_currentTarget = null;
    Entity m_Entity = null;

    private void Awake()
    {
        m_Entity = gameObject.GetComponent<Entity>();
        Assert.IsNotNull(m_Entity, "Patrol running in a non Entity object");
    }

    private void Start()
    {
        if (m_PatrolPositions.Length != 0)
        {
            m_CurrentIndex = 0;
            m_currentTarget = m_PatrolPositions[m_CurrentIndex];
            GoToTarget();
        }
    }

    private void Update()
    {
        if(m_currentTarget)
        {
            if(Vector3.Distance(m_currentTarget.transform.position, gameObject.transform.position) <= m_ReachedDistance)
            {
                NextTarget();
            }
        }
    }

    private void GoToTarget()
    {
        m_currentTarget = m_PatrolPositions[m_CurrentIndex];
        Vector3 destination = MapHelper.GetMapProjectionForGameObject(m_currentTarget);
        m_Entity.SetDestination(destination);
    }
    private void NextTarget()
    {
        m_CurrentIndex += 1;
        if(m_CurrentIndex >= m_PatrolPositions.Length)
        {
            m_CurrentIndex = 0;
        }
        GoToTarget();
    }
}
