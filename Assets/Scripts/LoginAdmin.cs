using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class LoginAdmin : MonoBehaviour
{
	public Text name, password, textCheck;
	const string nameAdmin = "Admin";
	const string passwordAdmin = "******";
    // Start is called before the first frame update
    void Start()
    {
       	textCheck.text = "";
    }
    public void SceneMain()
    {
        SceneManager.LoadScene(0);
    }
    public void SceneAdmin()
    {
    	if (name.text == nameAdmin && password.text == passwordAdmin){
    		SceneManager.LoadScene(4);
    	}
    	else{
    		textCheck.text = "Не правильно вказаний логін чи пароль адміністратора";
    	}

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
