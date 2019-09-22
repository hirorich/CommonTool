Imports CommonTool.FileIO
Imports CommonTool.Test.TestCase

Namespace TestCase.FileIO

    ''' <summary>
    ''' ケース：INIセクション一覧読み込みテスト
    ''' </summary>
    Public Class Case7
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try

                Call CsvUtil.WriteAppend("Test1.csv", "Test1")
                Call CsvUtil.WriteAppend("Test1.csv", {"Test1-1", "Test1-2"})

                Call CsvUtil.WriteAppend("Test2.csv", {"Test2-1", "Test2-2"})
                Call CsvUtil.WriteAppend("Test2.csv", "Test2")

                Call CsvUtil.WriteOver("Test3.csv", "Test3")
                Call CsvUtil.WriteAppend("Test3.csv", {"Test3-1", "Test3-2"})

                Call CsvUtil.WriteOver("Test4.csv", {"Test4-1", "Test4-2"})
                Call CsvUtil.WriteAppend("Test4.csv", "Test4")

                Call CsvUtil.WriteOver("Test5.csv", "Test5")
                Call CsvUtil.WriteAppend("Test5.csv", {"Test5-1", "Test5-2"})
                Call CsvUtil.WriteOver("Test5.csv", "Test5-3")

                Call CsvUtil.WriteOver("Test6.csv", {"Test6-1", "Test6-2"})
                Call CsvUtil.WriteAppend("Test6.csv", "Test6")
                Call CsvUtil.WriteOver("Test6.csv", {"Test6-3", "Test6-4"})

                Call CsvUtil.WriteOver("Test7.csv", """Test7-1")
                Call CsvUtil.WriteAppend("Test7.csv", "Test7-2""")
                Call CsvUtil.WriteAppend("Test7.csv", {"Test""7-3", "Test7""-4"})

                Call CsvUtil.WriteOver("Test8.csv", {"""Test8""-1", "Test8-2"""})

            Catch ex As Exception
                Call LogUtil.WriteLog(ex)
            End Try

            Return True
        End Function
    End Class

End Namespace
