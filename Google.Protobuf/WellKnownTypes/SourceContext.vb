﻿#Region "Microsoft.VisualBasic::b283f9c018ed54f26bd27d2520634579, Google.Protobuf\WellKnownTypes\SourceContext.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Module SourceContextReflection
    ' 
    '         Properties: Descriptor
    ' 
    '         Constructor: (+1 Overloads) Sub New
    ' 
    '     Class SourceContext
    ' 
    '         Properties: Descriptor, DescriptorProp, FileName, Parser
    ' 
    '         Constructor: (+2 Overloads) Sub New
    ' 
    '         Function: CalculateSize, Clone, (+2 Overloads) Equals, GetHashCode, ToString
    ' 
    '         Sub: (+2 Overloads) MergeFrom, OnConstruction, WriteTo
    ' 
    ' 
    ' /********************************************************************************/

#End Region

' Generated by the protocol buffer compiler.  DO NOT EDIT!
' source: google/protobuf/source_context.proto
#Region "Designer generated code"

Imports Microsoft.VisualBasic.Language
Imports pbr = Google.Protobuf.Reflection

Namespace Google.Protobuf.WellKnownTypes

    ''' <summary>Holder for reflection information generated from google/protobuf/source_context.proto</summary>
    Public Partial Module SourceContextReflection

#Region "Descriptor"
        ''' <summary>File descriptor for google/protobuf/source_context.proto</summary>
        Public ReadOnly Property Descriptor As pbr.FileDescriptor
            Get
                Return descriptorField
            End Get
        End Property

        Private descriptorField As pbr.FileDescriptor

        Sub New()
            Dim descriptorData As Byte() = Global.System.Convert.FromBase64String(String.Concat("CiRnb29nbGUvcHJvdG9idWYvc291cmNlX2NvbnRleHQucHJvdG8SD2dvb2ds", "ZS5wcm90b2J1ZiIiCg1Tb3VyY2VDb250ZXh0EhEKCWZpbGVfbmFtZRgBIAEo", "CUJVChNjb20uZ29vZ2xlLnByb3RvYnVmQhJTb3VyY2VDb250ZXh0UHJvdG9Q", "AaABAaICA0dQQqoCHkdvb2dsZS5Qcm90b2J1Zi5XZWxsS25vd25UeXBlc2IG", "cHJvdG8z"))
            descriptorField = pbr.FileDescriptor.FromGeneratedCode(descriptorData, New pbr.FileDescriptor() {}, New pbr.GeneratedClrTypeInfo(Nothing, New pbr.GeneratedClrTypeInfo() {New pbr.GeneratedClrTypeInfo(GetType(Global.Google.Protobuf.WellKnownTypes.SourceContext), Global.Google.Protobuf.WellKnownTypes.SourceContext.Parser, {"FileName"}, Nothing, Nothing, Nothing)}))
        End Sub
#End Region

    End Module
#Region "Messages"
    ''' <summary>
    '''  `SourceContext` represents information about the source of a
    '''  protobuf element, like the file in which it is defined.
    ''' </summary>
    Public NotInheritable Partial Class SourceContext
        Implements IMessageType(Of SourceContext)

        Private Shared ReadOnly _parser As MessageParserType(Of SourceContext) = New MessageParserType(Of SourceContext)(Function() New SourceContext())

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property Parser As MessageParserType(Of SourceContext)
            Get
                Return _parser
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property DescriptorProp As pbr.MessageDescriptor
            Get
                Return Global.Google.Protobuf.WellKnownTypes.SourceContextReflection.Descriptor.MessageTypes(0)
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Private ReadOnly Property Descriptor As pbr.MessageDescriptor Implements IMessage.Descriptor
            Get
                Return DescriptorProp
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub New()
            OnConstruction()
        End Sub

        Partial Private Sub OnConstruction()
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub New(other As SourceContext)
            Me.New()
            fileName_ = other.fileName_
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function Clone() As SourceContext Implements IDeepCloneable(Of SourceContext).Clone
            Return New SourceContext(Me)
        End Function

        ''' <summary>Field number for the "file_name" field.</summary>
        Public Const FileNameFieldNumber As Integer = 1
        Private fileName_ As String = ""
        ''' <summary>
        '''  The path-qualified name of the .proto file that contained the associated
        '''  protobuf element.  For example: `"google/protobuf/source_context.proto"`.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property FileName As String
            Get
                Return fileName_
            End Get
            Set(value As String)
                fileName_ = CheckNotNull(value, "value")
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function Equals(other As Object) As Boolean
            Return Equals(TryCast(other, SourceContext))
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overloads Function Equals(other As SourceContext) As Boolean Implements IEquatable(Of SourceContext).Equals
            If ReferenceEquals(other, Nothing) Then
                Return False
            End If

            If ReferenceEquals(other, Me) Then
                Return True
            End If

            If Not Equals(FileName, other.FileName) Then Return False
            Return True
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function GetHashCode() As Integer
            Dim hash = 1
            If FileName.Length <> 0 Then hash = hash Xor FileName.GetHashCode()
            Return hash
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function ToString() As String
            Return JsonFormatter.ToDiagnosticString(Me)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub WriteTo(output As CodedOutputStream) Implements IMessage.WriteTo
            If FileName.Length <> 0 Then
                output.WriteRawTag(10)
                output.WriteString(FileName)
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function CalculateSize() As Integer Implements IMessage.CalculateSize
            Dim size = 0

            If FileName.Length <> 0 Then
                size += 1 + CodedOutputStream.ComputeStringSize(FileName)
            End If

            Return size
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(other As SourceContext) Implements IMessageType(Of SourceContext).MergeFrom
            If other Is Nothing Then
                Return
            End If

            If other.FileName.Length <> 0 Then
                FileName = other.FileName
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(input As CodedInputStream) Implements IMessage.MergeFrom
            Dim tag As New Value(Of UInteger)

            While ((tag = input.ReadTag())) <> 0

                Select Case tag.Value
                    Case 10
                        FileName = input.ReadString()

                    Case Else
                        input.SkipLastField()
                End Select
            End While
        End Sub
    End Class

#End Region

End Namespace
#End Region
