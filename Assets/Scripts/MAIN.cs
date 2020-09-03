using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System;


public class MAIN : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
       /* Global.ListOrder.Add(order1);
        Debug.Log(Global.ListOrder[0].name);
        order1.name = "3";
        Global.ListOrder.Add(order1);
        Debug.Log(Global.ListOrder[1].name);*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneRequest()
    {
        if (Global.regUser == 0)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(3);
    }
    public void SceneLoginAdmin()
    {
        SceneManager.LoadScene(2);
    }
}


