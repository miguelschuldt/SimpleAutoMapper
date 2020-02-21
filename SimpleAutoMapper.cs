using System;
using System.Reflection;

namespace SimpleAutoMapper
{
    public class SimpleAutoMapper<W> where W : class, new()
    {
        public W Map(object origin)
        {
            Type WType = typeof(W);
            Type OriginType = origin.GetType();
            W w = new W();
            foreach (PropertyInfo property in WType.GetProperties())
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
