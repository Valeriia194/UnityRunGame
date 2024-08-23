using System;
using System.Collections.Generic;
using Assets.Scripts.Project;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelecLanguageView : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private ILocalizationService localizationService;
    private void Start()
    {
        localizationService = ProjectContext.Instance.LocalizationService;
        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var langKey in localizationService.LanguagesKeys)
        {
            options.Add(new TMP_Dropdown.OptionData(langKey));
        }

        dropdown.options = options;
        dropdown.onValueChanged.AddListener(OnLangChanged);

        for (int i = 0; i < localizationService.LanguagesKeys.Length; ++i)
        {
            if (localizationService.LanguagesKeys[i] == localizationService.CurrentLanguageKey)
                dropdown.value = i;
        }
    }

    private void OnLangChanged(int index)
    {
        localizationService.CurrentLanguageKey = dropdown.options[index].text;
    }
}