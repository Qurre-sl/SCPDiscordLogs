using System;
using System.Reflection;
using MoonSharp.Interpreter;
using Qurre.API;

namespace SCPLogs.Lua;

internal static class Internal
{

    internal static void PreRegisterLuaType(Type type)
    {
        if (type.Namespace is null)
            return;
            
        if (!(type.Namespace == "Qurre.API" ||
              type.Namespace.StartsWith("Qurre.API.Objects") ||
              type.Namespace.StartsWith("Qurre.API.Controllers") ||
              type.Namespace.StartsWith("Qurre.API.Classification") ||
              type.Namespace.StartsWith("Qurre.API.Addons")))
            return;
        
        RegisterLuaType(type);

        if (type is not { IsAbstract: true, IsSealed: true, IsPublic: true })
            return;
        
        string name = "API_" + type.Name;
        Globals.SetGlobalVariable(name, UserData.CreateStatic(type));
        Log.Debug($"Registered in Lua global space: {name}, Type: {type.FullName}");
    }

    internal static void RegisterLuaType(Type type)
    {
        try
        {
            PropertyInfo? propertyBase = type.GetProperty("Base", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (propertyBase is not null)
                Globals.RegisterType(propertyBase.PropertyType);
            
            Globals.RegisterType(type);
        }
        catch(Exception ex)
        {
            Log.Warn(type + "\n" + ex.Message);
        }
    }

    internal static void PrepareTable(Table table)
    {
        foreach (var variable in Globals.GetGlobalVariables())
        {
            table[variable.Key] = variable.Value;
        }
    }
}