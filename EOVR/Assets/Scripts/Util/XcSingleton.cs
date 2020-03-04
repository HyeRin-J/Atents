using System;

public class XcSingleton<T> where T : class, new()
{
    private static object m_syncobj = new object();
    private static volatile T m_instance = null;
    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                lock (m_syncobj)
                {
                    if (m_instance == null)
                    {
                        m_instance = new T();
                    }
                }
            }
            return m_instance;
        }
    }

    public XcSingleton()
    { }
}