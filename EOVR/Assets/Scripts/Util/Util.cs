using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;

public class Util 
{
	#region - gold text
	static System.Text.StringBuilder s_sb = new System.Text.StringBuilder();
	static string[] s_strs = new string[] {
		"", "a", "b", "c", "d", "e", "f", "g", "h", "i",
		"j", "k", "l", "m", "n", "o", "p", "q", "r", "s",
		"t", "u", "v", "w", "x", "y", "z", "A", "B", "C",
		"D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
		"N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
		"X", "Y", "Z" };

	public static string GetGoldText_T2(long _iGold)
	{
		s_sb.Length = 0;
		double tmpDb = (double)_iGold;
		int count = 0;
		while (tmpDb >= 1000)
		{
			tmpDb *= 0.001;
			count++;
		}
		if (count >= s_strs.Length)
			count = s_strs.Length - 1;


		if (count == 0)
		{
			s_sb.AppendFormat("{0}", _iGold);
		}
		else
		{
			int lastInt = (int)tmpDb;
			double lastPreDouble = (tmpDb - lastInt) * 1000;
			int lastPreInt = Mathf.RoundToInt((float)lastPreDouble);
			if (lastPreInt < 100)
			{
				s_sb.AppendFormat("{0}{1}", lastInt, s_strs[count]);
			}
			else
			{
				int lastPreInt100 = (int)(lastPreInt * 0.01);
				s_sb.AppendFormat("{0}.{1}{2}", lastInt, lastPreInt100, s_strs[count]);
			}
		}

		return s_sb.ToString();
	}

	public static string GetGoldText_T1(int _iGold)
	{
		return GetGoldText_T1((long)_iGold);
    }

	public static string GetGoldText_T1(long _iGold)
	{
		return _iGold.ToString("#,#0", CultureInfo.InvariantCulture);
	}

	#endregion

	#region - random
	static public int GetRandomIndex(List<int> _list)
    {
		if (null == _list)
			return 0;

        int _ratetotal = 0;
        for (int i = 0; i < _list.Count; ++i)
        {
            _ratetotal += _list[i];
        }

        int _rate = 0;
        int _rand = Random.Range(0, _ratetotal);
        for (int i = 0; i < _list.Count; ++i)
        {
            _rate += _list[i];
            if (_rand < _rate)
            {
                return i;
            }
        }

        return 0;
    }
	#endregion

	#region -spline
	static public Vector3 GetBezier3(Vector3 p1,Vector3 p2,Vector3 p3,float mu)
	{
	    float mum1,mum12,mu2;
	    Vector3 p;
	    mu2 = mu * mu;
	    mum1 = 1f - mu;
	    mum12 = mum1 * mum1;
	    p.x = p1.x * mum12 + 2 * p2.x * mum1 * mu + p3.x * mu2;
	    p.y = p1.y * mum12 + 2 * p2.y * mum1 * mu + p3.y * mu2;
	    p.z = p1.z * mum12 + 2 * p2.z * mum1 * mu + p3.z * mu2;
	    return p;
	}

	static public Vector3 GetBezier4(Vector3 p1,Vector3 p2,Vector3 p3,Vector3 p4, float mu)
	{
	    float mum1,mum13,mu3;
	    Vector3 p;
	    mum1 = 1 - mu;
	    mum13 = mum1 * mum1 * mum1;
	    mu3 = mu * mu * mu;
	    p.x = mum13*p1.x + 3*mu*mum1*mum1*p2.x + 3*mu*mu*mum1*p3.x +mu3*p4.x;
	    p.y = mum13*p1.y + 3*mu*mum1*mum1*p2.y + 3*mu*mu*mum1*p3.y +mu3*p4.y;
	    p.z = mum13*p1.z + 3*mu*mum1*mum1*p2.z + 3*mu*mu*mum1*p3.z +mu3*p4.z;
	    return(p);
	}

	// 0f <= t <= 1f ( t = 0f -> p1, t = 1f ->p2 )
	static public Vector3 GetCatmullRomSpline(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t ) 
	{
	    Vector3 ret = Vector3.zero;
	
	    float t2 = t * t;
	    float t3 = t2 * t;
	
	    ret.x = 0.5f * ((2.0f * p1.x) +
	    (-p0.x + p2.x) * t +
	    (2.0f * p0.x - 5.0f * p1.x + 4 * p2.x - p3.x) * t2 +
	    (-p0.x + 3.0f * p1.x - 3.0f * p2.x + p3.x) * t3);
	
	    ret.y = 0.5f * ((2.0f * p1.y) +
	    (-p0.y + p2.y) * t +
	    (2.0f * p0.y - 5.0f * p1.y + 4 * p2.y - p3.y) * t2 +
	    (-p0.y + 3.0f * p1.y - 3.0f * p2.y + p3.y) * t3);
		
		ret.z = 0.5f * ((2.0f * p1.z) +
	    (-p0.z + p2.z) * t +
	    (2.0f * p0.z - 5.0f * p1.z + 4 * p2.z - p3.z) * t2 +
	    (-p0.z + 3.0f * p1.z - 3.0f * p2.z + p3.z) * t3);
	
	    return ret;
	}
	#endregion

