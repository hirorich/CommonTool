Imports System.Data.Common

Namespace DB

    Public MustInherit Class DbController
        Implements IDisposable

        Private connection As IDbConnection
        Private transaction As IDbTransaction

        Public ReadOnly Property State() As ConnectionState
            Get
                Return connection.State
            End Get
        End Property

        Protected Friend Sub New(ByVal connection As IDbConnection)
            Me.connection = connection
            Me.transaction = Nothing
        End Sub

        Protected MustOverride Function NewDbDataAdapter() As DbDataAdapter

        Public Function Open() As Boolean

        End Function

        Public Function Close() As Boolean

        End Function

        Public Function BeginTransaction() As Boolean

        End Function

        Public Function Commit() As Boolean

        End Function

        Public Function Rollback() As Boolean

        End Function

        Protected Function SearchRecord(ByVal command As IDbCommand) As DataTable

        End Function

        Protected Function UpdateRecord(ByVal command As IDbCommand) As Integer

        End Function

#Region "IDisposable Support"
        Private disposedValue As Boolean ' 重複する呼び出しを検出するには

        ' IDisposable
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: マネージド状態を破棄します (マネージド オブジェクト)。
                End If

                ' TODO: アンマネージド リソース (アンマネージド オブジェクト) を解放し、下の Finalize() をオーバーライドします。
                ' TODO: 大きなフィールドを null に設定します。
            End If
            disposedValue = True
        End Sub

        ' TODO: 上の Dispose(disposing As Boolean) にアンマネージド リソースを解放するコードが含まれる場合にのみ Finalize() をオーバーライドします。
        'Protected Overrides Sub Finalize()
        '    ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
        '    Dispose(False)
        '    MyBase.Finalize()
        'End Sub

        ' このコードは、破棄可能なパターンを正しく実装できるように Visual Basic によって追加されました。
        Public Sub Dispose() Implements IDisposable.Dispose
            ' このコードを変更しないでください。クリーンアップ コードを上の Dispose(disposing As Boolean) に記述します。
            Dispose(True)
            ' TODO: 上の Finalize() がオーバーライドされている場合は、次の行のコメントを解除してください。
            ' GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Namespace
