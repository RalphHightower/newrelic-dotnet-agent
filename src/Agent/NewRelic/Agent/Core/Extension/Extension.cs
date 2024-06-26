// ------------------------------------------------------------------------------
//  <auto-generated>
//    Generated by Xsd2Code. Version 3.6.0.0
//    <NameSpace>NewRelic.Agent.Core.Extension</NameSpace><Collection>List</Collection><codeType>CSharp</codeType><EnableDataBinding>False</EnableDataBinding><EnableLazyLoading>False</EnableLazyLoading><TrackingChangesEnable>False</TrackingChangesEnable><GenTrackingClasses>False</GenTrackingClasses><HidePrivateFieldInIDE>False</HidePrivateFieldInIDE><EnableSummaryComment>True</EnableSummaryComment><VirtualProp>False</VirtualProp><PascalCase>False</PascalCase><BaseClassName>EntityBase</BaseClassName><IncludeSerializeMethod>False</IncludeSerializeMethod><UseBaseClass>False</UseBaseClass><GenBaseClass>False</GenBaseClass><GenerateCloneMethod>True</GenerateCloneMethod><GenerateDataContracts>False</GenerateDataContracts><CodeBaseTag>Net20</CodeBaseTag><SerializeMethodName>Serialize</SerializeMethodName><DeserializeMethodName>Deserialize</DeserializeMethodName><SaveToFileMethodName>SaveToFile</SaveToFileMethodName><LoadFromFileMethodName>LoadFromFile</LoadFromFileMethodName><GenerateXMLAttributes>True</GenerateXMLAttributes><OrderXMLAttrib>False</OrderXMLAttrib><EnableEncoding>False</EnableEncoding><AutomaticProperties>False</AutomaticProperties><GenerateShouldSerialize>False</GenerateShouldSerialize><DisableDebug>False</DisableDebug><PropNameSpecified>Default</PropNameSpecified><Encoder>UTF8</Encoder><CustomUsings></CustomUsings><ExcludeIncludedTypes>False</ExcludeIncludedTypes><InitializeFields>All</InitializeFields><GenerateAllTypes>True</GenerateAllTypes>
//  </auto-generated>
// ------------------------------------------------------------------------------
namespace NewRelic.Agent.Core.Extension
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.6.0.20097")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:newrelic-extension")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="urn:newrelic-extension", IsNullable=false)]
    public partial class extension
    {
        
        private List<extensionTracerFactory> instrumentationField;
        
        private bool enabledField;
        
        /// <summary>
        /// extension class constructor
        /// </summary>
        public extension()
        {
            this.instrumentationField = new List<extensionTracerFactory>();
            this.enabledField = true;
        }
        
        [System.Xml.Serialization.XmlArrayItemAttribute("tracerFactory", IsNullable=false)]
        public List<extensionTracerFactory> instrumentation
        {
            get
            {
                return this.instrumentationField;
            }
            set
            {
                this.instrumentationField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }
        
        #region Clone method
        /// <summary>
        /// Create a clone of this extension object
        /// </summary>
        public virtual extension Clone()
        {
            return ((extension)(this.MemberwiseClone()));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.6.0.20097")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:newrelic-extension")]
    public partial class extensionTracerFactory
    {
        
        private List<extensionTracerFactoryMatch> matchField;
        
        private string nameField;
        
        private string metricNameField;
        
        private bool enabledField;
        
        private string levelField;
        
        private bool suppressRecursiveCallsField;
        
        private extensionTracerFactoryMetric metricField;
        
        private bool transactionTraceSegmentField;
        
        private System.Nullable<ushort> transactionNamingPriorityField;
        
        /// <summary>
        /// extensionTracerFactory class constructor
        /// </summary>
        public extensionTracerFactory()
        {
            this.matchField = new List<extensionTracerFactoryMatch>();
            this.nameField = "NewRelic.Agent.Core.Tracer.Factories.DefaultTracerFactory";
            this.enabledField = true;
            this.levelField = "0";
            this.suppressRecursiveCallsField = true;
            this.metricField = extensionTracerFactoryMetric.scoped;
            this.transactionTraceSegmentField = true;
        }
        
        [System.Xml.Serialization.XmlElementAttribute("match")]
        public List<extensionTracerFactoryMatch> match
        {
            get
            {
                return this.matchField;
            }
            set
            {
                this.matchField = value;
            }
        }
        
        /// <summary>
        /// The full class name of the tracer factory.  If unspecified, the default tracer factory is used.
        /// Unless otherwise instructed, this attribute should remain blank when creating custom instrumentation
        /// for an application.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("NewRelic.Agent.Core.Tracer.Factories.DefaultTracerFactory")]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <summary>
        /// The metric name for this tracer.  Defaults to the instrumented class/method name.  If set to "instance",
        /// the metric name will be the class / method name using the class name of the invocation target instance at runtime.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string metricName
        {
            get
            {
                return this.metricNameField;
            }
            set
            {
                this.metricNameField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        [System.ComponentModel.DefaultValueAttribute("0")]
        public string level
        {
            get
            {
                return this.levelField;
            }
            set
            {
                this.levelField = value;
            }
        }
        
        /// <summary>
        /// Internal Only.  Subject to future change.
        /// By default, the agent will not create a new tracer if the parent tracer instruments the same class / method signature.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool suppressRecursiveCalls
        {
            get
            {
                return this.suppressRecursiveCallsField;
            }
            set
            {
                this.suppressRecursiveCallsField = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(extensionTracerFactoryMetric.scoped)]
        public extensionTracerFactoryMetric metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
        
        /// <summary>
        /// If true, a transaction tracer segment is generated for this tracer.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool transactionTraceSegment
        {
            get
            {
                return this.transactionTraceSegmentField;
            }
            set
            {
                this.transactionTraceSegmentField = value;
            }
        }
        
        /// <summary>
        /// If set, try to name the current transaction using this tracer.  Multiple tracers may try to name
        /// the transaction.  The highest priority wins.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort transactionNamingPriority
        {
            get
            {
                if (this.transactionNamingPriorityField.HasValue)
                {
                    return this.transactionNamingPriorityField.Value;
                }
                else
                {
                    return default(ushort);
                }
            }
            set
            {
                this.transactionNamingPriorityField = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool transactionNamingPrioritySpecified
        {
            get
            {
                return this.transactionNamingPriorityField.HasValue;
            }
            set
            {
                if (value==false)
                {
                    this.transactionNamingPriorityField = null;
                }
            }
        }
        
        #region Clone method
        /// <summary>
        /// Create a clone of this extensionTracerFactory object
        /// </summary>
        public virtual extensionTracerFactory Clone()
        {
            return ((extensionTracerFactory)(this.MemberwiseClone()));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.6.0.20097")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:newrelic-extension")]
    public partial class extensionTracerFactoryMatch
    {
        
        private List<extensionTracerFactoryMatchExactMethodMatcher> exactMethodMatcherField;
        
        private string assemblyNameField;
        
        private string minVersionField;
        
        private string maxVersionField;
        
        private string classNameField;
        
        /// <summary>
        /// extensionTracerFactoryMatch class constructor
        /// </summary>
        public extensionTracerFactoryMatch()
        {
            this.exactMethodMatcherField = new List<extensionTracerFactoryMatchExactMethodMatcher>();
        }
        
        [System.Xml.Serialization.XmlElementAttribute("exactMethodMatcher")]
        public List<extensionTracerFactoryMatchExactMethodMatcher> exactMethodMatcher
        {
            get
            {
                return this.exactMethodMatcherField;
            }
            set
            {
                this.exactMethodMatcherField = value;
            }
        }
        
        /// <summary>
        /// The full assembly name to match.  This is case sensitive - use the correct mixed case.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string assemblyName
        {
            get
            {
                return this.assemblyNameField;
            }
            set
            {
                this.assemblyNameField = value;
            }
        }
        
        /// <summary>
        /// The minimum version (inclusive) for this assembly to match. e.g. "1.2.3.4"
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string minVersion
        {
            get
            {
                return this.minVersionField;
            }
            set
            {
                this.minVersionField = value;
            }
        }
        
        /// <summary>
        /// The maximum version (inclusive) for this assembly to mach. e.g. "1.2.3.4"
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string maxVersion
        {
            get
            {
                return this.maxVersionField;
            }
            set
            {
                this.maxVersionField = value;
            }
        }
        
        /// <summary>
        /// The full class name to match.  This is case sensitive - use the correct mixed case.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string className
        {
            get
            {
                return this.classNameField;
            }
            set
            {
                this.classNameField = value;
            }
        }
        
        #region Clone method
        /// <summary>
        /// Create a clone of this extensionTracerFactoryMatch object
        /// </summary>
        public virtual extensionTracerFactoryMatch Clone()
        {
            return ((extensionTracerFactoryMatch)(this.MemberwiseClone()));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.6.0.20097")]
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:newrelic-extension")]
    public partial class extensionTracerFactoryMatchExactMethodMatcher
    {
        
        private string methodNameField;
        
        private string parametersField;
        
        /// <summary>
        /// The name of the method to match.  This is case sensitive - use the correct mixed case.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string methodName
        {
            get
            {
                return this.methodNameField;
            }
            set
            {
                this.methodNameField = value;
            }
        }
        
        /// <summary>
        /// The method parameters to match.  This is optional, and should only be used when a
        /// method is overloaded and you want to instrument a specific version of the method.
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
        
        #region Clone method
        /// <summary>
        /// Create a clone of this extensionTracerFactoryMatchExactMethodMatcher object
        /// </summary>
        public virtual extensionTracerFactoryMatchExactMethodMatcher Clone()
        {
            return ((extensionTracerFactoryMatchExactMethodMatcher)(this.MemberwiseClone()));
        }
        #endregion
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Xsd2Code", "3.6.0.20097")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="urn:newrelic-extension")]
    public enum extensionTracerFactoryMetric
    {
        
        none,
        
        scoped,
        
        unscoped,
        
        both,
    }
}
