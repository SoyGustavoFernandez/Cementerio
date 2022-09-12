using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace Microsoft.ApplicationBlocks.Data
{
    public static class DataReaderHelper
    {
        public static T DataReaderMapToEntidad<T>(SqlDataReader dr)
        {
            T obj = default(T);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    foreach (PropertyInfo prop in propertyInfos)
                    {
                        if (prop.Name.ToUpper() == dr.GetName(i).ToUpper())
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                                prop.SetValue(obj, dr[prop.Name], null);
                            break;
                        }
                    }
                }
            }
            return obj;
        }
        public static List<T> DataReaderMapToList<T>(SqlDataReader dr)
        {
            List<T> lst = new List<T>();
            T obj = default(T);
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    foreach (PropertyInfo prop in propertyInfos)
                    {
                        if (prop.Name.ToUpper() == dr.GetName(i).ToUpper())
                        {
                            if (!object.Equals(dr[prop.Name], DBNull.Value))
                                prop.SetValue(obj, dr[prop.Name], null);
                            break;
                        }
                    }
                }
                lst.Add(obj);
            }
            return lst;
        }
    }
}
