using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]

public class ChangeColor : MonoBehaviour
{
    GameObject[] Icon_001;
    GameObject[] Icon_003;

    Color Icon_001_color;
    Color Icon_003_color;

    string paletteName;



    public void ApplyColor()
    {
        paletteName = transform.parent.name;

        PlayerPrefs.SetString("paletteName", paletteName);
        Icon_001_color = transform.parent.Find("Image_Icon_001").GetComponent<Image>().color;
        Icon_001_color = transform.parent.Find("Image_003").GetComponent<Image>().color;

        GameObject.Find("UI_ColorManager").GetComponent<ColorManager>().Icon_001 = Icon_001_color;

        Icon_001 = GameObject.FindGameObjectsWithTag("Icon_001");
        for (int i = 0; i < Icon_001.Length; i++)
        {

            Icon_001[i].GetComponent<Image>().color = Icon_001_color;
        }

        Icon_003 = GameObject.FindGameObjectsWithTag("Icon_003");
        for (int i = 0; i < Icon_001.Length; i++)
        {

            Icon_001[i].GetComponent<Image>().color = Icon_003_color;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
