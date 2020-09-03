using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Request : MonoBehaviour
{
	Global.Order order1;
	public GameObject GameObject0, GameObject1, GameObject2, GameObject3, GameObject4, GameObject5;
	public Text nameCustomer, adressCustomer, carCustomer, offerCustomer, dateCustomer, timeCustomer, phoneCustomer;
	int numberGO;
    // Start is called before the first frame update
    void Start()
    {
    	Global.scenecal = 1;
    	numberGO = 0;
    	
        ActiveGameObject();
    }
    void ActiveGameObject(){
    	GameObject0.SetActive(false);
        GameObject1.SetActive(false);
        GameObject2.SetActive(false);
        GameObject3.SetActive(false);
        GameObject4.SetActive(false);
        GameObject5.SetActive(false);
        switch (numberGO)
      	{
          	case 0:
            	GameObject0.SetActive(true);
              	break;
          	case 1:
            	GameObject1.SetActive(true);
              	break;
          	case 2:
            	GameObject2.SetActive(true);
              	break;
          	case 3:
            	GameObject3.SetActive(true);
              	break;
          	case 4:
            	GameObject4.SetActive(true);
              	break;
          	case 5:
            	GameObject5.SetActive(true);
              	break;
      	}
    }
    public void NextGameObject(){
    	switch (numberGO)
      	{
          	case 0:
            	order1.name = nameCustomer.text;
              	break;
          	case 1:
            	order1.adress = adressCustomer.text;
    			order1.car = carCustomer.text;
              	break;
          	case 2:
            	order1.offer = offerCustomer.text;
              	break;
          	case 3:
            	order1.date = dateCustomer.text;
    			order1.time = timeCustomer.text;
              	break;
          	case 4:
            	order1.phone = phoneCustomer.text;
              	break;
      	}
    	numberGO++;
    	
    	if (numberGO > 5){
    		SceneManager.LoadScene(3);
    		Global.regUser = 1;
    		order1.status = 0;
    		order1.id = Global.countOrder;
    		Global.countOrder++;
    		Global.ListOrder.Add(order1);
    	}
    	else
	    	ActiveGameObject();
    }	
	public void SceneMain()
    {
    	if (Global.regUser == 0)
    		SceneManager.LoadScene(0);
    	else
    		SceneManager.LoadScene(3);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
