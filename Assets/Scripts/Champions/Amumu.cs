using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amumu : Champion
{
//public
    [Header("E")]
    public float m_E_Range;
    public float m_E_Damage;

    [Header("R")]
    public float m_R_Range;
    public float m_R_Damage;
    public float m_R_StunTime;

    protected override void Passive()
    {
    }
    protected override void Q(bool pressed)
    {
    }
    protected override void W(bool pressed)
    {
    }
    protected override void E(bool pressed)
    {
        if(pressed)
        {
            ChampionHelper.ForChampionInRange(this.gameObject, m_E_Range,
                (Champion target) =>
                {
                    Passive();
                    target.HandleDamage(m_E_Damage);
                }
            );
        }
    }
    protected override void R(bool pressed)
    {
        if(pressed)
        {
            ChampionHelper.ForChampionInRange(this.gameObject, m_R_Range, 
                (Champion target) => 
                    {
                        Passive();
                        target.HandleDamage(m_R_Damage);
                        target.HandleStun(m_R_StunTime);
                    }
            );
        }
    }
}
