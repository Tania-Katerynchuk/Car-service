using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
	public GameObject newCanvas;
    // Start is called before the first frame update
    void Start()
    {
     newCanvas.AddComponent<GraphicRaycaster>();
     GameObject panel = new GameObject("Panel");
     panel.AddComponent<CanvasRenderer>();
     Image i = panel.AddComponent<Image>();
     i.color = Color.red;
     panel.GetComponent<RectTransform> ().sizeDelta = new Vector2(50, 150);
     panel.transform.position = new Vector3(100, 100, 0);
     panel.transform.SetParent(newCanvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
