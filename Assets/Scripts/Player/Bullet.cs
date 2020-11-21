using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Health Target;
    public float Speed = 10;
    public int Damage = 1;

  
    private void Update()
    {
        if ( Target!= null )
        {
            Vector3 targetDirection = transform.position - Target.transform.position;
            if (targetDirection.sqrMagnitude <= 0.01f)
            {
                Target.Damage(Damage);
                Destroy(gameObject);
            }
            float rot_z = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        } else
        {
            Destroy(gameObject);
        }
        
    }
}
