using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CanvasButton : MonoBehaviour
{

    [SerializeField] private List<GameObject> _levelsMenu;
    [SerializeField] private List<GameObject> _levels;

    [SerializeField] private float _scale = 1.15f;
    [SerializeField] private float _scaleTime = 2f;

    [SerializeField] private GameObject _homeMenu;
    [SerializeField] private GameObject _questionText;

    public void LevelsButtonOpen()
    {
        foreach(GameObject level in _levelsMenu)
        {
            level.SetActive(true);
        }
    }
    public void LevelsButtonClose()
    {
        _homeMenu.SetActive(false);
    }

    public void HomeMenu()
    {
        _homeMenu.SetActive(true);
        _levels[0].SetActive(false);
        _levels[1].SetActive(false);
        _levels[2].SetActive(false);
        _questionText.SetActive(false);
    }
    public void levelsEasy()
    {
        LevelSettings(true, false, true, 0);
    }
    public void levelsMedium()
    {
        LevelSettings(true, false, true, 1);
    }
    public void levelsHard()
    {
        LevelSettings(true, false, true, 2);
    }

    private void LevelSettings(bool questText, bool homeMenu, bool level, int whichLevel)
    {
        _levels[whichLevel].SetActive(level);
        _levels[whichLevel].transform.DOScaleX(_scale, _scaleTime);
        _levels[whichLevel].transform.DOScaleY(_scale, _scaleTime);
        _questionText.SetActive(questText);
        _homeMenu.SetActive(homeMenu);
        
    }
}
