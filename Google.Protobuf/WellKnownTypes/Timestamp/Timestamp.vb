﻿#Region "Microsoft.VisualBasic::2227ba9aabe8b2233d0314f2bb8328cd, Google.Protobuf\WellKnownTypes\Timestamp\Timestamp.vb"

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

    '     Class Timestamp
    ' 
    '         Properties: Descriptor, DescriptorProp, Nanos, Parser, Seconds
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
' source: google/protobuf/timestamp.proto
#Region "Designer generated code"

Imports Microsoft.VisualBasic.Language
Imports pbr = Google.Protobuf.Reflection

Namespace Google.Protobuf.WellKnownTypes

#Region "Messages"
    ''' <summary>
    '''  A Timestamp represents a point in time independent of any time zone
    '''  or calendar, represented as seconds and fractions of seconds at
    '''  nanosecond resolution in UTC Epoch time. It is encoded using the
    '''  Proleptic Gregorian Calendar which extends the Gregorian calendar
    '''  backwards to year one. It is encoded assuming all minutes are 60
    '''  seconds long, i.e. leap seconds are "smeared" so that no leap second
    '''  table is needed for interpretation. Range is from
    '''  0001-01-01T00:00:00Z to 9999-12-31T23:59:59.999999999Z.
    '''  By restricting to that range, we ensure that we can convert to
    '''  and from  RFC 3339 date strings.
    '''  See [https://www.ietf.org/rfc/rfc3339.txt](https://www.ietf.org/rfc/rfc3339.txt).
    '''
    '''  Example 1: Compute Timestamp from POSIX `time()`.
    '''
    '''      Timestamp timestamp;
    '''      timestamp.set_seconds(time(NULL));
    '''      timestamp.set_nanos(0);
    '''
    '''  Example 2: Compute Timestamp from POSIX `gettimeofday()`.
    '''
    '''      struct timeval tv;
    '''      gettimeofday(&amp;tv, NULL);
    '''
    '''      Timestamp timestamp;
    '''      timestamp.set_seconds(tv.tv_sec);
    '''      timestamp.set_nanos(tv.tv_usec * 1000);
    '''
    '''  Example 3: Compute Timestamp from Win32 `GetSystemTimeAsFileTime()`.
    '''
    '''      FILETIME ft;
    '''      GetSystemTimeAsFileTime(&amp;ft);
    '''      UINT64 ticks = (((UINT64)ft.dwHighDateTime) &lt;&lt; 32) | ft.dwLowDateTime;
    '''
    '''      // A Windows tick is 100 nanoseconds. Windows epoch 1601-01-01T00:00:00Z
    '''      // is 11644473600 seconds before Unix epoch 1970-01-01T00:00:00Z.
    '''      Timestamp timestamp;
    '''      timestamp.set_seconds((INT64) ((ticks / 10000000) - 11644473600LL));
    '''      timestamp.set_nanos((INT32) ((ticks % 10000000) * 100));
    '''
    '''  Example 4: Compute Timestamp from Java `System.currentTimeMillis()`.
    '''
    '''      long millis = System.currentTimeMillis();
    '''
    '''      Timestamp timestamp = Timestamp.newBuilder().setSeconds(millis / 1000)
    '''          .setNanos((int) ((millis % 1000) * 1000000)).build();
    '''
    '''  Example 5: Compute Timestamp from current time in Python.
    '''
    '''      now = time.time()
    '''      seconds = int(now)
    '''      nanos = int((now - seconds) * 10**9)
    '''      timestamp = Timestamp(seconds=seconds, nanos=nanos)
    ''' </summary>
    Public NotInheritable Partial Class Timestamp
        Implements IMessageType(Of Timestamp)

        Private Shared ReadOnly _parser As MessageParserType(Of Timestamp) = New MessageParserType(Of Timestamp)(Function() New Timestamp())

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property Parser As MessageParserType(Of Timestamp)
            Get
                Return _parser
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Shared ReadOnly Property DescriptorProp As pbr.MessageDescriptor
            Get
                Return Global.Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor.MessageTypes(0)
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
        Public Sub New(other As Timestamp)
            Me.New()
            seconds_ = other.seconds_
            nanos_ = other.nanos_
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function Clone() As Timestamp Implements IDeepCloneable(Of Timestamp).Clone
            Return New Timestamp(Me)
        End Function

        ''' <summary>Field number for the "seconds" field.</summary>
        Public Const SecondsFieldNumber As Integer = 1
        Private seconds_ As Long
        ''' <summary>
        '''  Represents seconds of UTC time since Unix epoch
        '''  1970-01-01T00:00:00Z. Must be from from 0001-01-01T00:00:00Z to
        '''  9999-12-31T23:59:59Z inclusive.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property Seconds As Long
            Get
                Return seconds_
            End Get
            Set(value As Long)
                seconds_ = value
            End Set
        End Property

        ''' <summary>Field number for the "nanos" field.</summary>
        Public Const NanosFieldNumber As Integer = 2
        Private nanos_ As Integer
        ''' <summary>
        '''  Non-negative fractions of a second at nanosecond resolution. Negative
        '''  second values with fractions must still have non-negative nanos values
        '''  that count forward in time. Must be from 0 to 999,999,999
        '''  inclusive.
        ''' </summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Property Nanos As Integer
            Get
                Return nanos_
            End Get
            Set(value As Integer)
                nanos_ = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function Equals(other As Object) As Boolean
            Return Equals(TryCast(other, Timestamp))
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overloads Function Equals(other As Timestamp) As Boolean Implements IEquatable(Of Timestamp).Equals
            If ReferenceEquals(other, Nothing) Then
                Return False
            End If

            If ReferenceEquals(other, Me) Then
                Return True
            End If

            If Seconds <> other.Seconds Then Return False
            If Nanos <> other.Nanos Then Return False
            Return True
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function GetHashCode() As Integer
            Dim hash = 1
            If Seconds <> 0L Then hash = hash Xor Seconds.GetHashCode()
            If Nanos <> 0 Then hash = hash Xor Nanos.GetHashCode()
            Return hash
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Overrides Function ToString() As String
            Return JsonFormatter.ToDiagnosticString(Me)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub WriteTo(output As CodedOutputStream) Implements IMessage.WriteTo
            If Seconds <> 0L Then
                output.WriteRawTag(8)
                output.WriteInt64(Seconds)
            End If

            If Nanos <> 0 Then
                output.WriteRawTag(16)
                output.WriteInt32(Nanos)
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Function CalculateSize() As Integer Implements IMessage.CalculateSize
            Dim size = 0

            If Seconds <> 0L Then
                size += 1 + CodedOutputStream.ComputeInt64Size(Seconds)
            End If

            If Nanos <> 0 Then
                size += 1 + CodedOutputStream.ComputeInt32Size(Nanos)
            End If

            Return size
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(other As Timestamp) Implements IMessageType(Of Timestamp).MergeFrom
            If other Is Nothing Then
                Return
            End If

            If other.Seconds <> 0L Then
                Seconds = other.Seconds
            End If

            If other.Nanos <> 0 Then
                Nanos = other.Nanos
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute>
        Public Sub MergeFrom(input As CodedInputStream) Implements IMessage.MergeFrom
            Dim tag As New Value(Of UInteger)

            While ((tag = input.ReadTag())) <> 0

                Select Case tag.Value
                    Case 8
                        Seconds = input.ReadInt64()

                    Case 16
                        Nanos = input.ReadInt32()

                    Case Else
                        input.SkipLastField()
                End Select
            End While
        End Sub
    End Class

#End Region

End Namespace
#End Region
