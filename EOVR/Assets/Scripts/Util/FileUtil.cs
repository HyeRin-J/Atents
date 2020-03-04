using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileUtil
{
	public static T Get<T>(Dictionary<string, string> _data, string _key, T def = default(T))
	{
		if (false == _data.ContainsKey(_key))
		{
			Debug.LogError("Get<" + typeof(T).ToString() + ">  [not find] : " + _key);
			return def;
		}

		string _temp = _data[_key];
		if (null == _temp)
		{
			Debug.LogError("Get[null == _temp]");
			return def;
		}

		if (_temp.Length <= 0)
		{
			if (typeof(string) == typeof(T))
				return (T)((object)_temp);

			return def;
		}

        //try
       // {
			if (true == typeof(T).IsEnum)
			{
				return (T)Enum.Parse(typeof(T), _temp, true);
			}
			else
			{
				if (typeof(int) == typeof(T))
				{
					return (T)((object)int.Parse(_temp));
				}
				else if (typeof(long) == typeof(T))
				{
					return (T)((object)long.Parse(_temp));
				}
				else if (typeof(float) == typeof(T))
				{
					return (T)((object)float.Parse(_temp));
				}
				else if (typeof(bool) == typeof(T))
				{
					return (T)((object)bool.Parse(_temp));
				}
				else if (typeof(string) == typeof(T))
				{
					return (T)((object)_temp);
				}
                else if (typeof(int[]) == typeof(T))
                {
                    string[] temp = _temp.Split(',');
                    int[] _tempInt = new int[temp.Length];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        _tempInt[i] = int.Parse(temp[i]);
                    }

                    return (T)((object)_tempInt);
                }
                else
				{
					Debug.LogError("Get<" + typeof(T).ToString() + "> - [" + _key + "] : " + _temp);
				}
			}
		/*}

        catch
        {
			Debug.LogError("Get< catch : " + typeof(T).ToString() + "> - [" + _key + "] : " + _temp);
		}*/

		return def;
	}	

    static public string GetResPath( string _filename)
    {
        return string.Format("{0}/Resources/{1}.bytes", Application.dataPath, _filename);
    }

    static public string GetFilePath( string _filename)
    {
        return string.Format("{0}/{1}.bytes", Application.persistentDataPath, _filename);
    }

    #region -serialize
    static public bool BinarySerialize<T>(T t, string _path)
    {
        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Create);
            formatter.Serialize(stream, t);
            stream.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError(e);
            //Debug.LogError("FileUtile::BinarySerialize()[ path : " + _path + " exception : " + e.ToString());
            return false;
        }

        return true;
    }
    static public T BinaryDeserialize<T>(string _path)
    {
        //try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_path, FileMode.Open);
            T t = (T)formatter.Deserialize(stream);
            stream.Close();
            return t;
        }
        //catch (System.Exception e)
        {
            //Debug.LogError("FileUtile::BinarySerialize()[ path : " + _path + " exception : " + e.ToString());
            //return default(T);
        }
    }
    #endregion
}
