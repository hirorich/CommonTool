Namespace Text

    ''' <summary>
    ''' テキストファイル書き込み部品
    ''' </summary>
    Friend Class TextWriter

        ''' <summary>
        ''' 書き込み先ファイル
        ''' </summary>
        Private m_Filename As String

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <param name="filename">書き込み先ファイル</param>
        Friend Sub New(ByVal filename As String)
            Me.m_Filename = filename
        End Sub

        ''' <summary>
        ''' 上書きモードで書き込み先ファイルに文字列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        Friend Sub WriteOver(ByVal data As String)
            Try
                Call Me.Write({data}, False)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 上書きモードで書き込み先ファイルに文字列配列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        Friend Sub WriteOver(ByVal data As String())
            Try
                Call Me.Write(data, False)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 追記モードで書き込み先ファイルに文字列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        Friend Sub WriteAppend(ByVal data As String)
            Try
                Call Me.Write({data}, True)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 追記モードで書き込み先ファイルに文字列配列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        Friend Sub WriteAppend(ByVal data As String())
            Try
                Call Me.Write(data, True)
            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 書き込み先ファイルに文字列配列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        ''' <param name="append">True:追記モード/False:上書きモード</param>
        Private Sub Write(ByVal data As String(), ByVal append As Boolean)
            Try

            Catch ex As Exception
                Throw
            End Try
        End Sub

    End Class

End Namespace
