using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Syntra.Shared.Extensions {

	public static class CommonExtensions {
		public static string FindResourceName(this Type objType, string name) {
			if (name?.Length > 0 && objType != null) {
				return objType.Assembly.GetManifestResourceNames()?.Where(t => t.ToLower().Contains(name.ToLower())).FirstOrDefault();
			}
			return null;
		}
		public static string GetEmbeddedResource(this Type objType, string name, Encoding encode = null) {
			try {
				string resName = objType?.FindResourceName(name);
				if (resName?.Length > 0) {
					using Stream vStream = objType.Assembly.GetManifestResourceStream(resName);
					using StreamReader vReader = encode != null ? new StreamReader(vStream, encode) : new StreamReader(vStream);
					return vReader.ReadToEnd();
				}
			} catch (Exception ex) { throw (ex); }
			return null;
		}
		public static bool NotNull(this object obj) { return obj != null; }
		public static bool IsEmpty(this string str) { return str.NotEmpty() == false; }
		public static bool IsEmpty(this ICollection src) { return src.NotEmpty() == false; }
		public static bool IsEmpty(this MemoryStream src) { return src.NotEmpty() == false; }
		public static bool IsEmpty(this DateTime src) { return (src == DateTime.MinValue || src == DateTime.MaxValue); }
		public static bool IsEmpty(this DateTimeOffset src) { return (src <= DateTimeOffset.MinValue || src >= DateTimeOffset.MaxValue); }
		public static bool IsEmpty(this TimeSpan src) { return (src == TimeSpan.Zero || src == TimeSpan.MinValue || src == TimeSpan.MaxValue); }
		public static bool NotEmpty(this MemoryStream src) { return src?.Length > 0; }
		public static bool NotEmpty(this ICollection src) { return src?.Count > 0; }
		public static bool NotEmpty(this IEnumerable array) { return array?.GetEnumerator()?.MoveNext() == true && array?.GetEnumerator()?.Current != null; }
		public static bool NotEmpty(this string str) { return str?.Length > 0; }
		public static bool NotEmpty(this DateTime src) { return src.IsEmpty() == false; }
		public static bool NotEmpty(this DateTimeOffset src) { return src.IsEmpty() == false; }
		public static bool NotEmpty(this TimeSpan src) { return src.IsEmpty() == false; }
		public static byte[] Split(this byte[] src, int pos, int len = -1) {
			len = len > 0 ? len : src.Length - pos;
			if (pos < src?.Length && src?.Length >= pos + len) {
				byte[] dest = new byte[len];
				Array.Copy(src, pos, dest, 0, len);
				return dest;
			}
			return null;
		}
		public static byte[] ReadToEnd(this Stream s, int maxSize = -1, bool optimList = false) => ReadInBuffer(s, maxSize, optimList).ToArray();
		public static List<byte> ReadInBuffer(this Stream s, int maxSize = -1, bool optimList = false) {
			if (s?.CanRead == true) {
				List<byte> buffer = optimList ? new List<byte>((int)s.Length) : new List<byte>();
				int b = 0;
				int count = 0;
				do {
					b = s.ReadByte();
					if (b >= 0) {
						buffer.Add(Convert.ToByte(b));
						count++;
						if (maxSize > 0 && count >= maxSize) { break; }
					}
				} while (b >= 0);
				return buffer;
			}
			return null;
		}
		public static byte[] LoadResource(this Type tp, string name) {
			Stream s = tp.FindResource(name);
			if (s?.CanRead == true) {
				return s.ReadToEnd();
			}
			return null;
		}
		public static Stream FindResource(this Type tp, string name) {
			if (name.NotEmpty()) {
				string item = tp?.Assembly.GetManifestResourceNames().Where(t => t.ToLower().Contains(name.ToLower())).FirstOrDefault();
				if (item.NotEmpty()) { return tp.Assembly.GetManifestResourceStream(item); }
			}
			return null;
		}
		public static byte[] ToBytes(this string data, Encoding enc = null) { if (data.NotEmpty()) return (enc ?? Encoding.Unicode).GetBytes(data); return null; }
		public static string GetString(this byte[] buffer, Encoding usedEncoding = null) { usedEncoding ??= Encoding.Unicode; return buffer?.Length > 0 ? usedEncoding.GetString(buffer) : ""; }
		public static string GetString(this MemoryStream buffer, Encoding usedEncoding = null) { return buffer?.ToArray()?.GetString(usedEncoding); }
		public static string ToB64(this byte[] buffer) { if (buffer?.Length > 0) { return Convert.ToBase64String(buffer); } return string.Empty; }
		public static string ToB64(this string txt, Encoding enc = null) { if (txt?.Length > 0) { return Convert.ToBase64String((enc ?? Encoding.UTF8).GetBytes(txt)); } return string.Empty; }
		public static string ToHex(this byte[] buffer) => buffer?.Length > 0 ? string.Concat(buffer.Select(x => x.ToString("X2"))) : string.Empty;
		public static byte[] FromB64(this string data) { if (data?.Length > 0) { return Convert.FromBase64String(data); } return new byte[] { }; }
		public static string StrFromB64(this string data, Encoding enc = null) { if (data?.Length > 0) { return (enc ?? Encoding.UTF8).GetString(Convert.FromBase64String(data)); } return string.Empty; }
		public static bool ContainsFlag(this int value, int flag) { return ((value & flag) == flag); }
		public static bool Compare<T>(this T[] a, T[] b) where T : struct {
			if (a?.Length == b?.Length) { for (int i = 0; i < a.Length; i++) { if (!a[i].Equals(b[i])) return false; } return true; }
			return false;
		}
		public static string FileNameTimestamp(this DateTime dt, bool includeTime = false, bool includeDate = true, string sep = "") {
			sep ??= "";
			string res = null;
			if (includeDate) { res = $"{dt.Year.ToString("D4")}{sep}{dt.Month.ToString("D2")}{sep}{dt.Day.ToString("D2")}"; }
			if (includeTime) { res = $"{res ?? ""}{(res.NotEmpty() ? sep : "")}{dt.Hour.ToString("D2")}{sep}{dt.Minute.ToString("D2")}{sep}{dt.Second.ToString("D2")}"; }
			return res ?? dt.Ticks.ToString();
		}
		public static bool IsDefault<T>(this T value) where T : struct {
			bool isDefault = value.Equals(default(T));
			return isDefault;
		}
	}
}
