using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    static bool UIdestroy;


    private void Start()
    {
        UIdestroy = false;
        this.gameObject.SetActive(true);
    }

    public static void UIDestroy()
    {
        UIdestroy = true;
    }

    private void Update()
    {
        if(UIdestroy)
        {
            this.gameObject.SetActive(false);
        }
    }

}
