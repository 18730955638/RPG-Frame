﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaUIBehaviourWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(LuaUIBehaviour), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("RegistSelft", RegistSelft);
		L.RegFunction("AddButtonLisenter", AddButtonLisenter);
		L.RegFunction("AddButtonDownLisenter", AddButtonDownLisenter);
		L.RegFunction("AddButtonUpLisenter", AddButtonUpLisenter);
		L.RegFunction("AddSliderLisenter", AddSliderLisenter);
		L.RegFunction("AddInputFiledLisenter", AddInputFiledLisenter);
		L.RegFunction("AddToggleLisenter", AddToggleLisenter);
		L.RegFunction("AddDropDownLisenter", AddDropDownLisenter);
		L.RegFunction("GetTransform", GetTransform);
		L.RegFunction("SetImageSprite", SetImageSprite);
		L.RegFunction("GetButton", GetButton);
		L.RegFunction("GetSlider", GetSlider);
		L.RegFunction("SetButtonSprites", SetButtonSprites);
		L.RegFunction("GetText", GetText);
		L.RegFunction("GetImage", GetImage);
		L.RegFunction("SetInteractable", SetInteractable);
		L.RegFunction("GetTextColor", GetTextColor);
		L.RegFunction("SetTextColor", SetTextColor);
		L.RegFunction("GetTextWidth", GetTextWidth);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("panelName", get_panelName, set_panelName);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegistSelft(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			obj.RegistSelft();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddButtonLisenter(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
				LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
				obj.AddButtonLisenter(arg0);
				return 0;
			}
			else if (count == 3)
			{
				LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
				LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.AddButtonLisenter(arg0, arg1);
				return 0;
			}
			else if (count == 4)
			{
				LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
				LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				object arg2 = ToLua.ToVarObject(L, 4);
				obj.AddButtonLisenter(arg0, arg1, arg2);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: LuaUIBehaviour.AddButtonLisenter");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddButtonDownLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.AddButtonDownLisenter(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddButtonUpLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.AddButtonUpLisenter(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddSliderLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.AddSliderLisenter(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddInputFiledLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			LuaFunction arg1 = ToLua.CheckLuaFunction(L, 3);
			obj.AddInputFiledLisenter(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddToggleLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.AddToggleLisenter(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddDropDownLisenter(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.AddDropDownLisenter(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTransform(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.RectTransform o = obj.GetTransform();
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetImageSprite(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.Sprite arg0 = (UnityEngine.Sprite)ToLua.CheckObject(L, 2, typeof(UnityEngine.Sprite));
			UnityEngine.UI.Image o = obj.SetImageSprite(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetButton(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Button o = obj.GetButton();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSlider(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Slider o = obj.GetSlider();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonSprites(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.Sprite[] arg0 = ToLua.CheckParamsObject<UnityEngine.Sprite>(L, 2, count - 1);
			UnityEngine.UI.Button o = obj.SetButtonSprites(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetText(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Text o = obj.GetText();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetImage(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Image o = obj.GetImage();
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInteractable(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.SetInteractable(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextColor(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			UnityEngine.Color o = obj.GetTextColor(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTextColor(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			UnityEngine.UI.Text arg0 = (UnityEngine.UI.Text)ToLua.CheckObject<UnityEngine.UI.Text>(L, 2);
			UnityEngine.Color arg1 = ToLua.ToColor(L, 3);
			obj.SetTextColor(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTextWidth(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			LuaUIBehaviour obj = (LuaUIBehaviour)ToLua.CheckObject<LuaUIBehaviour>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			int o = obj.GetTextWidth(arg0);
			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)o;
			string ret = obj.panelName;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index panelName on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panelName(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			LuaUIBehaviour obj = (LuaUIBehaviour)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.panelName = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index panelName on a nil value");
		}
	}
}

