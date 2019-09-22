Imports CommonTool.Test.TestCase
Imports CommonTool.FileIO
Imports CommonTool.Test.TestCase.FileIO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.cmbTestCase.Items.Add("Case1")
        Me.cmbTestCase.Items.Add("Case2")
        Me.cmbTestCase.Items.Add("Case3")
        Me.cmbTestCase.Items.Add("Case4")
        Me.cmbTestCase.Items.Add("Case5")
        Me.cmbTestCase.Items.Add("Case6")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Me.txtTestResult.Text = String.Empty
    End Sub

    Private Sub btnExeTest_Click(sender As Object, e As EventArgs) Handles btnExeTest.Click
        Try
            Dim testcase As ICase = Nothing

            Select Case Me.cmbTestCase.SelectedItem.ToString()
                Case "Case1"
                    testcase = New Case1
                Case "Case2"
                    testcase = New Case2
                Case "Case3"
                    testcase = New Case3
                Case "Case4"
                    testcase = New Case4
                Case "Case5"
                    testcase = New Case5
                Case "Case6"
                    testcase = New Case6
                Case Else
                    Throw New Exception("未作成のケースです")
            End Select

            Call testcase.Execute()

        Catch ex As Exception
            Call LogUtil.WriteLog(ex)
        End Try
    End Sub
End Class
