Imports System.Data.OleDb

Namespace DB

    Public Class OleDbStrage
        Inherits DbStrage

        Private Shared instance As OleDbStrage

        Private Sub New()
        End Sub

        Public Shared Function CreateInstance() As OleDbStrage
            If OleDbStrage.instance Is Nothing Then
                OleDbStrage.instance = New OleDbStrage()
            End If
            Return OleDbStrage.instance
        End Function

        Public Function Add(ByVal dbname As String, ByVal connection As OleDbConnection) As Boolean

        End Function

        Public Function CreateDbController(ByVal dbname As String) As OleDbController

        End Function

    End Class

End Namespace
