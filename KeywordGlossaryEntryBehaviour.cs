using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class KeywordGlossaryEntryBehaviour : MonoBehaviour, IPointerClickHandler
{

    static KeywordGlossaryEntryBehaviour currentSelection;

    private TextMeshProUGUI keywordDescription;


    [SerializeField]
    Image selectionKeyword;


    //Initialize Keyword Title & Description
    public void Initialize(TextMeshProUGUI description)
    {
        keywordDescription = description;
        if (currentSelection == null)
        {
            OnClick();
        }
    }

    //Keyword Click Behavior
    public void OnClick()
    {
        if (currentSelection != null)
        {
            currentSelection.DeactivateKeyword();
        }

        keywordDescription.text = GetComponent<KeywordDataPopulator>().SourceKeywordDescription;

        selectionKeyword.enabled = true;
        currentSelection = this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick();
    }

    //Deactivate selectionIcon
    public void DeactivateKeyword()
    {
        selectionKeyword.enabled = false;
    }
}

