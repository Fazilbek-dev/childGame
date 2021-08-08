using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ListVariants : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _variants;

    [SerializeField] private List<Sprite> _sprites;

    [SerializeField] private Text _questionText;
    [SerializeField] private string _questionLetter;

    [SerializeField] private GameObject _questText;
    [SerializeField] private GameObject _level;

    [SerializeField] private ParticleSystem _particle;

    [SerializeField] private CanvasButton _cnButton;



    private void Start()
    {
        RandomLetter();
        QuestionFindLetter();
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.GetComponent<SpriteRenderer>().sprite.name);
                if(_questionLetter == hit.collider.GetComponent<SpriteRenderer>().sprite.name)
                {
                    Debug.Log(_variants.Count);
                    Debug.Log(hit.collider.GetComponent<SpriteRenderer>().sprite.name);
                    QuestionFindLetter();
                    hit.collider.GetComponent<SpriteRenderer>().sprite = null;

                    Instantiate(_particle, hit.collider.transform);

                    _particle.Play();
                }
                else
                {
                    hit.collider.transform.DOShakeRotation(2f, 90f, 10, 90f, true);
                    hit.collider.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    private void RandomLetter()
    {
        foreach( var i in _variants)
        {
            System.Random n = new System.Random((int)DateTime.Now.Ticks);
            int spriteRandom = n.Next(0, _sprites.Count);
            i.sprite = _sprites[spriteRandom];
            _sprites.RemoveAt(spriteRandom);
        }
    }

    private void QuestionFindLetter()
    {

        System.Random r = new System.Random((int)DateTime.Now.Ticks);

        int find = r.Next(0, _variants.Count);


        try
        {
            _questionText.text = "Find " + _variants[find].sprite.name;
            _questionLetter = _variants[find].sprite.name;
        }
        catch(Exception exp)
        {
            Debug.Log(exp);
            _cnButton.HomeMenu();
            _level.SetActive(false);
            _questText.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        _variants.RemoveAt(find);
    }
}
