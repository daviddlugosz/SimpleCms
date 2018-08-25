using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataLogic.Helpers
{
    public static class GenericMapper
    {
        private static string[] propertiesToExclude = { "password", "author" };

        // TODO: Use custom attribute for exluded properties
        public static T MapObject<T>(object inputObject) where T : new()
        {
            T outputObject = new T();

            if (propertiesToExclude != null)
                propertiesToExclude = propertiesToExclude.Select(x => x.ToLower()).ToArray();

            try
            {
                foreach(var property in inputObject.GetType().GetProperties())
                {
                    string propertyName = property.Name;

                    if (propertiesToExclude != null &&
                        propertiesToExclude.Contains(propertyName.ToLower()))
                        continue;

                    object inputPropertyValue = inputObject.GetType().GetProperty(propertyName).GetValue(inputObject);
                    if (inputPropertyValue == null)
                        continue;

                    TrySetProperty(outputObject, propertyName,
                        inputPropertyValue);  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outputObject;
        }

        public static IList<T> MapListOfObjects<T>(IEnumerable<object> inputList) where T : new()
        {
            List<T> outputList = new List<T>();

            try
            {
                foreach(var listItem in inputList)
                {
                    T outputObject = MapObject<T>(listItem);
                    outputList.Add(outputObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return outputList;
        }

        private static void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }

    }
}
