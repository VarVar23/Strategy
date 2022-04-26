using System;
using UnityEngine;
using Object = UnityEngine.Object;


[CreateAssetMenu(fileName = "AssetsContext", menuName = "Config/AssetsContext", order = 0)]
public class AssetsContext : ScriptableObject
{
    [SerializeField] private Object[] _objects;

    public Object GetObjectOfType(Type targetType, string targetName = null)
    {
        var obj = _objects[0];

        for(int i = 0; i < _objects.Length; i++)
        {
            obj = _objects[i];
            
            if(obj.GetType().IsAssignableFrom(targetType))
            {
                if(targetName == null || targetName == obj.name) return obj;
            }
        }

        return null;
    }
}

