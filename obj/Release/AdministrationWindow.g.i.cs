﻿#pragma checksum "..\..\AdministrationWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "48FEF92888EFEBCC9A9C9FAFE561BD29"
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
    /// AdministrationWindow
    /// </summary>
    public partial class AdministrationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_Name;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ParseCurses;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentGrid;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame AdminFrame;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox AllClients;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AdministrationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid AllClientsTable;
        
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
            System.Uri resourceLocater = new System.Uri("/Custodian;component/administrationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdministrationWindow.xaml"
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
            
            #line 8 "..\..\AdministrationWindow.xaml"
            ((Custodian.AdministrationWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\AdministrationWindow.xaml"
            ((Custodian.AdministrationWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 11 "..\..\AdministrationWindow.xaml"
            this.MainGrid.Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 15 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AdminSettings);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 21 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddNewClient);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 24 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.BuyOperation);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 26 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.TransferOperation);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 28 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SaleOperation);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.FundingOperation);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 32 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.WithdrawOperation);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 34 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCash);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 36 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ConvertOperation);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 41 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.IsinQuote_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 45 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PublickLubrary);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 46 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PrivateDocumentAdd);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 50 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.GotoCommissinsForm);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 53 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.TasksFrame_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 55 "..\..\AdministrationWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.ChatClick);
            
            #line default
            #line hidden
            return;
            case 19:
            this.lbl_Name = ((System.Windows.Controls.Label)(target));
            return;
            case 20:
            this.ParseCurses = ((System.Windows.Controls.Label)(target));
            return;
            case 21:
            this.ContentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 22:
            this.AdminFrame = ((System.Windows.Controls.Frame)(target));
            return;
            case 23:
            this.AllClients = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 24:
            this.AllClientsTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

