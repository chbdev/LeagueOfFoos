using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChampionHelper : MonoBehaviour
{
    public static void ForChampionInRange(GameObject sourceChampion, float radius, UnityAction<Champion> action)
    {
        Collider[] hitColliders = Physics.OverlapSphere(sourceChampion.transform.position, radius);
        foreach(Collider collider in hitColliders)
        {
            Champion champ;
            if (collider.gameObject.TryGetComponent<Champion>(out champ))
            {
                action(champ);
            }
        }
    }
}
