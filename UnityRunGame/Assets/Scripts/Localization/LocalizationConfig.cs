using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LocalizationConfig", menuName = "MyGame/LocalizationConfig")]
public class LocalizationConfig : ScriptableObject
{
    public LocalizationKey[] localizationKeys;

}

[Serializable]
public struct LocalizationKey
{
    public string key;
    public LocalizationValue[] values;
}

[Serializable]
public struct LocalizationValue
{
    public string languageKey;
    public string value;
}