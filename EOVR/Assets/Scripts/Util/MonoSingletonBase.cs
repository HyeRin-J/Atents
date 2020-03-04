using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class MonoSingletonBase<T> : MonoBehaviour where T : class
{

    private static T singleTonObject;
    public virtual void Awake()
    {
        singleTonObject = this as T;
    }
    public static T Instance
	{
        get
        {
            return singleTonObject;
        }
    }
}