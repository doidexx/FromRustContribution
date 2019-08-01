using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class LanguageManager : MonoBehaviour {

    [SerializeField]
    TextAsset cards, dialogues, ui, keywords;

    TextAsset currentCat;

    UITextLocalizer uITextLocalizer;

    Language selectedLang;

    public enum Category
    {
        Cards,
        Dialogues,
        Keywords,
        UI
    };

    //Dictionary that contains all Dictionaries.
    Dictionary<Category, Dictionary<string, Dictionary<Language, string>>> specificDictionary = new Dictionary<Category, Dictionary<string, Dictionary<Language, string>>>();

    //Dictionary that contains all lists.
    Dictionary<string, Dictionary<Language, string>> fullDictionary = new Dictionary<string, Dictionary<Language, string>>();

    void Start()
    {
        selectedLang = Language.English;
        DontDestroyOnLoad(this.gameObject);
        LanguageDictionary();
        uITextLocalizer = FindObjectOfType<UITextLocalizer>();
    }

    void LanguageDictionary()
    {
        List<List<string>> cardList = TableParser.GetRecordsFromCSV(cards);
        List<List<string>> dialogueList = TableParser.GetRecordsFromCSV(dialogues);
        List<List<string>> keywordList = TableParser.GetRecordsFromCSV(keywords);
        List<List<string>> uiList = TableParser.GetRecordsFromCSV(ui);
        foreach (List<string> list in cardList)
        {
            var variableName = list[0];
            var englishName = list[1];
            var spanishName = list[2];
            Dictionary<Language, string> langDict = new Dictionary<Language, string>();
            langDict.Add(Language.English, englishName);
            langDict.Add(Language.Spanish, spanishName);
            fullDictionary.Add(variableName, langDict);
        }
        foreach (List<string> list in uiList)
        {
            var variableName = list[0];
            var englishName = list[1];
            var spanishName = list[2];
            Dictionary<Language, string> langDict = new Dictionary<Language, string>();
            langDict.Add(Language.English, englishName);
            langDict.Add(Language.Spanish, spanishName);
            fullDictionary.Add(variableName, langDict);
        }
        foreach (List<string> list in dialogueList)
        {
            var variableName = list[0];
            var englishName = list[1];
            var spanishName = list[2];
            Dictionary<Language, string> langDict = new Dictionary<Language, string>();
            langDict.Add(Language.English, englishName);
            langDict.Add(Language.Spanish, spanishName);
            fullDictionary.Add(variableName, langDict);
        }
        foreach (List<string> list in keywordList)
        {
            var variableName = list[0];
            var englishName = list[1];
            var spanishName = list[2];
            Dictionary<Language, string> langDict = new Dictionary<Language, string>();
            langDict.Add(Language.English, englishName);
            langDict.Add(Language.Spanish, spanishName);
            fullDictionary.Add(variableName, langDict);
        }
        specificDictionary.Add(Category.Keywords, fullDictionary);
        specificDictionary.Add(Category.Cards, fullDictionary);
        specificDictionary.Add(Category.UI, fullDictionary);
        specificDictionary.Add(Category.Dialogues, fullDictionary);
    }

    public string TranslateString (Category category, string toTranslate)
    {
        Debug.Log(category);
        var translated = specificDictionary[category][toTranslate][selectedLang];
        if (translated == null)
        {
            return toTranslate;
        }
        return translated;
    }

    public void activateEnglish()
    {
        selectedLang = Language.English;
    }

    public void activateSpanish()
    {
        selectedLang = Language.Spanish;
    }

}
