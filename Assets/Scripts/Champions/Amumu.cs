using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amumu : Champion
{
    [Header("R")]
    float m_Range;
    float m_Damage;
    float m_StunTime;

    protected override void Passive()
    {
    }

    protected override void Q()
    {
    }

    protected override void E()
    {
    }

    protected override void W()
    {
    }

    protected override void R()
    {
        ChampionHelper.ForChampionInRange(this.gameObject, m_Range, 
            (Champion target) => 
                {
                    Passive();
                    target.HandleDamage(m_Damage);
                    target.HandleStun(m_StunTime);
                }
        );
    }
}
