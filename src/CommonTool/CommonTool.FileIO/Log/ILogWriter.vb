Namespace Log

    ''' <summary>
    ''' ログ出力インタフェース
    ''' </summary>
    Public Interface ILogWriter
        Inherits IDisposable

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象文字列</param>
        ''' <param name="optionArgs">出力オプション</param>
        Sub WriteLog(ByVal data As String, ByVal Optional optionArgs As Collection = Nothing)

        ''' <summary>
        ''' ログを出力する
        ''' </summary>
        ''' <param name="data">出力対象例外</param>
        ''' <param name="optionArgs">出力オプション</param>
        Sub WriteLog(ByVal data As Exception, ByVal Optional optionArgs As Collection = Nothing)

    End Interface

End Namespace
