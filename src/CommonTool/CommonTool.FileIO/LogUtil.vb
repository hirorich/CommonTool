Imports CommonTool.FileIO.Log

''' <summary>
''' ログ出力共通部品
''' </summary>
Public Class LogUtil

    ''' <summary>
    ''' ログ出力実装クラス
    ''' </summary>
    Private Shared m_LogWriterImpl As ILogWriter

    ''' <summary>
    ''' コンストラクタ(非推奨)
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' ログ出力実装クラス
    ''' </summary>
    Public Shared WriteOnly Property LogWriterImpl() As ILogWriter
        Set(value As ILogWriter)
            If m_LogWriterImpl IsNot Nothing Then
                Call m_LogWriterImpl.Dispose()
            End If
            m_LogWriterImpl = value
        End Set
    End Property

    ''' <summary>
    ''' ログを出力する
    ''' </summary>
    ''' <param name="data">出力対象文字列</param>
    ''' <param name="optionArgs">出力オプション</param>
    Public Shared Sub WriteLog(ByVal data As String, ByVal Optional optionArgs As Collection = Nothing)
        If m_LogWriterImpl Is Nothing Then
            m_LogWriterImpl = New LogWriterImpl
        End If
        Call m_LogWriterImpl.WriteLog(data, optionArgs)
    End Sub

    ''' <summary>
    ''' ログを出力する
    ''' </summary>
    ''' <param name="data">出力対象例外</param>
    ''' <param name="optionArgs">出力オプション</param>
    Public Shared Sub WriteLog(ByVal data As Exception, ByVal Optional optionArgs As Collection = Nothing)
        If m_LogWriterImpl Is Nothing Then
            m_LogWriterImpl = New LogWriterImpl
        End If
        Call m_LogWriterImpl.WriteLog(data, optionArgs)
    End Sub

End Class
