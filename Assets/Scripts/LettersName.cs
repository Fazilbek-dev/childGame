using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LettersName : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("click");
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.tag == "string")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    private void Update()
    {
        
    }
}
