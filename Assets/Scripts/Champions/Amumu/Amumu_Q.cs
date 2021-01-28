using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Amumu_Q : Ability
{
    [Header("Ability Data")]
    public GameObject m_Projectile;
    protected override UnityAction GetInternalAction()
    {
        return () =>
        {
            ChampionHelper.CreateProjectile(m_Projectile, 
                (Collider other) => 
                {
                    Debug.Log("Soy el proyectil de la Q de Amumu. He chocado con algo"); 

                }, Vector3.forward, m_Owner.transform.position);
        };
    }
}
