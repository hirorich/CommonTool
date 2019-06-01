Namespace LOG

    ''' <summary>
    ''' ログ出力インタフェース
    ''' </summary>
    Public Interface ILogTool
        Inherits IDisposable

        ''' <summary>
        ''' message の内容をログ出力する
        ''' </summary>
        ''' <param name="message">出力メッセージ</param>
        Sub WriteLog(ByVal message As String)

    End Interface

End Namespace
