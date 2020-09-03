using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Admin : MonoBehaviour
{
	public GameObject scrollWiew1, scrollWiew2, scrollWiew3, orderPanel3;
	public Button button1, button2, button3;
	public Text nameSW, dateOrders;
    public GameObject Content1, Content2, Content3;
    public Sprite buttonSpriet1, buttonSprite2;
    // Start is called before the first frame update
    void Start()
    {
        if (Global.adminMenu == 0){
            Global.scenecal = 3;
            button1.GetComponent<Image>().color = new Color32(41, 160, 143, 255);
            button2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            button3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            scrollWiew1.SetActive(true);
            scrollWiew2.SetActive(false);
            scrollWiew3.SetActive(false);
            nameSW.text = "Очікує на підтвердження";
            Global.CreateAllBlock(Content1, 0, 1, buttonSpriet1, buttonSprite2);
        }
        else if (Global.adminMenu == 1){
            ButtonConfirm();
            Global.adminMenu = 0;
        }
    	
    }
    public void ButtonNotConfirm(){
    	Start();
    }
    public void ButtonConfirm(){
    	button1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        button2.GetComponent<Image>().color = new Color32(41, 160, 143, 255);
        button3.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        scrollWiew1.SetActive(false);
        scrollWiew2.SetActive(true);
        scrollWiew3.SetActive(false);
        nameSW.text = "Підтвердженні";
        Global.CreateAllBlock(Content2, 1, 1, buttonSpriet1, buttonSprite2);
    }
    public void ButtonHistory(){
    	button1.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        button2.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        button3.GetComponent<Image>().color = new Color32(41, 160, 143, 255);
        scrollWiew1.SetActive(false);
        scrollWiew2.SetActive(false);
        scrollWiew3.SetActive(true);
        nameSW.text = "Історія замовлень";
    }
    public void ButtonCalendar(){
        orderPanel3.SetActive(false);
    }
    public void SceneMain(){
    	SceneManager.LoadScene(0);
    }
    public void ButtonCalendarNo(){
        orderPanel3.SetActive(true);
        Global.CreateDateBlock(Content3, dateOrders.text, 0, buttonSpriet1, buttonSprite2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
