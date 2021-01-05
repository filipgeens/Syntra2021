using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Syntra.Shared.Extensions {

	public static class ReflectionExtensions {
		public static Assembly GetAssembly(this object src) => src?.GetType().Assembly;
		public static string FileVersion(this Assembly assm) {
			try {
				return FileVersionInfo.GetVersionInfo(assm.Location).FileVersion;
			} catch (Exception ex) { return ex.Message; }
		}
		public static string Version(this Assembly assm, bool UseOnlyMajor = false) {
			return UseOnlyMajor ? assm.MajorVersion() : assm?.GetName().Version.ToString();
		}
		public static string MajorVersion(this Assembly assm) {
			return assm?.GetName().Version.Major.ToString();
		}
		public static bool ImplementsInterface(this Type myType, Type interfaceType) {
			return interfaceType?.IsInterface == true ? myType.GetInterfaces().Where(t => t == interfaceType).Count() > 0 : false;
		}
		public static string GetDirectory(this Assembly assm) => assm?.Location.NotEmpty() == true ? Path.GetDirectoryName(assm.Location) : "";
		public static bool IsSimpleType(this object obj) => obj?.GetType().IsSimpleType() ?? false;
		public static bool IsSimpleType(this Type tp) => (tp.IsPrimitive || tp == typeof(decimal) || tp == typeof(DateTime) || tp == typeof(TimeSpan));
		public static bool HasDefaultConstructor(this Type tp) => tp?.IsClass == true && tp.IsAbstract == false && tp.GetConstructors().Where(c => c.GetParameters().Length == 0 || c.GetParameters().All(p => p.IsOptional)).Count() > 0;
		public static bool HasDefaultConstructor(this PropertyInfo pi) => pi?.PropertyType.HasDefaultConstructor() == true;
		public static bool HasDefaultConstructor(this FieldInfo fi) => fi?.FieldType.HasDefaultConstructor() == true;
		public static string AssemblyVersion(this Type tp) { return tp?.Assembly.Version(); }

		public static Type DataType(this PropertyInfo pi) => pi?.PropertyType;
		public static Type GetMemberType(this MemberInfo info, bool allowMethods = false) {
			if (info is PropertyInfo pi) {
				return pi.PropertyType;
			} else if (info is FieldInfo fi) {
				return fi.FieldType;
			} else if (info is MethodInfo mi) {
				return mi.ReturnType == typeof(void) || !allowMethods ? null : mi.ReturnType;
			}
			return null;
		}
		public static object GetMemberValue(this MemberInfo info, object refObj, object stdValue = null) {
			if (info is PropertyInfo pi) {
				return pi.GetValue(refObj);
			} else if (info is FieldInfo fi) {
				return fi.GetValue(refObj);
			}
			return stdValue;
		}
		public static bool SetObjectValue(this MemberInfo member, object dest, object value) {
			if (member != null && dest != null && value != null) {
				if (member is PropertyInfo pi) {
					pi.SetValue(dest, value);
				} else if (member is FieldInfo fi) {
					fi.SetValue(dest, value);
				} else return false;
				return true;
			}
			return false;
		}
		public static bool HasCustomAttribute<T>(this MemberInfo tp) where T : Attribute => tp.GetCustomAttribute<T>() != null;
		public static bool IsArray(this MemberInfo mi) => mi.GetMemberType()?.IsArray == true;
		public static object CreateInstance(this Type tp) => Activator.CreateInstance(tp);
		public static Array CreateInstance(this Type tp, int len) => tp.IsArray ? Array.CreateInstance(tp.GetElementType(), len) : Array.CreateInstance(tp, len);
		public static T CreateInstance<T>(this Type tp) where T : class => Activator.CreateInstance(tp) as T;
		public static Type DataType(this FieldInfo fi) => fi?.FieldType;

		/// <summary>
		/// Create a generic type from Type
		/// Example
		/// Type t=typeof(List<>);
		/// Type genericType=typeof(string);
		/// => object obj=t.CreateGenericTypeObject(genericType);
		/// </summary>
		/// <param name="baseType"></param>
		/// <param name="genericTypes"></param>
		/// <returns></returns>
		public static object CreateGenericTypeObject(this Type baseType, params Type[] genericTypes) => (baseType != null && genericTypes?.Length > 0) ? Activator.CreateInstance(baseType.MakeGenericType(genericTypes)) : null;
		/// <summary>
		/// Same as the CreateGenericTypeObject but with an automatic cast to T
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="baseType"></param>
		/// <param name="genericTypes"></param>
		/// <returns></returns>
		public static T CreateGenericType<T>(this Type baseType, params Type[] genericTypes) where T : class => (baseType != null && genericTypes?.Length > 0) ? Activator.CreateInstance(baseType.MakeGenericType(genericTypes)) as T : default(T);
	}
}
