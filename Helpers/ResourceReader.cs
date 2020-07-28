using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MyResume.Helpers
{
	public static class ResourceHelper
	{
		public static T GetResourceFile<T>(string path)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(T));

			var assembly = Assembly.GetExecutingAssembly();
			T result;
			using (Stream resourceStream = assembly.GetManifestResourceStream(path))
			{
				if (resourceStream == null) return default(T);
				XmlDocument mappingFile = new XmlDocument();
				result = (T)serializer.Deserialize(resourceStream);
			}
			return result;
		}
		public static void SerializeParams<T>( List<T> paramList)
		{
			XmlSerializer serializer = new XmlSerializer(paramList.GetType());
			XDocument doc = new XDocument();
			System.Xml.XmlWriter writer = doc.CreateWriter();
			
			serializer.Serialize(writer, paramList);

			writer.Close();
		}

		public static List<T> DeserializeParams<T>(XDocument doc)
		{
			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));

			System.Xml.XmlReader reader = doc.CreateReader();

			List<T> result = (List<T>)serializer.Deserialize(reader);
			reader.Close();

			return result;
		}
	}
}
