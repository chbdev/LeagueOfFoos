using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChampionHelper : MonoBehaviour
{
    public static void ForChampionInRangeExclusingSource(GameObject sourceChampion, float radius, UnityAction<Champion> action)
    {
        HashSet<GameObject> excludeSet = new HashSet<GameObject>();
        excludeSet.Add(sourceChampion);
        ForChampionInRange(sourceChampion, radius, action, excludeSet);
    }

    public static void ForChampionInRange(GameObject sourceChampion, float radius, UnityAction<Champion> action, HashSet<GameObject> exclude)
    {
        Collider[] hitColliders = Physics.OverlapSphere(sourceChampion.transform.position, radius);
        foreach (Collider collider in hitColliders)
        {
            if (exclude != null && exclude.Contains(collider.gameObject))
                continue;

            Champion champ;
            if (collider.gameObject.TryGetComponent<Champion>(out champ))
            {
                action(champ);
            }
        }
    }

    public static IEnumerator ApplyAfterTime(float time, UnityAction action)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
