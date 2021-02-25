using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
//private
    [SerializeField] private float m_Range;
    [SerializeField] private float m_Speed;
    [SerializeField] private float m_Width;
    private Vector3 m_Direction;
    public System.Func<Collider, GameObject, bool> m_OnHit;
    private bool m_destroyOnSuccess;


    public void Init(System.Func<Collider, GameObject, bool> onHitAction, Vector3 direction)
    {
        m_OnHit = onHitAction;
        m_Direction = direction;
    }

    private void Update()
    {
        Assert.IsNotNull(m_OnHit, "No OnHit action for projectile " + this.gameObject.name + " maybe you've missed to call Init in code");
        transform.position = transform.position + m_Direction * m_Speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        bool shouldBeDestroyed = m_OnHit(other, this.gameObject);
        if(shouldBeDestroyed)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetOnHitAction(System.Func<Collider, GameObject, bool> newValue) { m_OnHit = newValue; }
    public void SetDiretion(Vector3 newValue) { m_Direction = newValue; }

}
