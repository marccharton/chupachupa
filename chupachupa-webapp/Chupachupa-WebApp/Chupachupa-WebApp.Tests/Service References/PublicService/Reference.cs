﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chupachupa_WebApp.Tests.PublicService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PublicService.IPublicServiceContract", SessionMode=System.ServiceModel.SessionMode.NotAllowed)]
    public interface IPublicServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicServiceContract/createAccount", ReplyAction="http://tempuri.org/IPublicServiceContract/createAccountResponse")]
        void createAccount(string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicServiceContract/createAccount", ReplyAction="http://tempuri.org/IPublicServiceContract/createAccountResponse")]
        System.Threading.Tasks.Task createAccountAsync(string login, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPublicServiceContractChannel : Chupachupa_WebApp.Tests.PublicService.IPublicServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PublicServiceContractClient : System.ServiceModel.ClientBase<Chupachupa_WebApp.Tests.PublicService.IPublicServiceContract>, Chupachupa_WebApp.Tests.PublicService.IPublicServiceContract {
        
        public PublicServiceContractClient() {
        }
        
        public PublicServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PublicServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublicServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublicServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void createAccount(string login, string password) {
            base.Channel.createAccount(login, password);
        }
        
        public System.Threading.Tasks.Task createAccountAsync(string login, string password) {
            return base.Channel.createAccountAsync(login, password);
        }
    }
}
