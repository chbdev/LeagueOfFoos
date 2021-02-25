using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
//public
    public abstract void Passive();
    public Ability[] m_Abilities;


    protected void Awake()
    {
        base.Awake();
        foreach (Ability ability in m_Abilities)
        {
            if(ability)
            {
                ability.SetOwner(this);
            }
        }
    }

    protected virtual void Update()
    {
        //Abilities
        Passive();
        foreach(Ability currentAbility in m_Abilities)
        {
            if (currentAbility.IsReady() && Input.GetKeyDown(currentAbility.GetAssociatedKey()))
            {
                currentAbility.Trigger();
            }
        }

        //Mouse
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                m_NavMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
