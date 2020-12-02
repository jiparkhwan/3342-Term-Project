﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace _3342_Term_Project.GetGameService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="GetGameSoap", Namespace="http://tempuri.org/")]
    public partial class GetGame : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetRandomGameOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GetGame() {
            this.Url = global::_3342_Term_Project.Properties.Settings.Default._3342_Term_Project_GetGameService_GetGame;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetRandomGameCompletedEventHandler GetRandomGameCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetRandomGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public VideoGames[] GetRandomGame() {
            object[] results = this.Invoke("GetRandomGame", new object[0]);
            return ((VideoGames[])(results[0]));
        }
        
        /// <remarks/>
        public void GetRandomGameAsync() {
            this.GetRandomGameAsync(null);
        }
        
        /// <remarks/>
        public void GetRandomGameAsync(object userState) {
            if ((this.GetRandomGameOperationCompleted == null)) {
                this.GetRandomGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRandomGameOperationCompleted);
            }
            this.InvokeAsync("GetRandomGame", new object[0], this.GetRandomGameOperationCompleted, userState);
        }
        
        private void OnGetRandomGameOperationCompleted(object arg) {
            if ((this.GetRandomGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRandomGameCompleted(this, new GetRandomGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3752.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class VideoGames {
        
        private string gameNameField;
        
        private int gameYearField;
        
        private string gameGenreField;
        
        private string gameDescriptionField;
        
        private string gameCreatorField;
        
        private string gameAgeRatingField;
        
        private string gameImageField;
        
        private int gameIDField;
        
        /// <remarks/>
        public string GameName {
            get {
                return this.gameNameField;
            }
            set {
                this.gameNameField = value;
            }
        }
        
        /// <remarks/>
        public int GameYear {
            get {
                return this.gameYearField;
            }
            set {
                this.gameYearField = value;
            }
        }
        
        /// <remarks/>
        public string GameGenre {
            get {
                return this.gameGenreField;
            }
            set {
                this.gameGenreField = value;
            }
        }
        
        /// <remarks/>
        public string GameDescription {
            get {
                return this.gameDescriptionField;
            }
            set {
                this.gameDescriptionField = value;
            }
        }
        
        /// <remarks/>
        public string GameCreator {
            get {
                return this.gameCreatorField;
            }
            set {
                this.gameCreatorField = value;
            }
        }
        
        /// <remarks/>
        public string GameAgeRating {
            get {
                return this.gameAgeRatingField;
            }
            set {
                this.gameAgeRatingField = value;
            }
        }
        
        /// <remarks/>
        public string GameImage {
            get {
                return this.gameImageField;
            }
            set {
                this.gameImageField = value;
            }
        }
        
        /// <remarks/>
        public int GameID {
            get {
                return this.gameIDField;
            }
            set {
                this.gameIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    public delegate void GetRandomGameCompletedEventHandler(object sender, GetRandomGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.3752.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRandomGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRandomGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public VideoGames[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((VideoGames[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591