	#region -angle
	static public float UpAngle(Vector3 fwd, Vector3 targetDir)
    {
        float angle = Vector3.Angle(fwd, targetDir);
		if (AngleDir(fwd, targetDir, Vector3.forward) == -1)
		{
			angle = 360.0f - angle;
			if (angle > 359.9999f)
				angle -= 360.0f;
			return angle;
		}

		return angle;
	}


    static public float ContAngle(Vector3 fwd, Vector3 targetDir)
    {
        float angle = Vector3.Angle(fwd, targetDir);

        if (AngleDir(fwd, targetDir, Vector3.forward) == -1)
        {
            angle = 360.0f - angle;
            if (angle > 359.9999f)
                angle -= 360.0f;

            return angle;
        }

		return angle;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;

        return Mathf.Clamp(angle, min, max);
    }

    static public int AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0.0)
            return 1;
        else if (dir < 0.0)
            return -1;

		return 0;
    }

	public static bool IsSightDetect(Vector3 posCur, Quaternion rot, Vector3 posTarget, float fAngle)
	{
		Vector3 tempTargetDir = posTarget - posCur;
		Vector3 tempCurLook = rot * Vector3.forward;

		float t = Vector3.Angle(tempCurLook.normalized, tempTargetDir.normalized);
		if (t < fAngle)
		{
			return true;
		}

		return false;
	}
	#endregion

	#region -color
	public static string colorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    public static Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        return new Color32(r, g, b, a);
    }

	#endregion

	#region - time
	static public int GetDay(int _time)
	{
		return _time / 3600 / 24;
	}

	static public int GetHour(int _time)
	{
		return _time / 3600;
	}

	static public int GetMinute(int _time)
	{
		return (_time % 3600) / 60;
	}

	static public int GetSecond(int _time)
	{
		return (_time % 3600) % 60;
	}

    static public long GetNowSystemTimeSecond()
    {
        return System.DateTime.Now.Ticks / 10000000;
    }

    static public long GetSystemTimeSecond( long _time)
    {
        return _time / 10000000;
    }

    #endregion

    #region -vector
    static public float GetVecDic_DY( Vector3 _pos1, Vector3 _pos2 )
	{
		_pos1.y = 0f;
		_pos2.y = 0f;

		return Vector3.Distance(_pos1, _pos2);
	}

	static public Vector3 GetVecDir_DY(Vector3 _pos1, Vector3 _pos2)
	{
		_pos1.y = 0f;
		_pos2.y = 0f;

		return _pos1 - _pos2;
	}

	public static bool IsInAngle(Vector3 posCur, Quaternion rot, Vector3 posTarget, float fAngle)
	{
		Vector3 tempTargetDir = posTarget - posCur;
		Vector3 tempCurLook = rot * Vector3.forward;

		float t = Vector3.Angle(tempCurLook.normalized, tempTargetDir.normalized);
		if (t < fAngle)
		{
			return true;
		}

		return false;
	}
	#endregion
}

public class TargetVector3
{
	Vector3 m_target = Vector3.zero;
	Vector3 m_pos = Vector3.zero;
	float m_speed = 1f;

	public void SetTarget(Vector3 _pos)
	{
		m_target = _pos;
    }
	
	public void SetValue( Vector3 _pos )
	{
		m_pos = _pos;
    }

	public void SetSpeed(float _speed)
	{
		m_speed = _speed;
    }

	public Vector3 getValue
	{
		get
		{
			return m_pos;
        }
	}

	public void Update()
	{
		Vector3 vec3Movement = m_target - m_pos;
		float _fMoveSpeed = m_speed * Time.deltaTime;

		if (_fMoveSpeed < vec3Movement.magnitude)
		{
			Vector3 _delta = vec3Movement.normalized * _fMoveSpeed;
			m_pos = m_pos + _delta;
		}
		else
		{
			m_pos = m_target;
        }
	}

	public bool isMoveing
	{
		get
		{
			return m_target != m_pos;
        }
	}
}

public class TargetValue
{
	private float m_target = 0f;
	private float m_value = 0f;
	private float m_speed = 1f;	

	public void SetSpeed(float _speed)
	{
		m_speed = _speed;
	}

	public void SetTarget(float _target)
	{
		m_target = _target;		
	}

	public float getValue
	{
		get
		{
			return m_value;
		}
	}

	public float getTarget
	{
		get
		{
			return m_target;
		}
	}

	public bool isMoveing
	{
		get
		{
			return getTarget != getValue;
		}
	}
	public void SetValue(float _value)
	{
		m_value = _value;
	}

	public void Update(float _teimdelta)
	{
		if (isMoveing == false)
			return;

		bool _isAdd = m_target > m_value;

		if (_isAdd)
		{
			m_value += m_speed * _teimdelta;
			if (m_target < m_value)
			{
				m_value = m_target;
			}
		}
		else
		{
			m_value -= m_speed * _teimdelta;
			if (m_target > m_value)
			{
				m_value = m_target;
			}
		}
	}

	public void Update()
	{
		Update(Time.deltaTime);
	}
}