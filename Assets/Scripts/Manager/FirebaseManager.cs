using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using System;
using UnityEngine;

public class FirebaseManager : ISingleton<FirebaseManager>
{

    public bool IsInit { get; private set; }

    private FirebaseApp App;
    private DatabaseReference DataReference;

    public FirebaseManager()
    {
        IsInit = false;
    }

    public void InitFirebase()
    {
        Debug.Log("FirebaseManager start init! ");
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            Firebase.DependencyStatus dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                App = Firebase.FirebaseApp.DefaultInstance;
                Debug.Log("FirebaseManager Unity SDK init success! ");
                IsInit = true;
                DataReference = FirebaseDatabase.DefaultInstance.RootReference;

            }
            else
            {
                Debug.LogWarning("FirebaseManager Unity SDK is not safe to use here");
            }
        });
    }

    public void WriteProfileData(string key, string data)
    {
        if (IsInit)
        {
            Debug.Log($"FirebaseManager WriteProfileData data = {data}");
            System.Threading.Tasks.Task rs = DataReference.Child("PlayerData/player01").SetRawJsonValueAsync(data);
        }
    }

    public void ReadProfileData(string key, Action<bool, string> callback)
    {
        if (IsInit)
        {
            Debug.Log("FirebaseManager ReadProfileData ");
            FirebaseDatabase.DefaultInstance.GetReference("PlayerData/player01").GetValueAsync().ContinueWithOnMainThread(task =>
            {
                if (task.IsFaulted)
                {
                    Debug.LogWarning("FirebaseManager Handle the error...");
                    callback?.Invoke(false, null);
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    Debug.Log($"FirebaseManager Data {snapshot.GetRawJsonValue()}");
                    callback?.Invoke(true, snapshot.GetRawJsonValue());
                }
            });
        }
    }

}

