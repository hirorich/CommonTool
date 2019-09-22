Imports CommonTool.FileIO.Const
Imports CommonTool.FileIO.Text

Namespace Csv

    ''' <summary>
    ''' CSVファイル書き込み部品
    ''' </summary>
    Friend Class CsvWriter

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
        ''' 上書きモードで書き込み先ファイルに文字列配列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        ''' <remarks>1行に出力</remarks>
        ''' <exception cref="Exception"></exception>
        Friend Sub WriteOver(ByVal data As String())
            Try

                ' 出力内容書き込み
                Dim writer As TextWriter = New TextWriter(Me.m_Filename)
                writer.WriteOver(JoinToLine(data))

            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 追記モードで書き込み先ファイルに文字列配列を書き込む
        ''' </summary>
        ''' <param name="data">書き込み内容</param>
        ''' <remarks>1行に出力</remarks>
        ''' <exception cref="Exception"></exception>
        Friend Sub WriteAppend(ByVal data As String())
            Try

                ' 出力内容書き込み
                Dim writer As TextWriter = New TextWriter(Me.m_Filename)
                writer.WriteAppend(JoinToLine(data))

            Catch ex As Exception
                Throw
            End Try
        End Sub

        ''' <summary>
        ''' 文字列配列を1行に連結
        ''' </summary>
        ''' <param name="data">連結対象文字列配列</param>
        ''' <returns>連結後文字列</returns>
        Friend Shared Function JoinToLine(ByVal data As String()) As String
            Try
                ' 1文字ごとにサニタイズ
                Dim objOutputList As List(Of String) = New List(Of String)
                For Each text As String In data
                    objOutputList.Add(Sanitize(text))
                Next

                ' カンマ区切りで連結
                JoinToLine = String.Join(SpecialCharacter.g_Comma, objOutputList)
            Catch ex As Exception
                Throw
            End Try
        End Function

        ''' <summary>
        ''' サニタイズ処理
        ''' </summary>
        ''' <param name="data">サニタイズ対象文字列</param>
        ''' <returns>サニタイズ後文字列</returns>
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

    End Class

End Namespace
