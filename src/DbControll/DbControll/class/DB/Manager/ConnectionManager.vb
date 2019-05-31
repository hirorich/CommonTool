Namespace DB

    Public MustInherit Class ConnectionManager
        Implements IDisposable

        Private dbcontrollers As Dictionary(Of String, ConnectionController)

        Protected Friend Sub New()
            dbcontrollers = New Dictionary(Of String, ConnectionController)
        End Sub

        Protected Function Add(ByVal dbname As String, ByVal connection As IDbConnection) As Boolean

        End Function

        Public Function Remove(ByVal dbname As String) As Boolean

        End Function

        Public Function Exists(ByVal dbname As String) As Boolean

        End Function

        Protected Function CreateDbController(ByVal dbname As String) As ConnectionController

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
