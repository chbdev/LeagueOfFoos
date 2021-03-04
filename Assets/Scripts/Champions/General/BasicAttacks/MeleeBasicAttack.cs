using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeBasicAttack : Ability
{
    [Header("Melee Basic Attack")]
    [SerializeField] private float m_Range = 0.0f;
    [SerializeField] private float m_Damage = 0.0f;

    protected override UnityAction<GameObject> GetInternalAction()
    {
        return (GameObject target) =>
        {
            if (!target.GetComponent<Entity>())
                return;

            Vector3 dir = (target.transform.position - m_Owner.transform.position);
            if(dir.magnitude <= m_Range)
            {
                target.GetComponent<Entity>().HandleDamage(m_Damage, Damages.Physical);
            }
            else
            {
                Vector3 dest = m_Owner.transform.position + dir.normalized * (dir.magnitude - m_Range);
                m_Owner.GetComponent<Entity>().SetDestination(dest);
            }
        };
    }
}
