﻿#pragma checksum "..\..\..\Forms\Registration.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD475691FD309E7E36B2978DAC0388D80081DA6B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace MasterRecon.Forms {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtActivationKey;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnValidate;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblFullName;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFullName;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMobileName;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMobileNo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblEmailID;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmailID;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblValidityDate;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtValidUpto;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Forms\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnActivate;
        
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
            System.Uri resourceLocater = new System.Uri("/MasterRecon;component/forms/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Forms\Registration.xaml"
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
            
            #line 8 "..\..\..\Forms\Registration.xaml"
            ((MasterRecon.Forms.Registration)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\..\Forms\Registration.xaml"
            ((MasterRecon.Forms.Registration)(target)).Unloaded += new System.Windows.RoutedEventHandler(this.Page_Unloaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtActivationKey = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnValidate = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Forms\Registration.xaml"
            this.btnValidate.Click += new System.Windows.RoutedEventHandler(this.btnValidate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lblFullName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtFullName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.lblMobileName = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.txtMobileNo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.lblEmailID = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.txtEmailID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.lblValidityDate = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.txtValidUpto = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 12:
            this.btnActivate = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Forms\Registration.xaml"
            this.btnActivate.Click += new System.Windows.RoutedEventHandler(this.btnActivate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
