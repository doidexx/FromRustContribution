using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryScreenButtonsBehavior : MonoBehaviour
{
    [Header("Internal References")]
    [SerializeField]
    Image glow;

    [SerializeField]
    TextMeshProUGUI label;

    [SerializeField]
    float raisedY;

    [SerializeField]
    float loweredY;

    public void SetToActive()
    { 
        glow.enabled = true;
        label.color = new Color(1, 1, 1, 1);
        transform.DOLocalMoveY(raisedY, .5f);
    }

    public void SetToInactive()
    {
        glow.enabled = false;
        label.color = new Color(1, 1, 1, 0.5f);
        transform.DOLocalMoveY(loweredY, .5f);
    }
}

