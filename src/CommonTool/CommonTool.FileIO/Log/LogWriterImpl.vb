Imports CommonTool.FileIO.Const
Imports CommonTool.FileIO.Log.Const
Imports CommonTool.FileIO.Text

Namespace Log

    ''' <summary>
    ''' ログ出力実装クラス
    ''' </summary>
    ''' <remarks>出力オプションは無視する</remarks>
    Friend Class LogWriterImpl
        Implements ILogWriter

        ''' <summary>
        ''' 書き込み先ファイル
        ''' </summary>
        Private m_Filename As String

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        Friend Sub New()
            Me.m_Filename = "Log_" & Date.Now.ToString("yyyyMMdd") & ".log"
        End Sub

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象文字列</param>
        ''' <param name="optionArgs">出力オプション</param>
        ''' <remarks>出力オプションは無視する</remarks>
        Friend Sub WriteLog(ByVal data As String, ByVal Optional optionArgs As Collection = Nothing) Implements ILogWriter.WriteLog
            Try
                Call Me.WriteLog(data, LogLevel.g_INFO)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 例外ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象例外</param>
        ''' <param name="optionArgs">出力オプション</param>
        ''' <remarks>出力オプションは無視する</remarks>
        Friend Sub WriteLog(ByVal data As Exception, ByVal Optional optionArgs As Collection = Nothing) Implements ILogWriter.WriteLog
            Try
                Call Me.WriteLog(data.ToString(), LogLevel.g_ERROR)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象文字列</param>
        Private Sub WriteLog(ByVal data As String, ByVal level As String)
            Try

                ' 出力内容の整形
                Dim listOutput As List(Of String) = New List(Of String)
                listOutput.Add(level)                                          ' ログレベル
                listOutput.Add(Date.Now.ToString("yyyy/MM/dd hh:mm:ss.fff"))   ' 日時
                listOutput.Add(Environment.MachineName)                        ' 端末名
                listOutput.Add(Environment.UserName)                           ' ユーザ名
                listOutput.Add(Sanitize(data))                                   ' 出力対象文字列

                ' 出力内容書き込み
                Dim writer As TextWriter = New TextWriter(Me.m_Filename)
                writer.WriteAppend(String.Join(SpecialCharacter.g_Comma, listOutput))

            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' サニタイズ処理
        ''' </summary>
        ''' <param name="data"></param>
        ''' <returns></returns>
        Friend Shared Function Sanitize(ByVal data As String) As String
            Try

                ' ダブルクォートをサニタイズ
                Sanitize = SpecialCharacter.g_DoubleQuote &
                    data.Replace(SpecialCharacter.g_DoubleQuote, SpecialCharacter.g_DoubleQuote & SpecialCharacter.g_DoubleQuote) &
                    SpecialCharacter.g_DoubleQuote
            Catch ex As Exception
                Sanitize = String.Empty
            End Try
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
