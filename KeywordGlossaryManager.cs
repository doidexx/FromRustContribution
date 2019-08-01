using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class KeywordGlossaryManager : MonoBehaviour
{
    KeywordDataPopulator keywordData;

    [SerializeField]
    GameObject keywordPrefab;

    [SerializeField]
    TextMeshProUGUI keywordDescription;

    [SerializeField]
    List<Keyword> keywordAssets;

    [SerializeField]
    GameObject glossaryPanel;

    [SerializeField]
    List<GameObject> keywordObj;

    public List<GameObject> KeywordObj { get { return keywordObj; } }

    void Start()
    {
        keywordData = FindObjectOfType<KeywordDataPopulator>();
        PopulateGrid();
    }

    void PopulateGrid()
    {
        // Order keys alphabetically
        var keywordOrder = (from keys in keywordAssets
                            where keys.Title != null
                            orderby keys.Title ascending
                            select keys).ToList();

        for (int i = 0; i < keywordAssets.Count; i++)
        {
            GameObject newObj;
            newObj = (GameObject)Instantiate(keywordPrefab, transform);

            //Setting asset
            newObj.GetComponent<KeywordDataPopulator>().keywordAsset = keywordOrder[i];

            //populate asset
            newObj.GetComponent<KeywordDataPopulator>().ReadKeywordFromAsset();

            //Populate Info
            newObj.GetComponent<KeywordGlossaryEntryBehaviour>().Initialize(keywordDescription);

            keywordObj.Add(newObj);
        }
    }
}
