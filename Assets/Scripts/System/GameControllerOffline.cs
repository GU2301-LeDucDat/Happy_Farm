
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerOffline : MonoBehaviour
{
    public bool loadingDone = false;
    private void Start()
    {
        StartCoroutine(loadingStep());
    }

    private IEnumerator loadingStep()
    {
        Debug.Log("Controller loading step 0: Firebase");
        FirebaseManager.Instance.InitFirebase();
        yield return new WaitUntil(() => (FirebaseManager.Instance.IsInit == true));

        Debug.Log("Controller loading step 1: Item data");
        ItemManager.Instance.InitData();
        yield return new WaitUntil(() => (ItemManager.Instance.IsInit == true));

        Debug.Log("Controller loading step 2: Notification");
        //StartCoroutine(NotificationManager.Instance.RequestNotificationPermission());
        //yield return new WaitUntil(() => (NotificationManager.Instance.IsInit == true));

        Debug.Log("Controller loading step 3: PLayerProfile");
        PlayerProfile.Instance.InitProfile();
        yield return new WaitUntil(() => (PlayerProfile.Instance.IsInit == true));
        Debug.Log("Controller loading step 4: Scene");
        SceneManager.LoadScene("GamePlay");

        loadingDone = true;
        yield return null;
    }
}
