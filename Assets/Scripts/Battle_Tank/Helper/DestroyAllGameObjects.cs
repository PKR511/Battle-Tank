using Battle_Tank.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllGameObjects : GenericSingleton<DestroyAllGameObjects>
{
    public GameObject[] GameObjects;
 

    public void DestroyAll()
    {

        for (int i = 0; i < GameObjects.Length; i++)
        {
            if (GameObjects[i].transform.childCount > 0)
            {
                for(int j=0;j< GameObjects[i].transform.childCount; j++)
                {
                    StartCoroutine(WaitFor(1f, GameObjects[i].transform.GetChild(j).gameObject));
                }
            }
            else
            {
                StartCoroutine(WaitFor(1f, GameObjects[i]));
            }


        }




        }





    public IEnumerator WaitFor(float time,GameObject obj)
    {
        yield return new WaitForSeconds(time);
        // Destroy(obj);
        obj.SetActive(false);
        Debug.Log("Destroy ="+obj);
        
    }
}
