using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class SearchBar : MonoBehaviour {

    [SerializeField]
    InputField field;
    
    [SerializeField]
    KeywordGlossaryManager glossaryHolder;

    List<GameObject> keywordGameObj;

    void Start ()
    {
        field.onValueChanged.AddListener(OnInputChange);
        keywordGameObj = glossaryHolder.KeywordObj;
    }

    public void OnInputChange(string input)
    {
        var keywordSearch = (from key in keywordGameObj
                            where key.GetComponent<TextMeshProUGUI>().text.StartsWith(input, true, new System.Globalization.CultureInfo("en-US", false))
                            select key).ToList();
        for (int i = 0; i < keywordGameObj.Count; i++)
        {
            bool active = keywordSearch.Contains(keywordGameObj[i]);
            keywordGameObj[i].SetActive(active);
        }
    }

    public void DeleteButton()
    {
        field.text = "";
    }
}
