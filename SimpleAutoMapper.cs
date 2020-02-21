using System;
using System.Reflection;

namespace SimpleAutoMapper
{
    public class SimpleAutoMapper<D> where D : class, new()
    {
        public D Map(object origin)
        {
            Type OriginType = origin.GetType();
            D w = new D();
            foreach (PropertyInfo property in typeof(D).GetProperties())
            {
                PropertyInfo OriginProperty = OriginType.GetProperty(property.Name);
                if (OriginProperty != null) 
                {
                    try
                    {
                        property.SetValue(w, OriginProperty.GetValue(origin));
                    }
                    catch { }
                }
            }
            return w;
        }
    }
}
