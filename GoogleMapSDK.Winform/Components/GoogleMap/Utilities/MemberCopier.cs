using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Components.GoogleMap.Utilities
{
    using System;
    using System.Reflection;

    public static class MemberCopier
    {
        public static void Copy(object source, object target)
        {
            if (source == null || target == null) return;

            Type sourceType = source.GetType();

            // 遍歷 source 的 properties
            foreach (var sourceMember in sourceType.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                object value = GetValue(source, sourceMember);
                if (value == null) continue;

                // 嘗試設定到目標的同名 Property 或 Field
                SetValueIfMatch(target, sourceMember.Name, value);
            }
        }

        private static object GetValue(object obj, MemberInfo member)
        {
            var prop = member as PropertyInfo;
            if (prop != null && prop.CanRead)
            {
                return prop.GetValue(obj);
            }

            var field = member as FieldInfo;
            if (field != null)
            {
                return field.GetValue(obj);
            }

            return null;
        }

        private static void SetValueIfMatch(object target, string name, object value)
        {
            Type targetType = target.GetType();
            
            // 優先找對應的 Property
            var targetProp = targetType.GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (targetProp != null && targetProp.CanWrite && IsTypeCompatible(targetProp.PropertyType, value))
            {
                targetProp.SetValue(target, value);
                return;
            }

            // 再找對應的 Field
            var targetField = targetType.GetField(name, BindingFlags.Public | BindingFlags.Instance);
            if (targetField != null && IsTypeCompatible(targetField.FieldType, value))
            {
                targetField.SetValue(target, value);
            }
        }

        private static bool IsTypeCompatible(Type targetType, object value)
        {
            return value != null && targetType.IsAssignableFrom(value.GetType());
        }
    }
}
