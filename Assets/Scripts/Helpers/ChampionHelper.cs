using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
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

    public static void CreateProjectile(GameObject projectileObject, System.Func<Collider, GameObject, bool> action, Vector3 direction, Vector3 startPos)
    {
        GameObject projectile = Instantiate(projectileObject, startPos, Quaternion.identity);
        Assert.IsTrue(projectile.GetComponent<Projectile>(), "Wrong usage of CreateProjectile. You are creating something that is not a projectile");

        projectile.GetComponent<Projectile>().Init(action, direction);
    }

    public static void DashInDirection(GameObject champion, Vector3 direction, float distance, float speed)
    {
    }

    public static IEnumerator GoToChampion(GameObject targetChampion, GameObject owner, float speed)
    {
        return GoToPosition(targetChampion.transform.position, owner, speed);
    }

    public static IEnumerator GoToPosition(Vector3 targetPosition, GameObject owner, float speed)
    {
        //TODO: Esta comprobaci�n tiene que ser "He colisionado con el target" en vez de una distancia fija porque habr� campeones con distintos tama�os
        while (Vector3.Distance(owner.transform.position, targetPosition) > 0.5f)
        {
            Vector3 pos = Vector3.MoveTowards(owner.transform.position, targetPosition, speed * Time.deltaTime);
            owner.transform.position = pos;
            yield return null;
        }
    }
}
