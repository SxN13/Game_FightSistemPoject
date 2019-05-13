using UnityEngine;
using System.Collections;

public class Fight2D : MonoBehaviour
{

    // функция возвращает ближайший объект из массива, относительно указанной позиции
    static GameObject NearTarget(Vector3 position, Collider2D[] array)
    {
        Collider2D current = null;
        float dist = Mathf.Infinity;

        foreach (Collider2D coll in array)
        {
            float curDist = Vector3.Distance(position, coll.transform.position);

            if (curDist < dist)
            {
                current = coll;
                dist = curDist;
            }
        }

        return (current != null) ? current.gameObject : null;
    }

    // point - точка контакта
    // radius - радиус поражения
    // layerMask - номер слоя, с которым будет взаимодействие
    // damage - наносимый урон
    // allTargets - должны-ли получить урон все цели, попавшие в зону поражения
    public static void Action(Vector2 point, float radius, int layerMask, float damage, bool allTargets)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(point, radius, 1 << layerMask);

        if (!allTargets)
        {
            GameObject obj = NearTarget(point, colliders);
            if (obj != null && obj.GetComponent<Hurtbox>())
            {
                obj.GetComponent<Hurtbox>().HP -= damage;
            }
            else if(obj != null && obj.GetComponent<Hurtboxknee>())
            {
                obj.GetComponent<Hurtboxknee>().HP -= damage;
            }
            if (obj != null && obj.GetComponent<HurtboxHead>())
            {
                obj.GetComponent<HurtboxHead>().HP -= damage;
            }
            return;
        }

        foreach (Collider2D hit in colliders)
        {
            if (hit.GetComponent<Hurtbox>())
            {
                hit.GetComponent<Hurtbox>().HP -= damage;
            }
            else if(hit.GetComponent<Hurtboxknee>())
            {
                hit.GetComponent<Hurtboxknee>().HP -= damage;
            }
            else if (hit.GetComponent<HurtboxHead>())
            {
                hit.GetComponent<HurtboxHead>().HP -= damage;
            }
        }
    }
}