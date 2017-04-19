using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DisplayHiddenShares
{
    /// <summary>
    /// Common XmlHandler
    /// </summary>
    public class XmlHandler
    {
        public const string NoNamespaceSchemaLocationAttr = "noNamespaceSchemaLocation";
        public const string XmlSchemaInstance = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// Reads/Creates, edits and saves an xml file in one rush, using ReadWrite access and Read share.
        /// </summary>
        /// <typeparam name="T">Type of object stored in the file.</typeparam>
        /// <param name="file">Fully qualified file to modify.</param>
        /// <param name="modifiy">Function that should be applied on the deserialized object. If the function returns
        /// true, the file content is replaced with the new content of the T object. If false is returned, the 
        /// file will be closed without any changes.</param>
        public static bool DeserializeModifyAndSerializeFile<T>(string file, Func<T, bool> modifiy) where T : class, new()
        {
            T obj;
            return DeserializeModifyAndSerializeFile(file, modifiy, out obj);
        }

        public static bool DeserializeModifyAndSerializeFile<T>(string file, Func<T, bool> modifiy, out T modifyObject) where T : class, new()
        {
            try
            {
                CreateTargetDirectoryIfNotExist(file);

                // this object avoids the generation of namespace in the xml file
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                XmlSerializer serialiser = new XmlSerializer(typeof(T));

                using (var fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read))
                {
                    modifyObject = null;

                    // Read the file if it has some content.
                    if (fileStream.Length != 0)
                    {
                        modifyObject = (T)serialiser.Deserialize(fileStream);
                    }

                    // Create new T instance if it could not be read from file.
                    if (modifyObject == null)
                    {
                        modifyObject = new T();
                    }

                    // Modify the content
                    if (modifiy(modifyObject))
                    {
                        // Reset file and save new content
                        fileStream.SetLength(0);
                        serialiser.Serialize(fileStream, modifyObject, namespaces);

                        return true;
                    }

                    return false;
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML deserialization of " + file, ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException("Error during XML processing of " + file + xe.Message, xe);
            }
            catch (Exception e)
            {
                throw new IOException("Error accessing file " + file, e);
            }
        }

        /// <summary>
        /// Read file from given pathAndfile and deserialise it to type T
        /// </summary>
        /// <typeparam name="T">Type to deserialise</typeparam>
        /// <param name="file">Fully qualified file to read.</param>
        /// <returns>object of type T</returns>
        public static T DeserializeReadWriteEnabledFromFile<T>(string file)
        {
            T deserialisedObject;

            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    deserialisedObject = (T)serialiser.Deserialize(fileStream);
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML deserialization of " + file, ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException("Error during XML processing of " + file + xe.Message, xe);
            }
            catch (Exception e)
            {
                throw new IOException("Error accessing file " + file, e);
            }

            return deserialisedObject;
        }

        /// <summary>
        /// Read file from given pathAndfile and deserialise it to type T
        /// </summary>
        /// <typeparam name="T">Type to deserialise</typeparam>
        /// <param name="file">Fully qualified file to read.</param>
        /// <returns>object of type T</returns>
        public static T DeserializeFromFile<T>(string file)
        {
            T deserialisedObject;

            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (fileStream.Length == 0)
                    {
                        return default(T);
                    }

                    deserialisedObject = (T)serialiser.Deserialize(fileStream);
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML deserialization of " + file, ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException("Error during XML processing of " + file + xe.Message, xe);
            }
            catch (Exception e)
            {
                throw new IOException("Error accessing file " + file, e);
            }

            return deserialisedObject;
        }

        /// <summary>
        /// Read file from given pathAndfile and deserialise it to type T
        /// Schema validation will also be done
        /// </summary>
        /// <typeparam name="T">Type to deserialise</typeparam>
        /// <param name="file">Fully qualified file to read.</param>
        /// <returns>object of type T</returns>
        public static T DeserializeAndValidateFile<T>(string file)
        {
            T deserialisedObject;
            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));

                // Set the validation settings.
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
                settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (fileStream.Length == 0)
                    {
                        return default(T);
                    }

                    using (XmlReader reader = XmlReader.Create(file, settings))
                    {
                        deserialisedObject = (T)serialiser.Deserialize(reader);
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML deserialization of " + file, ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException("Error during XML processing of " + file + xe.Message, xe);
            }
            catch (XmlSchemaException xse)
            {
                throw new XmlException("Error during XML Schema processing of " + file + xse.Message, xse);
            }
            catch (Exception e)
            {
                throw new IOException("Error accessing file " + file, e);
            }

            return deserialisedObject;
        }

        public static void DeserializeAndValidateFile<T>(string file, bool validate, out T deserialized, out string error)
        {
            if (validate)
            {
                DeserializeAndValidateFile(file, out deserialized, out error);
            }
            else
            {
                error = null;
                DeserializeAndValidateFile(file, out deserialized);
            }
        }

        public static void DeserializeAndValidateFile<T>(string file, out T deserialized)
        {
            deserialized = DeserializeAndValidateFile<T>(file);
        }

        public static bool DeserializeAndValidateFile<T>(string file, out T deserialized, out string error)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(T));
            DeserializeEventHandler eventHandler = new DeserializeEventHandler();

            // Set the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessSchemaLocation;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += eventHandler.Validation;

            try
            {
                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    if (fileStream.Length == 0)
                    {
                        error = null;
                        deserialized = default(T);
                        return true;
                    }

                    // use file (not Stream), otherwise path environment for schema definition is not found
                    using (XmlReader reader = XmlReader.Create(file, settings))
                    {
                        deserialized = (T)serialiser.Deserialize(reader);
                    }
                }
            }
            catch (Exception exp)
            {
                error = string.Format("Error reading file {0}: {1}", file, exp);
                deserialized = default(T);
                return false;
            }

            error = eventHandler.GetError();

            return string.IsNullOrEmpty(error);
        }

        /// <summary>
        /// Read file from given pathAndfile and deserialise it to type T
        /// </summary>
        /// <typeparam name="T">Type to deserialise</typeparam>
        /// <param name="file">Fully qualified file to read.</param>
        /// <returns>object of type T</returns>
        public static T DeserializeWriteDisabledFromFile<T>(string file)
        {
            T deserialisedObject;

            try
            {
                XmlSerializer serialiser = new XmlSerializer(typeof(T));

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
                {
                    if (fileStream.Length == 0)
                    {
                        return default(T);
                    }

                    deserialisedObject = (T)serialiser.Deserialize(fileStream);
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML deserialization of " + file, ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException("Error during XML processing of " + file + xe.Message, xe);
            }
            catch (Exception e)
            {
                throw new IOException("Error accessing file " + file, e);
            }

            return deserialisedObject;
        }


        /// <summary>
        /// Deserialise xml to an object type of T
        /// </summary>
        /// <typeparam name="T">the type of the wanted object</typeparam>
        /// <param name="xml">xml to deserialize</param>
        /// <returns>the object</returns>
        public static T Deserialize<T>(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            return Deserialize<T>(doc);
        }

        /// <summary>
        /// Deserialize doc to an object type of T
        /// </summary>
        /// <typeparam name="T">type of te object</typeparam>
        /// <param name="doc">xml document</param>
        /// <returns>instance of the type T</returns>
        /// <exception cref="System.InvalidOperationException">Thrown by XML deserializer. Refer to inner exception.</exception>
        public static T Deserialize<T>(XmlDocument doc)
        {
            XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
            return Deserialize<T>(reader);
        }

        public static T Deserialize<T>(XmlReader reader)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            object obj = ser.Deserialize(reader);

            // Then you just need to cast obj into whatever type it is 
            T myObj = (T)obj;

            return myObj;
        }

        /// <summary>
        /// Serialize object of class T
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="obj">the object to serialise</param>
        /// <returns>xml document</returns>
        public static XmlDocument Serialize<T>(T obj) where T : class
        {
            // this object avoids the generation of namespace in the xml file
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            XmlSerializer ser = new XmlSerializer(obj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            ser.Serialize(writer, obj, namespaces);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sb.ToString());

            writer.Flush();
            writer.Close();

            return doc;
        }

        /// <summary>
        /// Serialize object of class T to xml string
        /// </summary>
        /// <typeparam name="T">the type</typeparam>
        /// <param name="obj">the object to serialise</param>
        /// <returns>xml text</returns>
        public static string SerializeToString<T>(T obj) where T : class
        {
            // this object avoids the generation of namespace in the xml file
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);


            XmlSerializer ser = new XmlSerializer(obj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);

            ser.Serialize(writer, obj, namespaces);

            string xmlString = sb.ToString();

            writer.Flush();
            writer.Close();

            return xmlString;
        }

        /// <summary>
        /// Serialise and save file to file
        /// </summary>
        /// <param name="objectToSave">object to save</param>
        /// <param name="file">Fully qualified file to write.</param>
        public static void SerializeToFile(object objectToSave, string file)
        {
            SerializeToFile(objectToSave, file, null);
        }

        /// <summary>
        /// Serialise and save file to file
        /// </summary>
        /// <param name="objectToSave">object to save</param>
        /// <param name="file">Fully qualified file to write.</param>
        /// <param name="namespaces">namespaces </param>
        public static void SerializeToFile(object objectToSave, string file, XmlSerializerNamespaces namespaces)
        {
            //if (namespaces == null)
            //{
            // this object avoids the generation of namespace in the xml file
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            //}

            try
            {
                using (var fileStream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    using (var xmlWriter = new XmlTextWriter(fileStream, new UTF8Encoding()))
                    {
                        xmlWriter.Formatting = Formatting.Indented;
                        xmlWriter.Indentation = 2;
                        new XmlSerializer(objectToSave.GetType()).Serialize(xmlWriter, objectToSave, namespaces);
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Error during XML serialization", ioe);
            }
            catch (XmlException xe)
            {
                throw new XmlException(string.Format("Error during processing of object to xml to pathAndfile [{0}]: {1}", file, xe.Message), xe);
            }
            catch (Exception e)
            {
                throw new IOException(string.Format("Error accessing file [{0}]", file), e);
            }
        }

        private static void CreateTargetDirectoryIfNotExist(string pathAndFile)
        {
            FileInfo fileInfo = new FileInfo(pathAndFile);
            if (fileInfo.Directory != null && !fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }
        }

        private class DeserializeEventHandler
        {
            private List<Exception> _events;
            private XmlSeverityType _maxSeverity = XmlSeverityType.Warning;

            public DeserializeEventHandler()
            {
                MaxExceptions = 5;
            }

            public int MaxExceptions { get; set; }

            public void Validation(object sender, ValidationEventArgs e)
            {
                if (_events == null)
                {
                    _events = new List<Exception>();
                }
                if (_events.Count < MaxExceptions)
                {
                    _events.Add(e.Exception);
                }
                else if (_events.Count == MaxExceptions)
                {
                    _events.Add(new Exception("..."));
                }
                if (e.Severity == XmlSeverityType.Error)
                {
                    _maxSeverity = XmlSeverityType.Error;
                }
            }

            public string GetError()
            {
                if (_events == null)
                {
                    return null;
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0}: ", _maxSeverity);
                foreach (Exception e in _events)
                {
                    sb.AppendLine(e.Message);
                }
                return sb.ToString();
            }
        }
    }
}
