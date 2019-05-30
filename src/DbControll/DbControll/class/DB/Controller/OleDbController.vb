﻿Imports System.Data.Common
Imports System.Data.OleDb

Namespace DB

    ''' <summary>
    ''' OleDb に対するレコード操作クラス
    ''' </summary>
    Public Class OleDbController
        Inherits DbController

        ''' <summary>
        ''' 接続情報を指定してインスタンス生成
        ''' </summary>
        ''' <param name="connection">接続情報</param>
        Friend Sub New(ByVal connection As OleDbConnection)
            MyBase.New(connection)
        End Sub

        ''' <summary>
        ''' 親クラスで検索に使用するインスタンス生成
        ''' </summary>
        ''' <returns>OleDbDataAdapter</returns>
        Protected Overrides Function NewDbDataAdapter() As DbDataAdapter
            Return New OleDbDataAdapter()
        End Function

        ''' <summary>
        ''' クエリを指定しレコードを検索する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>検索したレコード</returns>
        Public Function SelectRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As DataTable
            Dim command As OleDbCommand = New OleDbCommand

            ' 実行するクエリとパラメータを指定
            command.CommandText = query
            If parameters IsNot Nothing Then
                command.Parameters.Add(parameters)
            End If

            ' 親クラスで実行
            Return MyBase.SearchRecord(command)

        End Function

        ''' <summary>
        ''' クエリを指定しレコードを追加する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>追加したレコード数</returns>
        Public Function InsertRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer
            Return Me.UpdateData(query, parameters)
        End Function

        ''' <summary>
        ''' クエリを指定しレコードを削除する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>削除したレコード数</returns>
        Public Function DeleteRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer
            Return Me.UpdateData(query, parameters)
        End Function

        ''' <summary>
        ''' クエリを指定しレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Public Overloads Function UpdateRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer
            Return Me.UpdateData(query, parameters)
        End Function

        ''' <summary>
        ''' クエリを指定しレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Private Function UpdateData(ByVal query As String, ByVal parameters As OleDbParameterCollection) As Integer
            Dim command As OleDbCommand = New OleDbCommand

            ' 実行するクエリとパラメータを指定
            command.CommandText = query
            If parameters IsNot Nothing Then
                command.Parameters.Add(parameters)
            End If

            ' 親クラスで実行
            Return MyBase.UpdateRecord(command)

        End Function

    End Class

End Namespace
