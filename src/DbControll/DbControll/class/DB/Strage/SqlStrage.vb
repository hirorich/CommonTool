Imports System.Data.SqlClient

Namespace DB

    ''' <summary>
    ''' SQL Server に対する接続情報保管クラス
    ''' </summary>
    Public Class SqlStrage
        Inherits DbStrage

        ''' <summary>
        ''' Singleton パターンのインスタンス
        ''' </summary>
        Private Shared instance As SqlStrage

        Private Sub New()
        End Sub

        ''' <summary>
        ''' インスタンスの生成
        ''' </summary>
        ''' <returns>インスタンス</returns>
        Public Shared Function CreateInstance() As SqlStrage
            If SqlStrage.instance Is Nothing Then
                SqlStrage.instance = New SqlStrage()
            End If
            Return SqlStrage.instance
        End Function

        ''' <summary>
        ''' 接続情報を追加
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <param name="connection">接続情報</param>
        ''' <returns>True:追加成功 /False:追加失敗</returns>
        Public Overloads Function Add(ByVal dbname As String, ByVal connection As SqlConnection) As Boolean
            Return MyBase.Add(dbname, connection)
        End Function

        ''' <summary>
        ''' 接続先を基にSQL Server に対するレコード操作クラスを取得
        ''' </summary>
        ''' <param name="dbname">接続先</param>
        ''' <returns>レコード操作クラス</returns>
        Public Overloads Function CreateDbController(ByVal dbname As String) As SqlController
            CreateDbController = TryCast(MyBase.CreateDbController(dbname), SqlController)
        End Function

    End Class

End Namespace
