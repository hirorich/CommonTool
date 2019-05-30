Imports System.Data.Common
Imports System.Data.SqlClient

Namespace DB

    Public Class SqlController
        Inherits DbController

        Friend Sub New(ByVal connection As SqlConnection)
            MyBase.New(connection)
        End Sub

        Protected Overrides Function NewDbDataAdapter() As DbDataAdapter
            Return New SqlDataAdapter()
        End Function

        Public Function SelectData(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As DataTable

        End Function

        Public Function InsertData(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As Integer

        End Function

        Public Function DeleteData(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As Integer

        End Function

        Public Function UpdateData(ByVal query As String, Optional ByVal parameters As SqlParameterCollection = Nothing) As Integer

        End Function

    End Class

End Namespace
