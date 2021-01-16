﻿Imports System.Runtime.CompilerServices
Imports LINQ.Language
Imports Microsoft.VisualBasic.Language

Module StackParser

    <Extension>
    Friend Function isKeywordFrom(t As Token) As Boolean
        Return isKeyword(t, "from")
    End Function

    <Extension>
    Friend Function isKeywordAggregate(t As Token) As Boolean
        Return isKeyword(t, "aggregate")
    End Function

    <Extension>
    Friend Function isKeyword(t As Token, text As String) As Boolean
        Return t.name = Tokens.keyword AndAlso t.text.TextEquals(text)
    End Function

    <Extension>
    Friend Function isKeywordSelect(t As Token) As Boolean
        Return isKeyword(t, "select")
    End Function

    Private Function GetParentPair(t As String) As String
        Select Case t
            Case "]" : Return "["
            Case "}" : Return "{"
            Case ")" : Return "("
            Case Else
                Throw New InvalidExpressionException
        End Select
    End Function

    <Extension>
    Public Function SplitByTopLevelStack(tokenList As IEnumerable(Of Token)) As IEnumerable(Of Token())
        Return tokenList _
            .DoSplitByTopLevelStack(Function(t)
                                        Return t.name = Tokens.keyword AndAlso Not t.text.TextEquals("as")
                                    End Function)
    End Function

    <Extension>
    Public Function SplitParameters(tokenList As IEnumerable(Of Token)) As IEnumerable(Of Token())
        Return tokenList _
            .DoSplitByTopLevelStack(Function(t)
                                        Return t.name = Tokens.Comma
                                    End Function)
    End Function

    <Extension>
    Public Iterator Function SplitOperators(tokenList As IEnumerable(Of Token)) As IEnumerable(Of Token())
        For Each block As Token() In tokenList _
            .DoSplitByTopLevelStack(Function(t)
                                        Return t.name = Tokens.Operator
                                    End Function)

            If block(Scan0).name = Tokens.Operator Then
                Yield {block(Scan0)}
                Yield block.Skip(1).ToArray
            Else
                Yield block
            End If
        Next
    End Function

    ''' <summary>
    ''' 根据最顶端的关键词以及括号进行栈片段的分割
    ''' </summary>
    ''' <param name="tokenList"></param>
    ''' <returns></returns>
    <Extension>
    Private Iterator Function DoSplitByTopLevelStack(tokenList As IEnumerable(Of Token), delimiter As Func(Of Token, Boolean)) As IEnumerable(Of Token())
        Dim block As New List(Of Token)
        Dim stack As New Stack(Of String)

        For Each item As Token In tokenList.Where(Function(t) t.name <> Tokens.Terminator AndAlso t.name <> Tokens.Comment)
            If delimiter(item) Then
                If stack.Count > 0 Then
                    block.Add(item)
                Else
                    If block > 0 Then
                        Yield block.PopAll
                    End If

                    block.Add(item)
                End If
            ElseIf item.name = Tokens.Open Then
                stack.Push(item.text)

                If stack.Count > 1 Then
                    block.Add(item)
                Else
                    If block > 0 Then
                        Yield block.PopAll
                    End If

                    block.Add(item)
                End If
            ElseIf item.name = Tokens.Close Then
                Dim parent As String = stack.Pop

                If parent <> GetParentPair(item.text) Then
                    Throw New SyntaxErrorException
                End If

                If stack.Count > 1 Then
                    block.Add(item)
                Else
                    block.Add(item)

                    If block > 0 Then
                        Yield block.PopAll
                    End If
                End If
            Else
                block.Add(item)
            End If
        Next

        If stack.Count > 0 Then
            Throw New SyntaxErrorException
        ElseIf block > 0 Then
            Yield block.PopAll
        End If
    End Function
End Module
