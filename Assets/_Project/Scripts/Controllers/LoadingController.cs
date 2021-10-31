using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public sealed class LoadingController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _loadgingInfo;
    [SerializeField] private Image _fillBar;    
    
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private IEnumerator LoadAsync()
    {
        AsyncOperation loadScene = SceneManager.LoadSceneAsync(3);

        while (loadScene.progress < 1)
        {
            _fillBar.fillAmount = loadScene.progress;
            _loadgingInfo.text = (loadScene.progress * 100).ToString() + " %";            
            yield return new WaitForEndOfFrame();
        }        
    }
}
