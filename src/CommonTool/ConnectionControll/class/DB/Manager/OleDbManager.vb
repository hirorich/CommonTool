Imports System.Data.OleDb

Namespace DB

    ''' <summary>
    ''' OleDb に対する接続情報管理クラス
    ''' </summary>
    Public Class OleDbManager
        Inherits ConnectionManager

        ''' <summary>
        ''' Singleton パターンのインスタンス
        ''' </summary>
        Private Shared instance As OleDbManager

        Private Sub New()
        End Sub

        ''' <summary>
        ''' インスタンスの生成
        ''' </summary>
        ''' <returns>インスタンス</returns>
        Public Shared Function CreateInstance() As OleDbManager
            If OleDbManager.instance Is Nothing Then
                OleDbManager.instance = New OleDbManager()
            End If
            Return OleDbManager.instance
        End Function

        ''' <summary>
        ''' 接続情報を追加
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="connection">接続情報</param>
        ''' <returns>True:成功 / False:失敗</returns>
        Public Overloads Function Add(ByVal dbname As String, ByVal connection As OleDbConnection) As Boolean
            Return MyBase.Add(dbname, connection)
        End Function

        ''' <summary>
        ''' 接続先を基にOleDb に対するレコード操作クラスを取得
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <returns>レコード操作クラス</returns>
        Public Overloads Function CreateDbController(ByVal dbname As String) As OleDbController
            CreateDbController = TryCast(MyBase.CreateDbController(dbname), OleDbController)
        End Function

    End Class

End Namespace
