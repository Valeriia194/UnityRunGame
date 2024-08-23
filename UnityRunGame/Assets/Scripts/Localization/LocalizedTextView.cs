using System;
using Assets.Scripts.Project;
using TMPro;
using UnityEngine;

public class LocalizedTextView : MonoBehaviour
{
    [SerializeField] private string key;
    [SerializeField] private TextMeshProUGUI text;
    private ILocalizationService localizationService;
    private object[] parameters;

    private void Start()
    {
        localizationService = ProjectContext.Instance.LocalizationService;
        localizationService.OnLanguageChanged += SetLocalizedText;
        SetLocalizedText();
    }

    private void OnDestroy()
    {
        localizationService.OnLanguageChanged -= SetLocalizedText;
    }

    private void SetLocalizedText()
    {
        string localizedText = localizationService.GetLocalizedValue(key);
        if (parameters != null)
        {
            text.text = string.Format(localizedText, parameters);
        }
        else
        {
            text.text = localizedText;
        }
    }

    public void SetParams(params object[] parameters)
    {
        this.parameters = parameters;
        SetLocalizedText();
    }
}