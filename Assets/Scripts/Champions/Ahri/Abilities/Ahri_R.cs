using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ahri_R : Ability
{
    [Header("Ability Data")]
    public float m_Range;
    public float m_Damage;

    protected override UnityAction GetInternalAction()
    {
        return () =>
        {
            
        };
    }
}
