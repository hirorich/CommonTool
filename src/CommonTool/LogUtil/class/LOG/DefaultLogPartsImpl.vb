Namespace LOG

    ''' <summary>
    ''' ログ出力実装クラス(Default)
    ''' </summary>
    Friend Class DefaultLogPartsImpl
        Implements ILogParts

        ''' <summary>
        ''' Singleton パターンのインスタンス
        ''' </summary>
        Private Shared instance As DefaultLogPartsImpl

        Private Sub New()
        End Sub

        ''' <summary>
        ''' インスタンスの生成
        ''' </summary>
        ''' <returns>インスタンス</returns>
        Friend Shared Function CreateInstance() As DefaultLogPartsImpl
            If DefaultLogPartsImpl.instance Is Nothing Then
                DefaultLogPartsImpl.instance = New DefaultLogPartsImpl()
            End If
            Return DefaultLogPartsImpl.instance
        End Function

        ''' <summary>
        ''' message の内容をログ出力する
        ''' </summary>
        ''' <param name="message">出力メッセージ</param>
        ''' <param name="parameters">パラメータ</param>
        Public Sub WriteLog(message As String, Optional ByVal parameters As List(Of Object) = Nothing) Implements ILogParts.WriteLog
            Throw New NotImplementedException()
        End Sub

        ''' <summary>
        ''' 発生した例外の内容をログに出力する
        ''' </summary>
        ''' <param name="e">Exception</param>
        ''' <param name="parameters">パラメータ</param>
        Public Sub WriteLog(ByVal e As Exception, Optional ByVal parameters As List(Of Object) = Nothing) Implements ILogParts.WriteLog
            Call Me.WriteLog(e.ToString())
        End Sub

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
