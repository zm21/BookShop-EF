﻿#pragma checksum "..\..\LogInSignUo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4FAEA4C22272A354AD6EC86E13CCC515265BA6F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel login;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_signup;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbox_log;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox passwd_box;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel SignUP;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_login;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox regtxtbox_login;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox regpasswd;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox regtxtbox_email;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\LogInSignUo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button reg;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/loginsignuo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LogInSignUo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.login = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.btn_signup = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\LogInSignUo.xaml"
            this.btn_signup.Click += new System.Windows.RoutedEventHandler(this.Btn_signup_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtbox_log = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.passwd_box = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 5:
            
            #line 28 "..\..\LogInSignUo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonLogin_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SignUP = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 7:
            this.btn_login = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\LogInSignUo.xaml"
            this.btn_login.Click += new System.Windows.RoutedEventHandler(this.Btn_login_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.regtxtbox_login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.regpasswd = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 10:
            this.regtxtbox_email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.reg = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\LogInSignUo.xaml"
            this.reg.Click += new System.Windows.RoutedEventHandler(this.Reg_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
