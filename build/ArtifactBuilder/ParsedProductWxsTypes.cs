using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace ArtifactBuilder
{
    // This code was auto-generated by visual studio and then edited to remove all of the generated
    // classes that were not needed for our testing purposes.
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    [XmlRoot(Namespace = "http://wixtoolset.org/schemas/v4/wxs", IsNullable = false)]
    public class Wix
    {
    
        public WixFragment Fragment { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragment
    {
        [XmlElement("ComponentGroup", typeof(WixFragmentComponentGroup))]
        public object[] Items { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragmentComponentGroup
    {
        [XmlElement("Component")]
        public WixFragmentComponentGroupComponent[] Component { get; set; }

        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Directory { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragmentComponentGroupComponent
    {
        public WixFragmentComponentGroupComponentFile File { get; set; }

        public WixFragmentComponentGroupComponentRegistryValue RegistryValue { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragmentComponentGroupComponentRegistryValue
    {
        [XmlAttribute]
        public string Root { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string KeyPath { get; set; }

        [XmlAttribute]
        public string Key { get; set; }

        [XmlElement("MultiStringValue")]
        public List<WixFragmentComponentGroupComponentRegistryValueMultiStringValue> MultiStringValue { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragmentComponentGroupComponentRegistryValueMultiStringValue
    {
        [XmlAttribute()]
        public string Value { get; set; }
    }

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://wixtoolset.org/schemas/v4/wxs")]
    public class WixFragmentComponentGroupComponentFile
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string KeyPath { get; set; }

        [XmlAttribute]
        public string Source { get; set; }
    }
}
