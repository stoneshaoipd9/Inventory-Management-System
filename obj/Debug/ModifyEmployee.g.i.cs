﻿#pragma checksum "..\..\ModifyEmployee.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0587BC2B025574D99B030BB0F0268511"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoParts;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace AutoParts {
    
    
    /// <summary>
    /// ModifyEmployee
    /// </summary>
    public partial class ModifyEmployee : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvModifyEmployeeList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboMESortBy;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMCAdd;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMCRemove;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMCUpdate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMCRefresh;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMCReturn;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblMEId;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMELastName;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMEIsAdmin;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMEUserName;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMEFirstName;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ModifyEmployee.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbMEPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/AutoParts;component/modifyemployee.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModifyEmployee.xaml"
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
            this.lvModifyEmployeeList = ((System.Windows.Controls.ListView)(target));
            
            #line 10 "..\..\ModifyEmployee.xaml"
            this.lvModifyEmployeeList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.lvModifyEmployeeList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.comboMESortBy = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\ModifyEmployee.xaml"
            this.comboMESortBy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.comboMESortBy_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 23 "..\..\ModifyEmployee.xaml"
            this.comboMESortBy.DropDownClosed += new System.EventHandler(this.comboMESortBy_DropDownClosed);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnMCAdd = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ModifyEmployee.xaml"
            this.btnMCAdd.Click += new System.Windows.RoutedEventHandler(this.btnMCAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnMCRemove = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\ModifyEmployee.xaml"
            this.btnMCRemove.Click += new System.Windows.RoutedEventHandler(this.btnMCRemove_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnMCUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ModifyEmployee.xaml"
            this.btnMCUpdate.Click += new System.Windows.RoutedEventHandler(this.btnMCUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnMCRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\ModifyEmployee.xaml"
            this.btnMCRefresh.Click += new System.Windows.RoutedEventHandler(this.btnMCRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnMCReturn = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\ModifyEmployee.xaml"
            this.btnMCReturn.Click += new System.Windows.RoutedEventHandler(this.btnMCReturn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblMEId = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.tbMELastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.tbMEIsAdmin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbMEUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.tbMEFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 13:
            this.tbMEPassword = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

