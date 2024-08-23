using System.Collections.Generic;
using System;
using System.Linq;

public interface ILocalizationService
{
    event Action OnLanguageChanged;
    string CurrentLanguageKey { get; set; }
    string[] LanguagesKeys { get; }
    string GetLocalizedValue(string key);
}

public class LocalizationService : ILocalizationService
{
    private const string SaveKey = "SelectedLanguage";
    public event Action OnLanguageChanged;
    private Dictionary<string, Dictionary<string, string>> localizationDictionary;

    public string[] LanguagesKeys { get; }
    private string currentLanguageKey;

    public string CurrentLanguageKey
    {
        get => currentLanguageKey;

        set
        {
            currentLanguageKey = value;
            OnLanguageChanged?.Invoke();

        }
    }

    public LocalizationService(IDataService dataService)
    {
        currentLanguageKey = "UA";
        localizationDictionary = new();

        LanguagesKeys = SetLanguageDictionary(dataService);
    }

    private string[] SetLanguageDictionary(IDataService dataService)
    {
        HashSet<string> langKeys = new HashSet<string>();
        foreach (var locKey in dataService.Localization)
        {
            localizationDictionary.Add(locKey.key, new Dictionary<string, string>());
            foreach (var value in locKey.values)
            {
                localizationDictionary[locKey.key][value.languageKey] = value.value;
                if (!langKeys.Contains(value.languageKey))
                {
                    langKeys.Add(value.languageKey);
                }
            }
        }
        return langKeys.ToArray();
    }


    public string GetLocalizedValue(string key)
    {
        if (localizationDictionary.ContainsKey(key) && localizationDictionary[key].ContainsKey(CurrentLanguageKey))
            return localizationDictionary[key][CurrentLanguageKey];
        return key;
    }
}

[Serializable]
public class SelectedLanguage
{
    public string currentLanguageKey;
}