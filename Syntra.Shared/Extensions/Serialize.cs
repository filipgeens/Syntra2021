using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Syntra.Shared.Extensions {
	public static class SerializingExtensions {
		public static string ToJson<T>(this T src, JsonSerializerOptions options = null) where T : new() {
			options ??= new JsonSerializerOptions() { WriteIndented = true };
			return JsonSerializer.Serialize<T>(src, options);
		}
		public static T FromJson<T>(this string json, JsonSerializerOptions options = null) where T : new() {
			return JsonSerializer.Deserialize<T>(json, options);
		}
		public static bool FromJson<T>(this T dest, string json, JsonSerializerOptions options = null) where T : class, new() {
			T res = JsonSerializer.Deserialize<T>(json, options);
			return dest.CopyFrom<T, T>(res);
		}
		public static string ToXml(this object src) {
			if (src != null) {
				XmlSerializer serializer = new XmlSerializer(src.GetType());
				StringBuilder sb = new StringBuilder();
				StringWriter writer = new StringWriter(sb);
				serializer.Serialize(writer, src);
				return sb.ToString();
			}
			return null;
		}
		public static T FromXml<T>(this string src) where T : new() {
			if (src != null) {
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				StringReader reader = new StringReader(src);
				return (T)serializer.Deserialize(reader);
			}
			return default;
		}
	}
}
