using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
    //protected
    protected abstract void Passive();
    protected abstract void Q(bool pressed);
    protected abstract void W(bool pressed);
    protected abstract void E(bool pressed);
    protected abstract void R(bool pressed);

    protected virtual void Update()
    {
        //Abilities
        Passive();
        Q(Input.GetKeyDown(KeyCode.Q));
        W(Input.GetKeyDown(KeyCode.W));
        E(Input.GetKeyDown(KeyCode.E));
        R(Input.GetKeyDown(KeyCode.R));

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
