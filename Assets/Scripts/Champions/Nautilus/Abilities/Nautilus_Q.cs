using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Nautilus_Q : Ability
{
    [Header("Ability Data")]
    [SerializeField] private GameObject m_Projectile;
    [SerializeField] private float m_DashSpeed;

    protected override UnityAction<GameObject> GetInternalAction()
    {
        return (GameObject target) =>
        {
            RaycastHit hit;
            Vector3 toGo = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                toGo = hit.point;
            }

            Vector3 dir = (toGo - m_Owner.transform.position).normalized;

            //Generar proyectil
            ChampionHelper.CreateProjectile(m_Projectile,
                (Collider other, GameObject projectile) =>
                {
                    if(other.gameObject != m_Owner.gameObject)
                    {
                        Champion champion = null;
                        if (other.gameObject.TryGetComponent<Champion>(out champion))
                        {
                            Vector3 toTarget = (other.gameObject.transform.position - m_Owner.gameObject.transform.position);
                            toTarget.Scale(new Vector3(0.5f, 0.5f, 0.5f));
                            toTarget = m_Owner.gameObject.transform.position + toTarget;

                            StartCoroutine(ChampionHelper.GoToPosition(toTarget, m_Owner.gameObject, m_DashSpeed));
                            StartCoroutine(ChampionHelper.GoToPosition(toTarget, other.gameObject, m_DashSpeed));

                            return true;
                        }

                        if(other.gameObject.tag == "Wall")
                        {
                            StartCoroutine(ChampionHelper.GoToPosition(projectile.transform.position, m_Owner.gameObject, m_DashSpeed));

                            return true;
                        }
                    }
                    return false;

                }, dir, m_Owner.transform.position);
        };
    }

}
