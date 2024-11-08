using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Animator animator; // Menambahkan animator sesuai diagram

    void Awake()
    {
        // Lakukan sesuatu di Awake, misalnya mengatur animator atau objek lainnya
        animator.enabled = false; // Contoh untuk menyembunyikan animasi
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.SetTrigger("FadeOut"); // Memicu transisi sebelum memuat scene
        yield return new WaitForSeconds(1); // Menunggu transisi selesai

        SceneManager.LoadSceneAsync(sceneName); // Memuat scene baru

        // Menyetel posisi pemain setelah scene dimuat
        Player.Instance.transform.position = new Vector3(0, -4.5f, 0);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName)); 
    }
}
