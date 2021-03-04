using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Amumu_W : Ability
{
    [Header("Ability Data")]
    [SerializeField] private float m_Range;
    [SerializeField] private float m_Damage;
    [SerializeField] private ParticleSystem m_EnabledParticleSystem;

    protected override UnityAction<GameObject> GetInternalAction()
    {
        return (GameObject target) =>
        {
            m_EnabledParticleSystem.Play();
            ChampionHelper.ForChampionInRangeExclusingSource(m_Owner.gameObject, m_Range, 
                (Champion target) =>
                {
                    target.HandleDamage(m_Damage, Damages.Magic);
                });
        };
    }
}
