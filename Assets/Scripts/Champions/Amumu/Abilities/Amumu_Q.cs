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
                (Collider other) => 
                {
                    Champion champion = null;
                    if (other.gameObject.TryGetComponent<Champion>(out champion))
                    {
                        if(m_Owner != champion)
                        {
                            StartCoroutine(GoTo(champion.gameObject)); 
                            champion.HandleStun(m_StunTime);
                            return true;
                        }
                    }
                    return false;

                }, Vector3.right, m_Owner.transform.position);
        };
    }

    IEnumerator GoTo(GameObject targetChampion)
    {
        //TODO: Esta comprobación tiene que ser "He colisionado con el target" en vez de una distancia fija porque habrá campeones con distintos tamaños
        while(Vector3.Distance(m_Owner.transform.position, targetChampion.transform.position) > 1.5f)
        {
            Vector3 pos = Vector3.MoveTowards(m_Owner.transform.position, targetChampion.transform.position, m_DashSpeed*Time.deltaTime);
            m_Owner.transform.position = pos;
            yield return null;
        }
    }
}
