﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClinicaFrba.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source = 192.168.1.130")]
        public string SQL_Server {
            get {
                return ((string)(this["SQL_Server"]));
            }
            set {
                this["SQL_Server"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Connection Timeout=999;")]
        public string SQL_Timeout {
            get {
                return ((string)(this["SQL_Timeout"]));
            }
            set {
                this["SQL_Timeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Database=GD2C2016")]
        public string SQL_Database {
            get {
                return ((string)(this["SQL_Database"]));
            }
            set {
                this["SQL_Database"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("User=gd;")]
        public string SQL_User {
            get {
                return ((string)(this["SQL_User"]));
            }
            set {
                this["SQL_User"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Password=gd2016;")]
        public string SQL_Password {
            get {
                return ((string)(this["SQL_Password"]));
            }
            set {
                this["SQL_Password"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SQLSERVER2012;")]
        public string SQL_Name {
            get {
                return ((string)(this["SQL_Name"]));
            }
            set {
                this["SQL_Name"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Persist Security Info=True;")]
        public string SQL_Security {
            get {
                return ((string)(this["SQL_Security"]));
            }
            set {
                this["SQL_Security"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECTIONADOS")]
        public string SQL_Schema {
            get {
                return ((string)(this["SQL_Schema"]));
            }
            set {
                this["SQL_Schema"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("9000")]
        public int Command_Timeout {
            get {
                return ((int)(this["Command_Timeout"]));
            }
            set {
                this["Command_Timeout"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2016-01-01")]
        public global::System.DateTime Fecha_Sistema {
            get {
                return ((global::System.DateTime)(this["Fecha_Sistema"]));
            }
            set {
                this["Fecha_Sistema"] = value;
            }
        }
    }
}
