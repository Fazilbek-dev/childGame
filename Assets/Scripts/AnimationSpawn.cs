using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AnimationSpawn : MonoBehaviour
{
    [SerializeField] private Transform _tableMedium;

    private void Update()
    {
        _tableMedium.DOScaleX(1f, 5);
        _tableMedium.DOScaleY(1f, 5);
    }
}
