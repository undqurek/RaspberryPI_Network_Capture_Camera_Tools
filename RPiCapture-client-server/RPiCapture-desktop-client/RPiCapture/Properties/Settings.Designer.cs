﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPiCapture.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.1.100")]
        public string LEFT_CAMERA_HOST {
            get {
                return ((string)(this["LEFT_CAMERA_HOST"]));
            }
            set {
                this["LEFT_CAMERA_HOST"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192.168.1.101")]
        public string RIGHT_CAMERA_HOST {
            get {
                return ((string)(this["RIGHT_CAMERA_HOST"]));
            }
            set {
                this["RIGHT_CAMERA_HOST"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal LEFT_CAMERA_ROTATION {
            get {
                return ((decimal)(this["LEFT_CAMERA_ROTATION"]));
            }
            set {
                this["LEFT_CAMERA_ROTATION"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal LEFT_CAMERA_X_SHIFT {
            get {
                return ((decimal)(this["LEFT_CAMERA_X_SHIFT"]));
            }
            set {
                this["LEFT_CAMERA_X_SHIFT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal LEFT_CAMERA_Y_SHIFT {
            get {
                return ((decimal)(this["LEFT_CAMERA_Y_SHIFT"]));
            }
            set {
                this["LEFT_CAMERA_Y_SHIFT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal RIGHT_CAMERA_ROTATION {
            get {
                return ((decimal)(this["RIGHT_CAMERA_ROTATION"]));
            }
            set {
                this["RIGHT_CAMERA_ROTATION"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal RIGHT_CAMERA_X_SHIFT {
            get {
                return ((decimal)(this["RIGHT_CAMERA_X_SHIFT"]));
            }
            set {
                this["RIGHT_CAMERA_X_SHIFT"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public decimal RIGHT_CAMERA_Y_SHIFT {
            get {
                return ((decimal)(this["RIGHT_CAMERA_Y_SHIFT"]));
            }
            set {
                this["RIGHT_CAMERA_Y_SHIFT"] = value;
            }
        }
    }
}
