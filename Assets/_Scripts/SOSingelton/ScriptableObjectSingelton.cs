using UnityEngine;

//Make sure that the scriptable object you'll create is inside the Resources folder and its name matches the name of the class
namespace SO_Base
{
    public abstract class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObjectSingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Resources.Load<T>(typeof(T).Name);
                    if (_instance == null)
                    {
                        Debug.LogError("Failed to load ScriptableObject instance of type: " + typeof(T).Name);
                    }
                    //Debug.Log(_instance.name + " is activated");
                }
                return _instance;
            }
        }

        public abstract void Enable();
    }
}