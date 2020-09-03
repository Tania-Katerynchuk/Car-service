using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Global
{
    public static int regUser = 0;
    public static int scenecal = 0;
    public static List<Order> ListOrder = new List<Order>();
	static Order order1;
	public static List<GameObject> ListActive = new List<GameObject>();
	public static int countOrder = 0;
	public static int adminMenu = 0;

    public struct Order 
	{
		public int id;
    	public string name;
    	public string car;
    	public string adress;
    	public string offer;
    	public string date;
    	public string time;
    	public string phone;
    	public int status;
	}

	public static void CreateAllBlock(GameObject newCanvas, int status, int accses, Sprite s1, Sprite s2){
		DestroyListActive();
		// order1.id = countOrder;
		// countOrder++;
		// order1.name = "vmlskdvm";
		// order1.status = 0;
		// order1.date = "8.5.2020";
		// //ListOrder.Add(order1);
		// ListOrder.Add(order1);
		// order1.status = 1;
		// order1.date = "10.5.2020";
		// order1.id = countOrder;
		// countOrder++;
		// ListOrder.Add(order1);
		int n = 0;
		for(int i=0; i < ListOrder.Count; i++){
			if (ListOrder[i].status == status){
				if (accses == 0){
					CreateBlock(newCanvas, i, -n*820, accses, status, s1, s2);
				}
				else if (accses == 1){
					CreateBlock(newCanvas, i, -n*1020, accses, status, s1, s2);
				}
				n++;
			}
		}
		if (accses == 0){
			newCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2(1064, n*820 + 30);
		}
		else if (accses == 1){
			newCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2(1064, n*1020 + 40);
		}
		
	}

	public static void CreateDateBlock(GameObject newCanvas, string date, int accses, Sprite s1, Sprite s2){
		DestroyListActive();
		int n = 0;
		for(int i=0; i < ListOrder.Count; i++){
			if (ListOrder[i].date == date){
				CreateBlock(newCanvas, i, -n*820, accses, -1, s1, s2);
				n++;
			}
		}
		newCanvas.GetComponent<RectTransform> ().sizeDelta = new Vector2(1064, n*820 + 30);
	}

	private static void CreateBlock(GameObject newCanvas, int n, int y, int accses, int status, Sprite s1, Sprite s2){
		newCanvas.AddComponent<GraphicRaycaster>();
     	GameObject panel = new GameObject("Panel1");
     	panel.AddComponent<Canvas>();
     	panel.AddComponent<CanvasRenderer>();
     	Image i = panel.AddComponent<Image>();
     	i.color = new Color32(255, 255, 255, 177);
     	if (accses == 0){
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2(1030, 800);
			panel.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 800);
			panel.transform.position = new Vector3(0, y - 440, 0);
		}
		else if (accses == 1){
			panel.GetComponent<RectTransform> ().sizeDelta = new Vector2(1030, 1000);
			panel.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 1000);
			panel.transform.position = new Vector3(0, y - 540, 0);
		}
     	panel.transform.SetParent(newCanvas.transform, false);
		if (accses == 1){
			if (status == 0){
				GameObject button1 = new GameObject();
    			button1.transform.parent = newCanvas.transform;
    			button1.AddComponent<RectTransform>();
    			button1.AddComponent<Button>();
    			RectTransform rectTransform1;
        		rectTransform1 = button1.GetComponent<RectTransform>();
        		rectTransform1.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 120);
        		rectTransform1.localPosition = new Vector3(430,-960+y, -12);
        		rectTransform1.sizeDelta = new Vector2(120, 120);
        		rectTransform1.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    			button1.AddComponent<Image>().sprite = s1;
    			button1.GetComponent<Button>().onClick.AddListener(() => ButtonOnStatus(n));
    			ListActive.Add(button1);

    			GameObject button2 = new GameObject();
    			button2.transform.parent = newCanvas.transform;
    			button2.AddComponent<RectTransform>();
    			button2.AddComponent<Button>();
    			RectTransform rectTransform2;
    			rectTransform2 = button2.GetComponent<RectTransform>();
        		rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 120);
        		rectTransform2.localPosition = new Vector3(-430,-960+y, -12);
        		rectTransform2.sizeDelta = new Vector2(120, 120);
        		rectTransform2.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    			button2.AddComponent<Image>().sprite = s2;
    			button2.GetComponent<Button>().onClick.AddListener(() => ButtonOffStatus(n));
    			ListActive.Add(button2);
    			adminMenu = 0;

			}
			else if (status == 1){
				GameObject button2 = new GameObject();
    			button2.transform.parent = newCanvas.transform;
    			button2.AddComponent<RectTransform>();
    			button2.AddComponent<Button>();
    			RectTransform rectTransform2;
    			rectTransform2 = button2.GetComponent<RectTransform>();
        		rectTransform2.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, 120);
        		rectTransform2.localPosition = new Vector3(0,-960+y, -12);
        		rectTransform2.sizeDelta = new Vector2(120, 120);
        		rectTransform2.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    			button2.AddComponent<Image>().sprite = s2;
    			button2.GetComponent<Button>().onClick.AddListener(() => ButtonOffStatus(n));
    			ListActive.Add(button2);
    			adminMenu = 1;
			}
		}
       	CreateText(panel, "Замовлення "+ (ListOrder[n].id+1), 80, 135, 355, 800, 200);
     	string textOrder = "Ім'я: " + ListOrder[n].name + "\nМашина: " + ListOrder[n].car + "\nАдреса СТО: " + ListOrder[n].adress + "\nПослуга: " + ListOrder[n].offer + "\nДата: " + ListOrder[n].date + "\nГодина: " + ListOrder[n].time + "\nНомер телефону: " + ListOrder[n].phone + "\nСтатус: ";
     	if (ListOrder[n].status == 0){
     		textOrder = textOrder + "очікує на підтвердження";
     	}
     	else if (ListOrder[n].status == 1){
     		textOrder = textOrder + "підтверджено";
     	}
     	else {
     		textOrder = textOrder + "відхилено";
     	}
     	CreateText(panel, textOrder, 60, 0, -44, 980, 680);
     	ListActive.Add(panel);
    }
    public static void ButtonOnStatus(int n){
    	adminMenu = 0;
    	order1.id = ListOrder[n].id;
    	order1.name = ListOrder[n].name;
    	order1.car = ListOrder[n].car;
    	order1.adress = ListOrder[n].adress;
    	order1.offer = ListOrder[n].offer;
    	order1.date = ListOrder[n].date;
    	order1.time = ListOrder[n].time;
    	order1.phone = ListOrder[n].phone;
    	order1.status = 1;
    	ListOrder.RemoveAt(n);
    	ListOrder.Add(order1);
    	SceneManager.LoadScene(4);
    }
    public static void ButtonOffStatus(int n){
    	order1.id = ListOrder[n].id;
    	order1.name = ListOrder[n].name;
    	order1.car = ListOrder[n].car;
    	order1.adress = ListOrder[n].adress;
    	order1.offer = ListOrder[n].offer;
    	order1.date = ListOrder[n].date;
    	order1.time = ListOrder[n].time;
    	order1.phone = ListOrder[n].phone;
    	order1.status = 2;
    	ListOrder.RemoveAt(n);
    	ListOrder.Add(order1);
    	SceneManager.LoadScene(4);
    }

    private static void CreateText(GameObject panel, string texts, int fontSize, int x, int y, int width, int height){
		Text text;
		Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
		GameObject textGO = new GameObject();
        textGO.transform.parent = panel.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = texts;
        text.fontSize = fontSize;
        text.color = new Color32(55, 55, 55, 255);
        text.alignment = TextAnchor.MiddleLeft;


        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(x, y, 0);
        rectTransform.sizeDelta = new Vector2(width, height);
        rectTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
    private static void DestroyListActive(){
    	for (int i = ListActive.Count - 1; i >=0;i--){
    		UnityEngine.Object.Destroy(ListActive[i]);
    		ListActive.RemoveAt(i);
    	}
    }
}

