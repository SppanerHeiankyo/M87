using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyConfigClass
{
    public enum action
    {
        attack=0, special=1, jump=2, select=3, back=4, pause=5
    }

    private Dictionary<action, KeyCode> defaultKey = new Dictionary<action, KeyCode>()
    {
        {action.attack,KeyCode.Z },
        {action.special,KeyCode.X },
        {action.jump,KeyCode.Space },
        {action.select,KeyCode.Return },
        {action.back,KeyCode.Backspace },
        {action.pause,KeyCode.Escape }
    };
    private Dictionary<action, string> KeyName = new Dictionary<action, string>()
    {
        {action.attack,"attack"},
        {action.special,"special"},
        {action.jump,"jump"},
        {action.select,"select"},
        {action.back,"back"},
        {action.pause,"pause"}
    };

    public Vector3 GetAxis()
    {
        Vector3 v=new Vector3(0f,0f,0f);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxisRaw("Horizontal") > 0)
        {
            v.x++;
        }
        if(Input.GetKey(KeyCode.LeftArrow)|| Input.GetAxisRaw("Horizontal") < 0)
        {
            v.x--;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxisRaw("Vertical") > 0)
        {
            v.y++;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0)
        {
            v.y--;
        }
        return v;
    }

    public void SetDefaultKey()
    {
        foreach (KeyValuePair<action,KeyCode> i in defaultKey)
        {
            SetKey(i.Key, i.Value);
        }
    }

    public action IntToAction(int i)
    {
        return (action)Enum.ToObject(typeof(action), i);
    }

    public void SetKey(action key, KeyCode keyCode)
    {
        var json = JsonUtility.ToJson(keyCode);
        PlayerPrefs.SetString(KeyName[key], json);
    }

    public KeyCode GetKeyCode(action key)
    {
        var json = PlayerPrefs.GetString(KeyName[key]);
        var obj = JsonUtility.FromJson<KeyCode>(json);
        return obj;
    }

    public KeyCode GetInput()
    {
        foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(code))
            {
                return code;
            }
        }
        throw new FormatException("Can't find Corresponding key code");
    }

    public bool GetKeyDown(action a)
    {
        return Input.GetKeyDown(GetKeyCode(a));
    }

    public bool GetKey(action a)
    {
        return Input.GetKey(GetKeyCode(a));
    }

    public bool GetKeyUp(action a)
    {
        return Input.GetKeyUp(GetKeyCode(a));
    }
}
