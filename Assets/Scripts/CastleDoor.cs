using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastleDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Castle trigger con: {other.tag}");
    
        if (other.CompareTag("Player"))
        {
            Debug.Log("Castle: llamando NextLevel");
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(1f);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.NextLevel();
        }
        else
        {
            int next = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(next);
        }
    }
}