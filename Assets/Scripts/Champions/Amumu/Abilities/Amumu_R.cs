using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Amumu_R : Ability
{
    [Header("Ability Data")]
    public float m_Range;
    public float m_Damage;
    public float m_StunTime;

    protected override UnityAction<GameObject> GetInternalAction()
    {
        return (GameObject target) =>
        {
            ChampionHelper.ForChampionInRangeExclusingSource(m_Owner.gameObject, m_Range,
                (Champion target) =>
                {
                    m_Owner.Passive();
                    target.HandleDamage(m_Damage, Damages.Magic);
                    target.HandleStun(m_StunTime);
                }
            );
        };
    }
}
