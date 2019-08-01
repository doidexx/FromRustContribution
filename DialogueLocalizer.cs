using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLocalizer : MonoBehaviour {

    LanguageManager languageManager;
    Text Dialogue;

	void Start () {
        languageManager = FindObjectOfType<LanguageManager>();
        Dialogue = GetComponent<Text>();
    }

    void Update()
    {
        if (Dialogue.enabled)
        {
            TranslateText();
        }    
    }

    public void TranslateText()
    {
        Dialogue.text = (Dialogue.text.StartsWith("%")) ? languageManager.TranslateString(LanguageManager.Category.Dialogues, Dialogue.text) : Dialogue.text;
    }
}
