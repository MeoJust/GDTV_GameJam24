using UnityEngine;
using DG.Tweening;
using TMPro;

public class TextAnimator : MonoBehaviour
{
    void Start()
    {
        Invoke(nameof(ShowTXT), 2f);
        Invoke(nameof(HideTXT), 6f);
    }
    void ShowTXT()
    {
        GetComponent<TextMeshProUGUI>().DOFade(1, 3);
    }

    void HideTXT()
    {
        GetComponent<TextMeshProUGUI>().DOFade(0, 3);
    }
}
