﻿#Region "Microsoft.VisualBasic::e94be86c97798ea0d4158954c7dad3f9, ..\sciBASIC.ComputingServices\LINQ\LINQ\LDM\Parser\ParserAPI\Extensions.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
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

#End Region

Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.Linq.LDM.Statements.TokenIcer
Imports Microsoft.VisualBasic.Scripting.TokenIcer

Namespace LDM.Parser

    Module Extensions

        Public ReadOnly Property Primitive As Tokens = Tokens.String
        Public ReadOnly Property OpenParens As Tokens = Tokens.LPair
        Public ReadOnly Property CloseParens As Tokens = Tokens.RPair
        Public ReadOnly Property Comma As Tokens = Tokens.ParamDeli
        Public ReadOnly Property Dot As Tokens = Tokens.CallFunc

        ''' <summary>
        ''' Current tokens is a operator?
        ''' </summary>
        ''' <param name="token"></param>
        ''' <returns></returns>
        <Extension> Public Function IsOperator(token As Tokens) As Boolean
            Select Case token
                Case Statements.TokenIcer.Tokens.Slash,
                     Statements.TokenIcer.Tokens.Plus,
                     Statements.TokenIcer.Tokens.Or,
                     Statements.TokenIcer.Tokens.Not,
                     Statements.TokenIcer.Tokens.Minus,
                     Statements.TokenIcer.Tokens.Is,
                     Statements.TokenIcer.Tokens.Equals,
                     Statements.TokenIcer.Tokens.And,
                     Tokens.GT,
                     Tokens.GT_EQ,
                     Tokens.LT,
                     Tokens.LT_EQ,
                     Tokens.Mod,
                     Tokens.ModSlash,
                     Tokens.Shift

                    Return True
                Case Else
                    Return False
            End Select
        End Function

        ''' <summary>
        ''' 将变量引用替换为标识符类型
        ''' </summary>
        ''' <param name="source"></param>
        ''' <param name="name"></param>
        ''' <returns></returns>
        ''' 
        <Extension>
        Public Function Replace(source As Token(Of Tokens)(), name As String) As Token(Of Tokens)()
            For Each x As Token(Of Tokens) In source
                If x.Type = Tokens.varRef Then
                    x.TokenName = Tokens.Identifier
                    x.TokenValue = name
                End If
            Next
            Return source
        End Function
    End Module
End Namespace
