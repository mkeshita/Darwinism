﻿Imports System.Text
Imports Microsoft.VisualBasic.ComponentModel
Imports Microsoft.VisualBasic.ComputingServices.TaskHost
Imports Microsoft.VisualBasic.Serialization.JsonContract
Imports RQL.StorageTek

''' <summary>
''' Repository database
''' </summary>
Public Class Repository : Implements ISaveHandle

    ''' <summary>
    ''' {lower_case.url, type_info}
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Models As Dictionary(Of String, EntityProvider)

    Public Function GetRepository(url As String) As IEnumerable
        Dim api As EntityProvider = Models(url.ToLower)
        Return api.GetRepository
    End Function

    Public Function LoadFile(url As String) As Repository
        Return LoadJsonFile(Of Repository)(url)
    End Function

    Public Function LoadDefault() As Repository
        Return LoadFile(DefaultFile)
    End Function

    Public Shared ReadOnly Property DefaultFile As String =
        App.ProductSharedDir & "/RQL.Provider.json"

    Private Function ISaveHandle_Save(Optional Path As String = "", Optional encoding As Encoding = Nothing) As Boolean Implements ISaveHandle.Save
        If String.IsNullOrEmpty(Path) Then
            Path = DefaultFile
        End If
        Return Me.GetJson.SaveTo(Path, encoding)
    End Function

    Public Function Save(Optional Path As String = "", Optional encoding As Encodings = Encodings.UTF8) As Boolean Implements ISaveHandle.Save
        Return ISaveHandle_Save(Path, encoding.GetEncodings)
    End Function
End Class

