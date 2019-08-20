using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class gameoverbutton : MonoBehaviour
{
    Sequence menuSequence;
    public Transform playGame;
    // Start is called before the first frame update
    void Start()
    {
        menuSequence = DOTween.Sequence();

        menuSequence.Append(transform.DOLocalMoveY(-5, 2).SetEase(Ease.OutBack, 2).SetDelay(1.0f));

        DOTween.To(() => transform.position, x => transform.position = x, new Vector3(680, 0, 0), 0.5f);

        playGame.transform.DOLocalMove(new Vector3(0, -10, 0), 0.5f);
    }

    
}
