using UnityEngine;
using DG.Tweening;

public class AttackAnimator : MonoBehaviour
{
    public void AttackAnim()
    {
        transform.DOScale(1.2f, 0.3f).OnComplete(() => transform.DOScale(1f, 0.3f));
    }
}
