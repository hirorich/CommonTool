Namespace Log

    ''' <summary>
    ''' ログ出力実装クラス
    ''' </summary>
    Friend Class LogWriterImpl
        Implements ILogWriter

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象文字列</param>
        ''' <param name="optionArgs">出力オプション</param>
        Friend Sub WriteLog(data As String, Optional optionArgs As Collection = Nothing) Implements ILogWriter.WriteLog
            Throw New NotImplementedException()

            ' 出力先ファイルを指定

            ' 出力内容の整形

            ' 出力内容書き込み

        End Sub

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象例外</param>
        ''' <param name="optionArgs">出力オプション</param>
        Friend Sub WriteLog(data As Exception, Optional optionArgs As Collection = Nothing) Implements ILogWriter.WriteLog
            Call Me.WriteLog(data.ToString(), optionArgs)
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
