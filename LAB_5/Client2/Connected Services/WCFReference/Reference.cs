﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.WCFReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="A", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    [System.SerializableAttribute()]
    public partial class A : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float fField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int kField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string sField;
        
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
        public float f {
            get {
                return this.fField;
            }
            set {
                if ((this.fField.Equals(value) != true)) {
                    this.fField = value;
                    this.RaisePropertyChanged("f");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int k {
            get {
                return this.kField;
            }
            set {
                if ((this.kField.Equals(value) != true)) {
                    this.kField = value;
                    this.RaisePropertyChanged("k");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string s {
            get {
                return this.sField;
            }
            set {
                if ((object.ReferenceEquals(this.sField, value) != true)) {
                    this.sField = value;
                    this.RaisePropertyChanged("s");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFReference.IWCFSimplex")]
    public interface IWCFSimplex {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Add", ReplyAction="http://tempuri.org/IWCFSimplex/AddResponse")]
        int Add(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Add", ReplyAction="http://tempuri.org/IWCFSimplex/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Concat", ReplyAction="http://tempuri.org/IWCFSimplex/ConcatResponse")]
        string Concat(string s, double d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Concat", ReplyAction="http://tempuri.org/IWCFSimplex/ConcatResponse")]
        System.Threading.Tasks.Task<string> ConcatAsync(string s, double d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Sum", ReplyAction="http://tempuri.org/IWCFSimplex/SumResponse")]
        Client.WCFReference.A Sum(Client.WCFReference.A a1, Client.WCFReference.A a2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFSimplex/Sum", ReplyAction="http://tempuri.org/IWCFSimplex/SumResponse")]
        System.Threading.Tasks.Task<Client.WCFReference.A> SumAsync(Client.WCFReference.A a1, Client.WCFReference.A a2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFSimplexChannel : Client.WCFReference.IWCFSimplex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFSimplexClient : System.ServiceModel.ClientBase<Client.WCFReference.IWCFSimplex>, Client.WCFReference.IWCFSimplex {
        
        public WCFSimplexClient() {
        }
        
        public WCFSimplexClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WCFSimplexClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFSimplexClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WCFSimplexClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int x, int y) {
            return base.Channel.Add(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int x, int y) {
            return base.Channel.AddAsync(x, y);
        }
        
        public string Concat(string s, double d) {
            return base.Channel.Concat(s, d);
        }
        
        public System.Threading.Tasks.Task<string> ConcatAsync(string s, double d) {
            return base.Channel.ConcatAsync(s, d);
        }
        
        public Client.WCFReference.A Sum(Client.WCFReference.A a1, Client.WCFReference.A a2) {
            return base.Channel.Sum(a1, a2);
        }
        
        public System.Threading.Tasks.Task<Client.WCFReference.A> SumAsync(Client.WCFReference.A a1, Client.WCFReference.A a2) {
            return base.Channel.SumAsync(a1, a2);
        }
    }
}