﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B4628F4465898F98B8EB605C8C7310FA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DragDopTest;
using Infragistics;
using Infragistics.Controls;
using Infragistics.DragDrop;
using Infragistics.Shared;
using Infragistics.Themes;
using Infragistics.Windows;
using Infragistics.Windows.Controls;
using Infragistics.Windows.Controls.Markup;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.DataPresenter.Calculations;
using Infragistics.Windows.Editors;
using Infragistics.Windows.Reporting;
using Infragistics.Windows.Ribbon;
using Infragistics.Windows.Themes;
using Infragistics.Windows.Tiles;
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


namespace DragDopTest {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider mySlider;
        
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
            System.Uri resourceLocater = new System.Uri("/DragDopTest;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.mySlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 2:
            
            #line 61 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).Drop += new System.EventHandler<Infragistics.DragDrop.DropEventArgs>(this.DragSource_Drop);
            
            #line default
            #line hidden
            
            #line 62 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragStart += new System.EventHandler<Infragistics.DragDrop.DragDropStartEventArgs>(this.DragSource_DragStart);
            
            #line default
            #line hidden
            
            #line 63 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnter += new System.EventHandler<Infragistics.DragDrop.DragDropCancelEventArgs>(this.DragSource_DragEnter);
            
            #line default
            #line hidden
            
            #line 64 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragLeave += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragLeave);
            
            #line default
            #line hidden
            
            #line 65 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnd += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragEnd);
            
            #line default
            #line hidden
            
            #line 66 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragOver += new System.EventHandler<Infragistics.DragDrop.DragDropMoveEventArgs>(this.DragSource_DragOver);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 76 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).Drop += new System.EventHandler<Infragistics.DragDrop.DropEventArgs>(this.DragSource_Drop);
            
            #line default
            #line hidden
            
            #line 77 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragStart += new System.EventHandler<Infragistics.DragDrop.DragDropStartEventArgs>(this.DragSource_DragStart);
            
            #line default
            #line hidden
            
            #line 78 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnter += new System.EventHandler<Infragistics.DragDrop.DragDropCancelEventArgs>(this.DragSource_DragEnter);
            
            #line default
            #line hidden
            
            #line 79 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragLeave += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragLeave);
            
            #line default
            #line hidden
            
            #line 80 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnd += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragEnd);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragOver += new System.EventHandler<Infragistics.DragDrop.DragDropMoveEventArgs>(this.DragSource_DragOver);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 91 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).Drop += new System.EventHandler<Infragistics.DragDrop.DropEventArgs>(this.DragSource_Drop);
            
            #line default
            #line hidden
            
            #line 92 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragStart += new System.EventHandler<Infragistics.DragDrop.DragDropStartEventArgs>(this.DragSource_DragStart);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnter += new System.EventHandler<Infragistics.DragDrop.DragDropCancelEventArgs>(this.DragSource_DragEnter);
            
            #line default
            #line hidden
            
            #line 94 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragLeave += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragLeave);
            
            #line default
            #line hidden
            
            #line 95 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnd += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragEnd);
            
            #line default
            #line hidden
            
            #line 96 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragOver += new System.EventHandler<Infragistics.DragDrop.DragDropMoveEventArgs>(this.DragSource_DragOver);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 106 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).Drop += new System.EventHandler<Infragistics.DragDrop.DropEventArgs>(this.DragSource_Drop);
            
            #line default
            #line hidden
            
            #line 107 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragStart += new System.EventHandler<Infragistics.DragDrop.DragDropStartEventArgs>(this.DragSource_DragStart);
            
            #line default
            #line hidden
            
            #line 108 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnter += new System.EventHandler<Infragistics.DragDrop.DragDropCancelEventArgs>(this.DragSource_DragEnter);
            
            #line default
            #line hidden
            
            #line 109 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragLeave += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragLeave);
            
            #line default
            #line hidden
            
            #line 110 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnd += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragEnd);
            
            #line default
            #line hidden
            
            #line 111 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragOver += new System.EventHandler<Infragistics.DragDrop.DragDropMoveEventArgs>(this.DragSource_DragOver);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 121 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).Drop += new System.EventHandler<Infragistics.DragDrop.DropEventArgs>(this.DragSource_Drop);
            
            #line default
            #line hidden
            
            #line 122 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragStart += new System.EventHandler<Infragistics.DragDrop.DragDropStartEventArgs>(this.DragSource_DragStart);
            
            #line default
            #line hidden
            
            #line 123 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnter += new System.EventHandler<Infragistics.DragDrop.DragDropCancelEventArgs>(this.DragSource_DragEnter);
            
            #line default
            #line hidden
            
            #line 124 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragLeave += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragLeave);
            
            #line default
            #line hidden
            
            #line 125 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragEnd += new System.EventHandler<Infragistics.DragDrop.DragDropEventArgs>(this.DragSource_DragEnd);
            
            #line default
            #line hidden
            
            #line 126 "..\..\MainWindow.xaml"
            ((Infragistics.DragDrop.DragSource)(target)).DragOver += new System.EventHandler<Infragistics.DragDrop.DragDropMoveEventArgs>(this.DragSource_DragOver);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

