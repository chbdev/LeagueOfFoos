using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
//public
    public abstract void Passive();
    [Header("General Champion Settings")]
    public bool m_LocalPlayer = false;
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
        if (!m_LocalPlayer)
            return;

        //MouseTarget
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        GameObject target = hit.collider ? hit.collider.gameObject : null;
        
        //Mouse Input
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (target && !target.GetComponent<Entity>())
            {
                m_NavMeshAgent.SetDestination(hit.point);
            }
        }

        //Abilities
        Passive();
        foreach(Ability currentAbility in m_Abilities)
        {
            if (currentAbility.IsReady() && Input.GetKeyDown(currentAbility.GetAssociatedKey()))
            {
                currentAbility.Trigger(target);
            }
        }
    }
}
