﻿#pragma checksum "..\..\..\..\View\Controls\MazeWall.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A118E5C7187646FEF067F7AAD19BFDE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ATP2016ProjectNew.View;
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


namespace ATP2016ProjectNew.View {
    
    
    /// <summary>
    /// MazeWall
    /// </summary>
    public partial class MazeWall : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel DockP_Mwall;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_up;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_down;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextB_MazeWall;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextB_SizeMaze;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\View\Controls\MazeWall.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextB_GoalPois;
        
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
            System.Uri resourceLocater = new System.Uri("/ATP2016ProjectNew;component/view/controls/mazewall.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Controls\MazeWall.xaml"
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
            this.DockP_Mwall = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.button_up = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\View\Controls\MazeWall.xaml"
            this.button_up.Click += new System.Windows.RoutedEventHandler(this.button_up_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.button_down = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\View\Controls\MazeWall.xaml"
            this.button_down.Click += new System.Windows.RoutedEventHandler(this.button_down_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextB_MazeWall = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TextB_SizeMaze = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.TextB_GoalPois = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

