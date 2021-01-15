using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public abstract class Champion : MonoBehaviour
{
    //public 
    //protected
    //private
    float m_Hp;
    NavMeshAgent m_NavMesAgent;

    protected abstract void Passive();
    protected abstract void Q();
    protected abstract void W();
    protected abstract void E();
    protected abstract void R();

    public virtual void HandleDamage(float damage)
    {
        m_Hp -= damage;        
    }
    public virtual void HandleStun(float time)
    {

    }
    private void Start()
    {
        m_NavMesAgent = GetComponent<NavMeshAgent>();
        Assert.IsNotNull(m_NavMesAgent);
    }

    protected virtual void Update()
    {
        //Abilities
        Passive();
        Q();
        W();
        E();
        R();

        //Mouse
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                m_NavMesAgent.SetDestination(hit.point);
            }
        }
    }
}
