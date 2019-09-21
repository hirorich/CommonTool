Imports CommonTool.FileIO.WinAPI

''' <summary>
''' iniファイル読み書きクラス
''' </summary>
Public Class IniControl

    ''' <summary>
    ''' 読み書き対象ファイル
    ''' </summary>
    Private m_filename As String

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="filename">読み書き対象ファイル</param>
    Public Sub New(ByVal filename As String)
        Me.m_filename = filename
    End Sub

    ''' <summary>
    ''' セクション一覧読み込み
    ''' </summary>
    ''' <returns></returns>
    Public Function ReadSections() As String()
        Try

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' キー一覧読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <returns></returns>
    Public Function ReadKeys(ByVal section As String) As String()
        Try

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 値読み込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <param name="key">キー</param>
    ''' <returns></returns>
    Public Function ReadValue(ByVal section As String, ByVal key As String) As String
        Try

        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' 値書き込み
    ''' </summary>
    ''' <param name="section">セクション</param>
    ''' <param name="key">キー</param>
    ''' <param name="value">値</param>
    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As String)
        Try

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
