using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ChupaChupa.Service.Tool
{
    public class MessageMapper<T, U> where T : class, new() where U : class, new()
    {
        public T map(U obj) {
            T ret = new T();

            if (obj == null) {
                return ret;
            }

            PropertyInfo[] propertiesIn = typeof(U).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] propertiesOut = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyIn in propertiesIn) {
                bool found = false;
                for (int i = 0; i < propertiesOut.Length && !found; ++i) {
                    if (propertyIn.Name.CompareTo(propertiesOut[i].Name) == 0) {
                        mapProperty(obj, propertyIn, ret, propertiesOut[i]);
                        found = true;
                    }
                }
            }
            return ret;
        }

        private void mapProperty(U objIn, PropertyInfo propertyIn, T objOut, PropertyInfo propertyOut) {
            if (isBasicType(propertyIn.PropertyType)) {
                propertyOut.SetValue(objOut, propertyIn.GetValue(objIn));            
            } else if (propertyIn.PropertyType.IsGenericType && propertyIn.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)) {
                var listIn = propertyIn.GetValue(objIn) as IList;

                if (propertyOut.PropertyType == typeof(Int64)) {
                    if (listIn != null) {
                        propertyOut.SetValue(objOut, listIn.Count);
                    } else {
                        propertyOut.SetValue(objOut, 0);
                    }
                } else {
                    var listOut = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(propertyOut.PropertyType.GetGenericArguments()[0]));

                    if (listIn != null)
                    {
                        foreach (var element in listIn)
                        {
                            var type = typeof(MessageMapper<,>).MakeGenericType(propertyOut.PropertyType.GetGenericArguments()[0], propertyIn.PropertyType.GetGenericArguments()[0]);
                            var mapper = Activator.CreateInstance(type);
                            var mapFunc = type.GetMethod("map");
                            listOut.Add(mapFunc.Invoke(mapper, new object[] { element }));
                        }
                    }
                    propertyOut.SetValue(objOut, listOut);
                }
            } else {
                var type = typeof(MessageMapper<,>).MakeGenericType(propertyOut.PropertyType, propertyIn.PropertyType);
                var mapper = Activator.CreateInstance(type);
                var mapFunc = type.GetMethod("map");
                propertyOut.SetValue(objOut, mapFunc.Invoke(mapper, new object[] { propertyIn.GetValue(objIn) } ));
            }
        }

        private bool isBasicType(Type inputType) {
            if (inputType == typeof(Int16) || inputType == typeof(Int32) || inputType == typeof(Int64)
                || inputType == typeof(String) || inputType == typeof(DateTime) || inputType == typeof(Nullable<DateTime>)) {
                    return true;
            }
            return false;
        }
    }
}