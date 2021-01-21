using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
    //protected
    protected abstract void Passive();
    protected abstract void FeedAbilities();

    public Ability[] m_Abilities;

    private void Start()
    {
        FeedAbilities();
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
                m_NavMesAgent.SetDestination(hit.point);
            }
        }
    }
}
