﻿#pragma checksum "..\..\SalonDeClases.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "84C489E8DE54D32547794B9923D489DF"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ClienteCSharp;
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


namespace ClienteCSharp {
    
    
    /// <summary>
    /// SalonDeClases
    /// </summary>
    public partial class SalonDeClases : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBxMensaje;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnEnviar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBxChat;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LstBxConectados;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtBlDireccionIP;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SalonDeClases.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WebBrowser WBwsrNavegador;
        
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
            System.Uri resourceLocater = new System.Uri("/ClienteCSharp;component/salondeclases.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SalonDeClases.xaml"
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
            
            #line 8 "..\..\SalonDeClases.xaml"
            ((ClienteCSharp.SalonDeClases)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TxtBxMensaje = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.BtnEnviar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\SalonDeClases.xaml"
            this.BtnEnviar.Click += new System.Windows.RoutedEventHandler(this.BtnEnviar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TxtBxChat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.LstBxConectados = ((System.Windows.Controls.ListBox)(target));
            
            #line 14 "..\..\SalonDeClases.xaml"
            this.LstBxConectados.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.LstBxConectados_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TxtBlDireccionIP = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.WBwsrNavegador = ((System.Windows.Controls.WebBrowser)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

