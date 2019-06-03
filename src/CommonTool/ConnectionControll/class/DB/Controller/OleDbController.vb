Imports System.Data.Common
Imports System.Data.OleDb

Namespace DB

    ''' <summary>
    ''' OleDb に対するレコード操作クラス
    ''' </summary>
    Public Class OleDbController
        Inherits ConnectionController

        ''' <summary>
        ''' 接続情報を指定してインスタンス生成
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="connection">接続情報</param>
        Friend Sub New(ByVal dbname As String, ByVal connection As OleDbConnection)
            MyBase.New(dbname, connection)
        End Sub

        ''' <summary>
        ''' 親クラスでレコード検索に使用するDbDataAdapterインスタンス生成
        ''' </summary>
        ''' <returns>OleDbDataAdapter</returns>
        Protected Overrides Function CreateDbDataAdapter() As DbDataAdapter
            Return New OleDbDataAdapter()
        End Function

        ''' <summary>
        ''' クエリを指定してレコードを検索する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>検索したレコード</returns>
        Public Function SelectRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As DataTable

            ' 親クラスで実行
            Return MyBase.SearchRecord(query, parameters)

        End Function

        ''' <summary>
        ''' クエリを指定してレコードを更新する
        ''' </summary>
        ''' <param name="query">クエリ</param>
        ''' <param name="parameters">パラメータ</param>
        ''' <returns>更新したレコード数</returns>
        Public Overloads Function UpdateRecord(ByVal query As String, Optional ByVal parameters As OleDbParameterCollection = Nothing) As Integer

            ' 親クラスで実行
            Return MyBase.UpdateRecord(query, parameters)

        End Function

    End Class

End Namespace
