using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removechild : MonoBehaviour
{
    public void Deletechilde()
    {
        Transform[] childList = GetComponentsInChildren<Transform>(true);
        if (childList != null)
        {
            for (int i = 0; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

    }
}
