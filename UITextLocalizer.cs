using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextLocalizer : MonoBehaviour {

    LanguageManager languageManager;
    Text UItext;

	void Start () {
        languageManager = FindObjectOfType<LanguageManager>();
        UItext = GetComponent<Text>();
    }

    void Update()
    {
        if (UItext.enabled)
        {
            TranslateText();
        }    
    }

    public void TranslateText()
    {
        UItext.text = (UItext.text.StartsWith("%")) ? languageManager.TranslateString(LanguageManager.Category.UI, UItext.text) : UItext.text;
    }
}
