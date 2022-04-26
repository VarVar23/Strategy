using System.Reflection;
using System;

public static class AssetsInjector 
{
    private static readonly Type _injectAssetAttributeType = typeof(InjectAssetAttribute);

    public static T Inject<T>(this AssetsContext context, T target)
    {
        var targetType = target.GetType();
        

        while(targetType != null)
        {
            var allFields = targetType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < allFields.Length; i++)
            {
                var fieldInfo = allFields[i];
                var injectAssetsAttribute = fieldInfo.GetCustomAttributes(_injectAssetAttributeType) as InjectAssetAttribute;

                if (injectAssetsAttribute == null) continue;

                var objectToInject = context.GetObjectOfType(fieldInfo.FieldType, injectAssetsAttribute.AssetName);
                fieldInfo.SetValue(target, objectToInject);
            }

            targetType = targetType.BaseType;
        }


        return target;
    }
}
