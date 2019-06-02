﻿Imports System.Data.Common
Imports System.Data.SqlClient

Namespace DB

    ''' <summary>
    ''' SQL Server に対するレコード操作クラス
    ''' </summary>
    Public Class SqlController
        Inherits ConnectionController

        ''' <summary>
        ''' 接続情報を指定してインスタンス生成
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="connection">接続情報</param>
        Friend Sub New(ByVal dbname As String, ByVal connection As SqlConnection)
            MyBase.New(dbname, connection)
        End Sub

        ''' <summary>
        ''' 親クラスでレコード検索に使用するDbDataAdapterインスタンス生成
        ''' </summary>
        ''' <returns>SqlDataAdapter</returns>
        Protected Overrides Function CreateDbDataAdapter() As DbDataAdapter
            Return New SqlDataAdapter()
        End Function

        ''' <summary>
        ''' 親クラスでクエリ実行に使用するIDbCommandインスタンス生成
        ''' </summary>
        ''' <returns>SqlCommand</returns>
        Protected Overrides Function CreateIDbCommand() As IDbCommand
            Return New SqlCommand()
        End Function

        ''' <summary>
        ''' クエリを指定してレコードを検索する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>検索したレコード</returns>
        Public Function SelectRecord(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As DataTable

            ' 親クラスで実行
            Return MyBase.SearchRecord(query, parameters)

        End Function

        ''' <summary>
        ''' クエリを指定してレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Public Overloads Function UpdateRecord(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As Integer

            ' 親クラスで実行
            Return MyBase.UpdateRecord(query, parameters)

        End Function

    End Class

End Namespace
