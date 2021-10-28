using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaryController : MonoBehaviour
{
    public string sceneName;
    public AudioSource warySound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("LoadNextScene", 0.6f);
            //การบันทึกการ wary ล่าสุด (การบันทึก Scene ตอน Wary)
            PlayerPrefs.SetString("PrevScene", sceneName);

            //บันทึกจำนวนเหรียญ
            var player = other.gameObject.GetComponent<PlayerControllerRigidbody>();
            PlayerPrefs.SetInt("CoinCount", player.coinCount);

            warySound?.Play();
            /*if(warySound != null)
             {
                 warySound.Play();
             }*/
        }
    }
    
    void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
