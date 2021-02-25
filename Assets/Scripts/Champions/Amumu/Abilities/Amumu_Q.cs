using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Amumu_Q : Ability
{
    [Header("Ability Data")]
    [SerializeField] private float m_StunTime;
    [SerializeField] private GameObject m_Projectile;
    [SerializeField] private float m_DashSpeed;
    protected override UnityAction GetInternalAction()
    {
        return () =>
        {
            ChampionHelper.CreateProjectile(m_Projectile, 
                (Collider other, GameObject projectile) => 
                {
                    Champion champion = null;
                    if (other.gameObject.TryGetComponent<Champion>(out champion))
                    {
                        if(m_Owner != champion)
                        {
                            StartCoroutine(ChampionHelper.GoToChampion(champion.gameObject, m_Owner.gameObject, m_DashSpeed)); 
                            champion.HandleStun(m_StunTime);
                            return true;
                        }
                    }
                    return false;

                }, Vector3.right, m_Owner.transform.position);
        };
    }
}
