﻿#pragma checksum "..\..\ShowWind.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "252EA42D86FBA251F5B225C3FBD9E782"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Custodian;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Custodian {
    
    
    /// <summary>
    /// ShowWind
    /// </summary>
    public partial class ShowWind : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\ShowWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock informTXT;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ShowWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ricklev;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\ShowWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonPassChange;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ShowWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\ShowWind.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button No;
        
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
            System.Uri resourceLocater = new System.Uri("/CGAAF;component/showwind.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ShowWind.xaml"
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
            
            #line 12 "..\..\ShowWind.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.informTXT = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.ricklev = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.buttonPassChange = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\ShowWind.xaml"
            this.buttonPassChange.Click += new System.Windows.RoutedEventHandler(this.buttonPassChange_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\ShowWind.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.No = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\ShowWind.xaml"
            this.No.Click += new System.Windows.RoutedEventHandler(this.buttonPassChange_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

