Namespace LOG

    ''' <summary>
    ''' ログ出力共通クラス
    ''' </summary>
    Public Class LogTool

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Private Shared writer As ILogTool

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Public Shared WriteOnly Property LogWriter As ILogTool
            Set(value As ILogTool)

                ' 実装クラスを既に保持する場合解放する
                If LogTool.writer IsNot Nothing Then
                    Call LogTool.writer.Dispose()
                End If

                ' 実装クラスを指定する
                LogTool.writer = value

            End Set
        End Property

        Private Sub New()
        End Sub

        ''' <summary>
        ''' message の内容をログ出力する
        ''' </summary>
        ''' <param name="message">出力メッセージ</param>
        Public Shared Sub WriteLog(ByVal message As String)
            Dim tool As ILogTool

            Try

                ' 実装クラスの指定有無によって使用するインスタンスを切り替える
                If LogTool.writer IsNot Nothing Then
                    tool = LogTool.writer
                Else
                    tool = DefaultLogToolImpl.CreateInstance()
                End If

                ' message の内容をログ出力する
                Call tool.WriteLog(message)

            Catch ex As Exception

                ' 例外は潰す

            End Try

        End Sub

        ''' <summary>
        ''' 発生した例外の内容をログに出力する
        ''' </summary>
        ''' <param name="e">Exception</param>
        Public Shared Sub WriteLog(ByVal e As Exception)

            ' メッセージ、スタックトレースをログに出力
            Call LogTool.WriteLog(e.ToString)

        End Sub

    End Class

End Namespace
