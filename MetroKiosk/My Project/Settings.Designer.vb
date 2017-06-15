﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(sender As Global.System.Object, e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("192.168.1.91")>  _
        Public Property LogmasterIp() As String
            Get
                Return CType(Me("LogmasterIp"),String)
            End Get
            Set
                Me("LogmasterIp") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property DebugMode() As Boolean
            Get
                Return CType(Me("DebugMode"),Boolean)
            End Get
            Set
                Me("DebugMode") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property BluetoothEnabled() As Boolean
            Get
                Return CType(Me("BluetoothEnabled"),Boolean)
            End Get
            Set
                Me("BluetoothEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("6x4")>  _
        Public Property Size1Text() As String
            Get
                Return CType(Me("Size1Text"),String)
            End Get
            Set
                Me("Size1Text") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("7x5")>  _
        Public Property Size2Text() As String
            Get
                Return CType(Me("Size2Text"),String)
            End Get
            Set
                Me("Size2Text") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("8x6")>  _
        Public Property Size3Text() As String
            Get
                Return CType(Me("Size3Text"),String)
            End Get
            Set
                Me("Size3Text") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10x8")>  _
        Public Property Size4Text() As String
            Get
                Return CType(Me("Size4Text"),String)
            End Get
            Set
                Me("Size4Text") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("10x12")>  _
        Public Property Size5Text() As String
            Get
                Return CType(Me("Size5Text"),String)
            End Get
            Set
                Me("Size5Text") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("25")>  _
        Public Property PriceBand1Max() As Single
            Get
                Return CType(Me("PriceBand1Max"),Single)
            End Get
            Set
                Me("PriceBand1Max") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("50")>  _
        Public Property PriceBand2Max() As Single
            Get
                Return CType(Me("PriceBand2Max"),Single)
            End Get
            Set
                Me("PriceBand2Max") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property PriceBand3Max() As Single
            Get
                Return CType(Me("PriceBand3Max"),Single)
            End Get
            Set
                Me("PriceBand3Max") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.25")>  _
        Public Property Size1Price1() As Single
            Get
                Return CType(Me("Size1Price1"),Single)
            End Get
            Set
                Me("Size1Price1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.2")>  _
        Public Property Size1Price2() As Single
            Get
                Return CType(Me("Size1Price2"),Single)
            End Get
            Set
                Me("Size1Price2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.15")>  _
        Public Property Size1Price3() As Single
            Get
                Return CType(Me("Size1Price3"),Single)
            End Get
            Set
                Me("Size1Price3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.12")>  _
        Public Property Size1Price4() As Single
            Get
                Return CType(Me("Size1Price4"),Single)
            End Get
            Set
                Me("Size1Price4") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.5")>  _
        Public Property Size2Price1() As Single
            Get
                Return CType(Me("Size2Price1"),Single)
            End Get
            Set
                Me("Size2Price1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.35")>  _
        Public Property Size2Price2() As Single
            Get
                Return CType(Me("Size2Price2"),Single)
            End Get
            Set
                Me("Size2Price2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.3")>  _
        Public Property Size2Price3() As Single
            Get
                Return CType(Me("Size2Price3"),Single)
            End Get
            Set
                Me("Size2Price3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.25")>  _
        Public Property Size2Price4() As Single
            Get
                Return CType(Me("Size2Price4"),Single)
            End Get
            Set
                Me("Size2Price4") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.75")>  _
        Public Property Size3Price1() As Single
            Get
                Return CType(Me("Size3Price1"),Single)
            End Get
            Set
                Me("Size3Price1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.75")>  _
        Public Property Size3Price2() As Single
            Get
                Return CType(Me("Size3Price2"),Single)
            End Get
            Set
                Me("Size3Price2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.75")>  _
        Public Property Size3Price3() As Single
            Get
                Return CType(Me("Size3Price3"),Single)
            End Get
            Set
                Me("Size3Price3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0.75")>  _
        Public Property Size3Price4() As Single
            Get
                Return CType(Me("Size3Price4"),Single)
            End Get
            Set
                Me("Size3Price4") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.5")>  _
        Public Property Size4Price1() As Single
            Get
                Return CType(Me("Size4Price1"),Single)
            End Get
            Set
                Me("Size4Price1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.5")>  _
        Public Property Size4Price2() As Single
            Get
                Return CType(Me("Size4Price2"),Single)
            End Get
            Set
                Me("Size4Price2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.5")>  _
        Public Property Size4Price3() As Single
            Get
                Return CType(Me("Size4Price3"),Single)
            End Get
            Set
                Me("Size4Price3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1.5")>  _
        Public Property Size4Price4() As Single
            Get
                Return CType(Me("Size4Price4"),Single)
            End Get
            Set
                Me("Size4Price4") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property Size5Price1() As Single
            Get
                Return CType(Me("Size5Price1"),Single)
            End Get
            Set
                Me("Size5Price1") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property Size5Price2() As Single
            Get
                Return CType(Me("Size5Price2"),Single)
            End Get
            Set
                Me("Size5Price2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property Size5Price3() As Single
            Get
                Return CType(Me("Size5Price3"),Single)
            End Get
            Set
                Me("Size5Price3") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("3")>  _
        Public Property Size5Price4() As Single
            Get
                Return CType(Me("Size5Price4"),Single)
            End Get
            Set
                Me("Size5Price4") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\KioskAssets\6x4.png")>  _
        Public Property Size1Img() As String
            Get
                Return CType(Me("Size1Img"),String)
            End Get
            Set
                Me("Size1Img") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\KioskAssets\7x5.png")>  _
        Public Property Size2Img() As String
            Get
                Return CType(Me("Size2Img"),String)
            End Get
            Set
                Me("Size2Img") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\KioskAssets\8x6.png")>  _
        Public Property Size3Img() As String
            Get
                Return CType(Me("Size3Img"),String)
            End Get
            Set
                Me("Size3Img") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\KioskAssets\10x8.png")>  _
        Public Property Size4Img() As String
            Get
                Return CType(Me("Size4Img"),String)
            End Get
            Set
                Me("Size4Img") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\KioskAssets\10x12.png")>  _
        Public Property Size5Img() As String
            Get
                Return CType(Me("Size5Img"),String)
            End Get
            Set
                Me("Size5Img") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("D:")>  _
        Public Property StorageSD() As String
            Get
                Return CType(Me("StorageSD"),String)
            End Get
            Set
                Me("StorageSD") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("E:")>  _
        Public Property StorageXD() As String
            Get
                Return CType(Me("StorageXD"),String)
            End Get
            Set
                Me("StorageXD") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("F:")>  _
        Public Property StorageMS() As String
            Get
                Return CType(Me("StorageMS"),String)
            End Get
            Set
                Me("StorageMS") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("G:")>  _
        Public Property StorageCF() As String
            Get
                Return CType(Me("StorageCF"),String)
            End Get
            Set
                Me("StorageCF") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("H:")>  _
        Public Property StorageUSB() As String
            Get
                Return CType(Me("StorageUSB"),String)
            End Get
            Set
                Me("StorageUSB") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("I:")>  _
        Public Property StorageCD() As String
            Get
                Return CType(Me("StorageCD"),String)
            End Get
            Set
                Me("StorageCD") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("J:")>  _
        Public Property StorageiDevice() As String
            Get
                Return CType(Me("StorageiDevice"),String)
            End Get
            Set
                Me("StorageiDevice") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("C:\Orders")>  _
        Public Property StorageTarget() As String
            Get
                Return CType(Me("StorageTarget"),String)
            End Get
            Set
                Me("StorageTarget") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property Size1Channel() As String
            Get
                Return CType(Me("Size1Channel"),String)
            End Get
            Set
                Me("Size1Channel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("27")>  _
        Public Property Size2Channel() As String
            Get
                Return CType(Me("Size2Channel"),String)
            End Get
            Set
                Me("Size2Channel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("9")>  _
        Public Property Size3Channel() As String
            Get
                Return CType(Me("Size3Channel"),String)
            End Get
            Set
                Me("Size3Channel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("36")>  _
        Public Property Size4Channel() As String
            Get
                Return CType(Me("Size4Channel"),String)
            End Get
            Set
                Me("Size4Channel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("42")>  _
        Public Property Size5Channel() As String
            Get
                Return CType(Me("Size5Channel"),String)
            End Get
            Set
                Me("Size5Channel") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property UseGDIReceipt() As Boolean
            Get
                Return CType(Me("UseGDIReceipt"),Boolean)
            End Get
            Set
                Me("UseGDIReceipt") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property Use2K17() As Boolean
            Get
                Return CType(Me("Use2K17"),Boolean)
            End Get
            Set
                Me("Use2K17") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.MetroKiosk.My.MySettings
            Get
                Return Global.MetroKiosk.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
