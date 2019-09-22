Imports System.IO

Namespace FileUtil

    ''' <summary>
    ''' ファイルのチェック一覧
    ''' </summary>
    Friend Class FileChecker

        ''' <summary>
        ''' コンストラクタ(非推奨)
        ''' </summary>
        Private Sub New()
        End Sub

        ''' <summary>
        ''' ファイルの存在チェック
        ''' </summary>
        ''' <param name="filename">ファイル名</param>
        ''' <exception cref="FileNotFoundException"></exception>
        Friend Shared Sub ExistFile(ByVal filename As String)
            Try
                If Not File.Exists(filename) Then
                    Throw New FileNotFoundException(filename & "が存在しません")
                End If
            Catch ex As Exception
                Throw
            End Try
        End Sub

    End Class

End Namespace
