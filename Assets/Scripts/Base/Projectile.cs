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
    private UnityAction<Collider> m_OnHit;
    
    public void Init(UnityAction<Collider> onHitAction, Vector3 direction)
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
        m_OnHit(other);
    }

    public void SetOnHitAction(UnityAction<Collider> newValue) { m_OnHit = newValue; }
    public void SetDiretion(Vector3 newValue) { m_Direction = newValue; }

}
