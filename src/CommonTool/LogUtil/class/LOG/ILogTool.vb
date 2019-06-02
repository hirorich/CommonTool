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
        ''' <param name="parameters">パラメータ</param>
        Sub WriteLog(ByVal message As String, Optional ByVal parameters As List(Of Object) = Nothing)

    End Interface

End Namespace
