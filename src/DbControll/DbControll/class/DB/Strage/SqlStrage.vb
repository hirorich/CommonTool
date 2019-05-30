Imports System.Data.SqlClient

Namespace DB

    Public Class SqlStrage
        Inherits DbStrage

        Private Shared instance As SqlStrage

        Private Sub New()
        End Sub

        Public Shared Function CreateInstance() As SqlStrage
            If SqlStrage.instance Is Nothing Then
                SqlStrage.instance = New SqlStrage()
            End If
            Return SqlStrage.instance
        End Function

        Public Function Add(ByVal dbname As String, ByVal connection As SqlConnection) As Boolean

        End Function

        Public Function CreateDbController(ByVal dbname As String) As SqlController

        End Function

    End Class

End Namespace
