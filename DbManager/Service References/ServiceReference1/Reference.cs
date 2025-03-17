﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbManager.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Tag", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.InputTag))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.AnalogInput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.DigitalInput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.OutputTag))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.AnalogOutput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.DigitalOutput))]
    public partial class Tag : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ioAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tagIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.descriptionField, value) != true)) {
                    this.descriptionField = value;
                    this.RaisePropertyChanged("description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ioAddress {
            get {
                return this.ioAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.ioAddressField, value) != true)) {
                    this.ioAddressField = value;
                    this.RaisePropertyChanged("ioAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tagId {
            get {
                return this.tagIdField;
            }
            set {
                if ((object.ReferenceEquals(this.tagIdField, value) != true)) {
                    this.tagIdField = value;
                    this.RaisePropertyChanged("tagId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InputTag", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.AnalogInput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.DigitalInput))]
    public partial class InputTag : DbManager.ServiceReference1.Tag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] alarmsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string driverField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool scanOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int scanTimeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] alarms {
            get {
                return this.alarmsField;
            }
            set {
                if ((object.ReferenceEquals(this.alarmsField, value) != true)) {
                    this.alarmsField = value;
                    this.RaisePropertyChanged("alarms");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string driver {
            get {
                return this.driverField;
            }
            set {
                if ((object.ReferenceEquals(this.driverField, value) != true)) {
                    this.driverField = value;
                    this.RaisePropertyChanged("driver");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool scanOn {
            get {
                return this.scanOnField;
            }
            set {
                if ((this.scanOnField.Equals(value) != true)) {
                    this.scanOnField = value;
                    this.RaisePropertyChanged("scanOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int scanTime {
            get {
                return this.scanTimeField;
            }
            set {
                if ((this.scanTimeField.Equals(value) != true)) {
                    this.scanTimeField = value;
                    this.RaisePropertyChanged("scanTime");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnalogInput", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    public partial class AnalogInput : DbManager.ServiceReference1.InputTag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double highLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double lowLimitField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double highLimit {
            get {
                return this.highLimitField;
            }
            set {
                if ((this.highLimitField.Equals(value) != true)) {
                    this.highLimitField = value;
                    this.RaisePropertyChanged("highLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lowLimit {
            get {
                return this.lowLimitField;
            }
            set {
                if ((this.lowLimitField.Equals(value) != true)) {
                    this.lowLimitField = value;
                    this.RaisePropertyChanged("lowLimit");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalInput", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    public partial class DigitalInput : DbManager.ServiceReference1.InputTag {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OutputTag", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.AnalogOutput))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(DbManager.ServiceReference1.DigitalOutput))]
    public partial class OutputTag : DbManager.ServiceReference1.Tag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double initialValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double initialValue {
            get {
                return this.initialValueField;
            }
            set {
                if ((this.initialValueField.Equals(value) != true)) {
                    this.initialValueField = value;
                    this.RaisePropertyChanged("initialValue");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnalogOutput", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    public partial class AnalogOutput : DbManager.ServiceReference1.OutputTag {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double highLimitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double lowLimitField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double highLimit {
            get {
                return this.highLimitField;
            }
            set {
                if ((this.highLimitField.Equals(value) != true)) {
                    this.highLimitField = value;
                    this.RaisePropertyChanged("highLimit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double lowLimit {
            get {
                return this.lowLimitField;
            }
            set {
                if ((this.lowLimitField.Equals(value) != true)) {
                    this.lowLimitField = value;
                    this.RaisePropertyChanged("lowLimit");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DigitalOutput", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    public partial class DigitalOutput : DbManager.ServiceReference1.OutputTag {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Alarm", Namespace="http://schemas.datacontract.org/2004/07/SCADA")]
    [System.SerializableAttribute()]
    public partial class Alarm : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string alarmIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double criticalValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int priorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string tagIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double tagValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string typeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string alarmId {
            get {
                return this.alarmIdField;
            }
            set {
                if ((object.ReferenceEquals(this.alarmIdField, value) != true)) {
                    this.alarmIdField = value;
                    this.RaisePropertyChanged("alarmId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double criticalValue {
            get {
                return this.criticalValueField;
            }
            set {
                if ((this.criticalValueField.Equals(value) != true)) {
                    this.criticalValueField = value;
                    this.RaisePropertyChanged("criticalValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int priority {
            get {
                return this.priorityField;
            }
            set {
                if ((this.priorityField.Equals(value) != true)) {
                    this.priorityField = value;
                    this.RaisePropertyChanged("priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string tagId {
            get {
                return this.tagIdField;
            }
            set {
                if ((object.ReferenceEquals(this.tagIdField, value) != true)) {
                    this.tagIdField = value;
                    this.RaisePropertyChanged("tagId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double tagValue {
            get {
                return this.tagValueField;
            }
            set {
                if ((this.tagValueField.Equals(value) != true)) {
                    this.tagValueField = value;
                    this.RaisePropertyChanged("tagValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                if ((object.ReferenceEquals(this.typeField, value) != true)) {
                    this.typeField = value;
                    this.RaisePropertyChanged("type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDatabaseManager")]
    public interface IDatabaseManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalInputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalInputTagResponse")]
        bool AddDigitalInputTag(string id, string description, string address, string driver, int time, bool on);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalInputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalInputTagResponse")]
        System.Threading.Tasks.Task<bool> AddDigitalInputTagAsync(string id, string description, string address, string driver, int time, bool on);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalOutputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalOutputTagResponse")]
        bool AddDigitalOutputTag(string id, string description, string address, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddDigitalOutputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddDigitalOutputTagResponse")]
        System.Threading.Tasks.Task<bool> AddDigitalOutputTagAsync(string id, string description, string address, int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogInputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogInputTagResponse")]
        bool AddAnalogInputTag(string id, string desc, string address, string driver, int time, bool on, double low, double high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogInputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogInputTagResponse")]
        System.Threading.Tasks.Task<bool> AddAnalogInputTagAsync(string id, string desc, string address, string driver, int time, bool on, double low, double high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogOuputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogOuputTagResponse")]
        bool AddAnalogOuputTag(string id, string description, string address, double initialValue, double low, double high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAnalogOuputTag", ReplyAction="http://tempuri.org/IDatabaseManager/AddAnalogOuputTagResponse")]
        System.Threading.Tasks.Task<bool> AddAnalogOuputTagAsync(string id, string description, string address, double initialValue, double low, double high);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        bool RemoveTag(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveTag", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveTagResponse")]
        System.Threading.Tasks.Task<bool> RemoveTagAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/UpdateTag", ReplyAction="http://tempuri.org/IDatabaseManager/UpdateTagResponse")]
        void UpdateTag(DbManager.ServiceReference1.Tag tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/UpdateTag", ReplyAction="http://tempuri.org/IDatabaseManager/UpdateTagResponse")]
        System.Threading.Tasks.Task UpdateTagAsync(DbManager.ServiceReference1.Tag tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/SetInitialValue", ReplyAction="http://tempuri.org/IDatabaseManager/SetInitialValueResponse")]
        bool SetInitialValue(string tagId, string ioAddress, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/SetInitialValue", ReplyAction="http://tempuri.org/IDatabaseManager/SetInitialValueResponse")]
        System.Threading.Tasks.Task<bool> SetInitialValueAsync(string tagId, string ioAddress, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetTagsResponse")]
        DbManager.ServiceReference1.Tag[] GetTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetTagsResponse")]
        System.Threading.Tasks.Task<DbManager.ServiceReference1.Tag[]> GetTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetInputTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetInputTagsResponse")]
        DbManager.ServiceReference1.InputTag[] GetInputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetInputTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetInputTagsResponse")]
        System.Threading.Tasks.Task<DbManager.ServiceReference1.InputTag[]> GetInputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetAlarmsForTag", ReplyAction="http://tempuri.org/IDatabaseManager/GetAlarmsForTagResponse")]
        DbManager.ServiceReference1.Alarm[] GetAlarmsForTag(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetAlarmsForTag", ReplyAction="http://tempuri.org/IDatabaseManager/GetAlarmsForTagResponse")]
        System.Threading.Tasks.Task<DbManager.ServiceReference1.Alarm[]> GetAlarmsForTagAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetAllAlarms", ReplyAction="http://tempuri.org/IDatabaseManager/GetAllAlarmsResponse")]
        DbManager.ServiceReference1.Alarm[] GetAllAlarms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetAllAlarms", ReplyAction="http://tempuri.org/IDatabaseManager/GetAllAlarmsResponse")]
        System.Threading.Tasks.Task<DbManager.ServiceReference1.Alarm[]> GetAllAlarmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputTagsResponse")]
        DbManager.ServiceReference1.OutputTag[] GetOutputTags();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputTags", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputTagsResponse")]
        System.Threading.Tasks.Task<DbManager.ServiceReference1.OutputTag[]> GetOutputTagsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputTagAddressesAndValues", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputTagAddressesAndValuesResponse")]
        System.Collections.Generic.Dictionary<string, double> GetOutputTagAddressesAndValues();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/GetOutputTagAddressesAndValues", ReplyAction="http://tempuri.org/IDatabaseManager/GetOutputTagAddressesAndValuesResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetOutputTagAddressesAndValuesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOn", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOnResponse")]
        bool ScanOn(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOn", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOnResponse")]
        System.Threading.Tasks.Task<bool> ScanOnAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOff", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOffResponse")]
        bool ScanOff(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/ScanOff", ReplyAction="http://tempuri.org/IDatabaseManager/ScanOffResponse")]
        System.Threading.Tasks.Task<bool> ScanOffAsync(string tagId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/AddAlarmResponse")]
        bool AddAlarm(string alarmId, string tagId, double triggerValue, string type, int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/AddAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/AddAlarmResponse")]
        System.Threading.Tasks.Task<bool> AddAlarmAsync(string alarmId, string tagId, double triggerValue, string type, int priority);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveAlarmResponse")]
        bool RemoveAlarm(string tagId, string alarmId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDatabaseManager/RemoveAlarm", ReplyAction="http://tempuri.org/IDatabaseManager/RemoveAlarmResponse")]
        System.Threading.Tasks.Task<bool> RemoveAlarmAsync(string tagId, string alarmId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDatabaseManagerChannel : DbManager.ServiceReference1.IDatabaseManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DatabaseManagerClient : System.ServiceModel.ClientBase<DbManager.ServiceReference1.IDatabaseManager>, DbManager.ServiceReference1.IDatabaseManager {
        
        public DatabaseManagerClient() {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DatabaseManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool AddDigitalInputTag(string id, string description, string address, string driver, int time, bool on) {
            return base.Channel.AddDigitalInputTag(id, description, address, driver, time, on);
        }
        
        public System.Threading.Tasks.Task<bool> AddDigitalInputTagAsync(string id, string description, string address, string driver, int time, bool on) {
            return base.Channel.AddDigitalInputTagAsync(id, description, address, driver, time, on);
        }
        
        public bool AddDigitalOutputTag(string id, string description, string address, int value) {
            return base.Channel.AddDigitalOutputTag(id, description, address, value);
        }
        
        public System.Threading.Tasks.Task<bool> AddDigitalOutputTagAsync(string id, string description, string address, int value) {
            return base.Channel.AddDigitalOutputTagAsync(id, description, address, value);
        }
        
        public bool AddAnalogInputTag(string id, string desc, string address, string driver, int time, bool on, double low, double high) {
            return base.Channel.AddAnalogInputTag(id, desc, address, driver, time, on, low, high);
        }
        
        public System.Threading.Tasks.Task<bool> AddAnalogInputTagAsync(string id, string desc, string address, string driver, int time, bool on, double low, double high) {
            return base.Channel.AddAnalogInputTagAsync(id, desc, address, driver, time, on, low, high);
        }
        
        public bool AddAnalogOuputTag(string id, string description, string address, double initialValue, double low, double high) {
            return base.Channel.AddAnalogOuputTag(id, description, address, initialValue, low, high);
        }
        
        public System.Threading.Tasks.Task<bool> AddAnalogOuputTagAsync(string id, string description, string address, double initialValue, double low, double high) {
            return base.Channel.AddAnalogOuputTagAsync(id, description, address, initialValue, low, high);
        }
        
        public bool RemoveTag(string tagId) {
            return base.Channel.RemoveTag(tagId);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveTagAsync(string tagId) {
            return base.Channel.RemoveTagAsync(tagId);
        }
        
        public void UpdateTag(DbManager.ServiceReference1.Tag tag) {
            base.Channel.UpdateTag(tag);
        }
        
        public System.Threading.Tasks.Task UpdateTagAsync(DbManager.ServiceReference1.Tag tag) {
            return base.Channel.UpdateTagAsync(tag);
        }
        
        public bool SetInitialValue(string tagId, string ioAddress, double value) {
            return base.Channel.SetInitialValue(tagId, ioAddress, value);
        }
        
        public System.Threading.Tasks.Task<bool> SetInitialValueAsync(string tagId, string ioAddress, double value) {
            return base.Channel.SetInitialValueAsync(tagId, ioAddress, value);
        }
        
        public DbManager.ServiceReference1.Tag[] GetTags() {
            return base.Channel.GetTags();
        }
        
        public System.Threading.Tasks.Task<DbManager.ServiceReference1.Tag[]> GetTagsAsync() {
            return base.Channel.GetTagsAsync();
        }
        
        public DbManager.ServiceReference1.InputTag[] GetInputTags() {
            return base.Channel.GetInputTags();
        }
        
        public System.Threading.Tasks.Task<DbManager.ServiceReference1.InputTag[]> GetInputTagsAsync() {
            return base.Channel.GetInputTagsAsync();
        }
        
        public DbManager.ServiceReference1.Alarm[] GetAlarmsForTag(string tagId) {
            return base.Channel.GetAlarmsForTag(tagId);
        }
        
        public System.Threading.Tasks.Task<DbManager.ServiceReference1.Alarm[]> GetAlarmsForTagAsync(string tagId) {
            return base.Channel.GetAlarmsForTagAsync(tagId);
        }
        
        public DbManager.ServiceReference1.Alarm[] GetAllAlarms() {
            return base.Channel.GetAllAlarms();
        }
        
        public System.Threading.Tasks.Task<DbManager.ServiceReference1.Alarm[]> GetAllAlarmsAsync() {
            return base.Channel.GetAllAlarmsAsync();
        }
        
        public DbManager.ServiceReference1.OutputTag[] GetOutputTags() {
            return base.Channel.GetOutputTags();
        }
        
        public System.Threading.Tasks.Task<DbManager.ServiceReference1.OutputTag[]> GetOutputTagsAsync() {
            return base.Channel.GetOutputTagsAsync();
        }
        
        public System.Collections.Generic.Dictionary<string, double> GetOutputTagAddressesAndValues() {
            return base.Channel.GetOutputTagAddressesAndValues();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, double>> GetOutputTagAddressesAndValuesAsync() {
            return base.Channel.GetOutputTagAddressesAndValuesAsync();
        }
        
        public bool ScanOn(string tagId) {
            return base.Channel.ScanOn(tagId);
        }
        
        public System.Threading.Tasks.Task<bool> ScanOnAsync(string tagId) {
            return base.Channel.ScanOnAsync(tagId);
        }
        
        public bool ScanOff(string tagId) {
            return base.Channel.ScanOff(tagId);
        }
        
        public System.Threading.Tasks.Task<bool> ScanOffAsync(string tagId) {
            return base.Channel.ScanOffAsync(tagId);
        }
        
        public bool AddAlarm(string alarmId, string tagId, double triggerValue, string type, int priority) {
            return base.Channel.AddAlarm(alarmId, tagId, triggerValue, type, priority);
        }
        
        public System.Threading.Tasks.Task<bool> AddAlarmAsync(string alarmId, string tagId, double triggerValue, string type, int priority) {
            return base.Channel.AddAlarmAsync(alarmId, tagId, triggerValue, type, priority);
        }
        
        public bool RemoveAlarm(string tagId, string alarmId) {
            return base.Channel.RemoveAlarm(tagId, alarmId);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveAlarmAsync(string tagId, string alarmId) {
            return base.Channel.RemoveAlarmAsync(tagId, alarmId);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IAuthentication")]
    public interface IAuthentication {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/Register", ReplyAction="http://tempuri.org/IAuthentication/RegisterResponse")]
        bool Register(string username, string password, bool admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/Register", ReplyAction="http://tempuri.org/IAuthentication/RegisterResponse")]
        System.Threading.Tasks.Task<bool> RegisterAsync(string username, string password, bool admin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/LogIn", ReplyAction="http://tempuri.org/IAuthentication/LogInResponse")]
        string[] LogIn(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/LogIn", ReplyAction="http://tempuri.org/IAuthentication/LogInResponse")]
        System.Threading.Tasks.Task<string[]> LogInAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/LogOut", ReplyAction="http://tempuri.org/IAuthentication/LogOutResponse")]
        bool LogOut(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/LogOut", ReplyAction="http://tempuri.org/IAuthentication/LogOutResponse")]
        System.Threading.Tasks.Task<bool> LogOutAsync(string token);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/emptyDb", ReplyAction="http://tempuri.org/IAuthentication/emptyDbResponse")]
        bool emptyDb();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/emptyDb", ReplyAction="http://tempuri.org/IAuthentication/emptyDbResponse")]
        System.Threading.Tasks.Task<bool> emptyDbAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/ValidateUser", ReplyAction="http://tempuri.org/IAuthentication/ValidateUserResponse")]
        bool ValidateUser(string Token, bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthentication/ValidateUser", ReplyAction="http://tempuri.org/IAuthentication/ValidateUserResponse")]
        System.Threading.Tasks.Task<bool> ValidateUserAsync(string Token, bool isAdmin);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticationChannel : DbManager.ServiceReference1.IAuthentication, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticationClient : System.ServiceModel.ClientBase<DbManager.ServiceReference1.IAuthentication>, DbManager.ServiceReference1.IAuthentication {
        
        public AuthenticationClient() {
        }
        
        public AuthenticationClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticationClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticationClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Register(string username, string password, bool admin) {
            return base.Channel.Register(username, password, admin);
        }
        
        public System.Threading.Tasks.Task<bool> RegisterAsync(string username, string password, bool admin) {
            return base.Channel.RegisterAsync(username, password, admin);
        }
        
        public string[] LogIn(string username, string password) {
            return base.Channel.LogIn(username, password);
        }
        
        public System.Threading.Tasks.Task<string[]> LogInAsync(string username, string password) {
            return base.Channel.LogInAsync(username, password);
        }
        
        public bool LogOut(string token) {
            return base.Channel.LogOut(token);
        }
        
        public System.Threading.Tasks.Task<bool> LogOutAsync(string token) {
            return base.Channel.LogOutAsync(token);
        }
        
        public bool emptyDb() {
            return base.Channel.emptyDb();
        }
        
        public System.Threading.Tasks.Task<bool> emptyDbAsync() {
            return base.Channel.emptyDbAsync();
        }
        
        public bool ValidateUser(string Token, bool isAdmin) {
            return base.Channel.ValidateUser(Token, isAdmin);
        }
        
        public System.Threading.Tasks.Task<bool> ValidateUserAsync(string Token, bool isAdmin) {
            return base.Channel.ValidateUserAsync(Token, isAdmin);
        }
    }
}
