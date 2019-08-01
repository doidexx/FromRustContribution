using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class KeywordDataPopulator : MonoBehaviour
{
    LanguageManager languageManager;

    public Keyword keywordAsset;

    [Header("References")]
    [SerializeField]
    String sourceKeywordTitle;

    public string SourceKeywordTitle { get { return sourceKeywordTitle; } }

    [SerializeField]
    String sourceKeywordDescription;

    public string SourceKeywordDescription { get { return sourceKeywordDescription; } }

    [SerializeField]
    TextMeshProUGUI titleLabel;

    public void ReadKeywordFromAsset()
    {
        languageManager = FindObjectOfType<LanguageManager>();
        //sourceKeywordTitle = keywordAsset.Title;
        //sourceKeywordDescription = keywordAsset.Description;
        if (sourceKeywordTitle != null)
        {
            sourceKeywordTitle = (keywordAsset.Title.StartsWith("%")) ? languageManager.TranslateString(LanguageManager.Category.Keywords, keywordAsset.Title) : keywordAsset.Title;
            titleLabel.text = (keywordAsset.Title.StartsWith("%")) ? languageManager.TranslateString(LanguageManager.Category.Keywords, keywordAsset.Title) : keywordAsset.Title;
        }
        if (sourceKeywordDescription != null)
        {
            sourceKeywordDescription = (keywordAsset.Description.StartsWith("%")) ? languageManager.TranslateString(LanguageManager.Category.Keywords, keywordAsset.Description) : keywordAsset.Description;
        }
    }
}
