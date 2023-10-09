using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageSettings : MonoBehaviour
{
    public string En;
    public string Tr;
    public string textt;
    public Text textte;
    void Start()
    {
        textte = GetComponent<Text>();
    }


    void Update()
    {

        textte.text = textt;

        if (GameObject.Find("ButtonManager").GetComponent<ButtonManager>().languageEn)
        {
            textt = En;

        }

        if (GameObject.Find("ButtonManager").GetComponent<ButtonManager>().languageTr)
        {
            textt = Tr;

           
        }
    }
}
