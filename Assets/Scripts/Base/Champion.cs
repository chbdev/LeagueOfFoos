using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
    //protected
    protected abstract void Passive();
    protected abstract void Q();
    protected abstract void W();
    protected abstract void E();
    protected abstract void R();

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
