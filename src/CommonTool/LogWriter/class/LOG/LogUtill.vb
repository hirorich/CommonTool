Namespace LOG

    ''' <summary>
    ''' ログ出力共通クラス
    ''' </summary>
    Public Class LogUtill

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Private Shared writer As ILogUtill

        ''' <summary>
        ''' ログ出力実装クラス
        ''' </summary>
        Public Shared WriteOnly Property LogWriter As ILogUtill
            Set(value As ILogUtill)

                ' 実装クラスを既に保持する場合解放する
                If LogUtill.writer IsNot Nothing Then
                    Call LogUtill.writer.Dispose()
                End If

                ' 実装クラスを指定する
                LogUtill.writer = value

            End Set
        End Property

        Private Sub New()
        End Sub

        ''' <summary>
        ''' message の内容をログ出力する
        ''' </summary>
        ''' <param name="message">出力メッセージ</param>
        Public Shared Sub WriteLog(ByVal message As String)
            Dim tool As ILogUtill

            ' 実装クラスの指定有無によって使用するインスタンスを切り替える
            If LogUtill.writer IsNot Nothing Then
                tool = LogUtill.writer
            Else
                tool = DefaultLogUtillImpl.CreateInstance()
            End If

            ' message の内容をログ出力する
            Call tool.WriteLog(message)

        End Sub

        ''' <summary>
        ''' 発生した例外の内容をログに出力する
        ''' </summary>
        ''' <param name="e">Exception</param>
        Public Shared Sub WriteLog(ByVal e As Exception)

            ' メッセージ、スタックトレースをログに出力
            Call LogUtill.WriteLog(e.ToString)

        End Sub

    End Class

End Namespace
