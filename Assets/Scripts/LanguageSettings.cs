using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Settings;


public class LanguageSettings : MonoBehaviour
{
    private bool active = false;

    public void ChangeLocale(int localID)
    {
        if (active == true)
            return;
        StartCoroutine(SetLocale(localID));
    }


    IEnumerator SetLocale(int _localID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localID];
        active = false;
    }
}
