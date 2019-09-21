Imports CommonTool.FileIO

Namespace TestCase

    ''' <summary>
    ''' ケース：INI値書き込みテスト
    ''' </summary>
    Public Class Case3
        Implements ICase

        ''' <summary>
        ''' テスト実行
        ''' </summary>
        ''' <returns></returns>
        Public Function Execute() As Boolean Implements ICase.Execute
            Try
                Dim section As String = String.Empty
                Dim key As String = String.Empty
                Dim value As String = String.Empty

                Dim control As IniControl = New IniControl("..\..\INI\Test.ini")

                Try
                    section = "Section6"
                    key = "key1"
                    value = "AfterValue1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Before: Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                    Call control.WriteValue(section, key, value)
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "After : Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section6"
                    key = "key3"
                    value = "AfterValue3"
                    Call control.WriteValue(section, key, value)
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "After : Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Try
                    section = "Section7"
                    key = "key1"
                    value = "AfterValue7-1"
                    Call control.WriteValue(section, key, value)
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "After : Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try



                Try
                    control = New IniControl("..\..\INI\Nothing.ini")
                    section = "Section6"
                    key = "key1"
                    value = "AfterValue1"
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "Before: Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                    Call control.WriteValue(section, key, value)
                    Form1.txtTestResult.Text = Form1.txtTestResult.Text & vbCrLf &
                        "After : Section:" & section & ", Key:" & key & ", Value:" & control.ReadValue(section, key)
                Catch ex As Exception
                    Call LogUtil.WriteLog(ex)
                End Try

                Return True
            Catch ex As Exception
                Throw
            End Try
        End Function
    End Class

End Namespace
