using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Amumu_E : Ability
{
    [Header("Ability Data")]
    public float m_Range;
    public float m_Damage;
    protected override UnityAction GetInternalAction()
    {
        return () =>
        {
            ChampionHelper.ForChampionInRangeExclusingSource(m_Owner.gameObject, m_Range,
                (Champion target) =>
                {
                    m_Owner.Passive();
                    target.HandleDamage(m_Damage, Damages.Magic);
                }
            );
        };
    }
}
