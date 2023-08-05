using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneForPlayerSaveState : MonoBehaviour
{
    //private Coroutine _coroutine;
    //[SerializeField]
    //private string _sceneForSaveExists;
    //[SerializeField]
    //private string _sceneForNoSave;
    //private void Start()
    //{
    //}
    //public void Trigger()
    //{
    //    if(_coroutine == null)
    //    {
    //        _coroutine = StartCoroutine(LoadSceneCoroutine());
    //    }
    //}

    //IEnumerator LoadSceneCoroutine()
    //{
    //    yield return new WaitUntil(() => ItemManager.Instance.IsInit == true);
    //    var saveExistsTask = ItemManager.Instance.SaveExists();
    //    yield return new WaitUntil(predicate: () => saveExistsTask.IsCompleted);
    //    if(saveExistsTask.Result)
    //    {
    //        SceneManager.LoadScene(_sceneForSaveExists);
    //    } else
    //    {
    //        SceneManager.LoadScene(_sceneForNoSave);
    //    }
        
    //}
}
