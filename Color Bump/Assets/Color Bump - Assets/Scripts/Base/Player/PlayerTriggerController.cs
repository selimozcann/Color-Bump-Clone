using UnityEngine;
using System;

public enum ColorType { White, Black , Blue}
public class PlayerTriggerController : MonoBehaviour
{
    [SerializeField] private ColorType mainColorType;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(StringData.LEVELOBJECT))
        {
            ObjectController objectController = other.GetComponent<ObjectController>();
            if (objectController)
            {
                if (mainColorType == objectController.ColorType)
                    return;

                Debug.LogError("The Game is fail");
            }
                 
        }
    }
}
