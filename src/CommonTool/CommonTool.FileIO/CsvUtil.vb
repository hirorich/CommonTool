Imports CommonTool.FileIO.Csv
Imports CommonTool.FileIO.FileUtil

''' <summary>
''' CSVファイル出力共通部品
''' </summary>
Public Class CsvUtil

    ''' <summary>
    ''' コンストラクタ(非推奨)
    ''' </summary>
    Private Sub New()
    End Sub

    ''' <summary>
    ''' 上書きモードで書き込み先ファイルに文字列を書き込む
    ''' </summary>
    ''' <param name="filename">書き込み先ファイル</param>
    ''' <param name="data">書き込み内容</param>
    ''' <remarks>1行に出力</remarks>
    ''' <exception cref="Exception"></exception>
    Public Shared Sub WriteOver(ByVal filename As String, ByVal data As String)
        Try

            ' ファイルの存在チェック
            Call FileChecker.ExistFile(filename)

            ' 上書きモードで出力
            Dim objCsvWriter As CsvWriter = New CsvWriter(filename)
            Call objCsvWriter.WriteOver({data})

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 上書きモードで書き込み先ファイルに文字列配列を書き込む
    ''' </summary>
    ''' <param name="filename">書き込み先ファイル</param>
    ''' <param name="data">書き込み内容</param>
    ''' <remarks>1行に出力</remarks>
    ''' <exception cref="Exception"></exception>
    Public Shared Sub WriteOver(ByVal filename As String, ByVal data As String())
        Try

            ' ファイルの存在チェック
            Call FileChecker.ExistFile(filename)

            ' 上書きモードで出力
            Dim objCsvWriter As CsvWriter = New CsvWriter(filename)
            Call objCsvWriter.WriteOver(data)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 追記モードで書き込み先ファイルに文字列を書き込む
    ''' </summary>
    ''' <param name="filename">書き込み先ファイル</param>
    ''' <param name="data">書き込み内容</param>
    ''' <remarks>1行に出力</remarks>
    ''' <exception cref="Exception"></exception>
    Public Shared Sub WriteAppend(ByVal filename As String, ByVal data As String)
        Try

            ' ファイルの存在チェック
            Call FileChecker.ExistFile(filename)

            ' 追記モードで出力
            Dim objCsvWriter As CsvWriter = New CsvWriter(filename)
            Call objCsvWriter.WriteAppend({data})

        Catch ex As Exception
            Throw
        End Try
    End Sub

    ''' <summary>
    ''' 追記モードで書き込み先ファイルに文字列配列を書き込む
    ''' </summary>
    ''' <param name="filename">書き込み先ファイル</param>
    ''' <param name="data">書き込み内容</param>
    ''' <remarks>1行に出力</remarks>
    ''' <exception cref="Exception"></exception>
    Public Shared Sub WriteAppend(ByVal filename As String, ByVal data As String())
        Try

            ' ファイルの存在チェック
            Call FileChecker.ExistFile(filename)

            ' 追記モードで出力
            Dim objCsvWriter As CsvWriter = New CsvWriter(filename)
            Call objCsvWriter.WriteAppend(data)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
