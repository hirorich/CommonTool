Imports System.Data.Common
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
        ''' <param name="connection">接続情報</param>
        Friend Sub New(ByVal connection As SqlConnection)
            MyBase.New(connection)
        End Sub

        ''' <summary>
        ''' 親クラスでレコード検索に使用するDbDataAdapterインスタンス生成
        ''' </summary>
        ''' <returns>SqlDataAdapter</returns>
        Protected Overrides Function CreateDbDataAdapter() As DbDataAdapter
            Return New SqlDataAdapter()
        End Function

        ''' <summary>
        ''' クエリを指定しレコードを検索する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>検索したレコード</returns>
        Public Function SelectRecord(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As DataTable
            Dim command As SqlCommand = New SqlCommand

            ' 実行するクエリとパラメータを指定
            command.CommandText = query
            If parameters IsNot Nothing Then
                command.Parameters.Add(parameters)
            End If

            ' 親クラスで実行
            Return MyBase.SearchRecord(command)

        End Function

        ''' <summary>
        ''' クエリを指定しレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Public Overloads Function UpdateRecord(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As Integer
            Dim command As SqlCommand = New SqlCommand

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
