Imports CommonTool.FileIO

Namespace TestCase

    ''' <summary>
    ''' ケース：ログ出力部品テスト
    ''' </summary>
    Public Class Case1
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try
                Call LogUtil.WriteLog("LogTest")
                Call LogUtil.WriteLog(New Exception("例外"))

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

End Namespace
