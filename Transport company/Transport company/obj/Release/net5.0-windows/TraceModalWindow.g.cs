﻿#pragma checksum "..\..\..\TraceModalWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E06487FBF50BADEDA9B4994F4C9ADF72016D8413"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Transport_company;


namespace Transport_company {
    
    
    /// <summary>
    /// TraceModalWindow
    /// </summary>
    public partial class TraceModalWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextStart;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextFinish;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextMass;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Start;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Finish;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Mass;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AutoInfo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextMass_Copy;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\TraceModalWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DatePick;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Transport company;component/tracemodalwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TraceModalWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TextStart = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.TextFinish = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.TextMass = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.Start = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\TraceModalWindow.xaml"
            this.Start.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Start_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Finish = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\TraceModalWindow.xaml"
            this.Finish.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Finish_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Mass = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\TraceModalWindow.xaml"
            this.Mass.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Mass_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AutoInfo = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\TraceModalWindow.xaml"
            this.AutoInfo.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AutoInfo_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 27 "..\..\..\TraceModalWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Accept_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TextMass_Copy = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.DatePick = ((System.Windows.Controls.DatePicker)(target));
            
            #line 29 "..\..\..\TraceModalWindow.xaml"
            this.DatePick.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DatePick_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
