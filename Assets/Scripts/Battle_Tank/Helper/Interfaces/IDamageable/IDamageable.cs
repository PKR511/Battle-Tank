using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper.Interface.IDamageable
{
    public interface IDamageable 
    {

         void TakeDamage(float damageAmount, string damageBy);
       
    }

}
