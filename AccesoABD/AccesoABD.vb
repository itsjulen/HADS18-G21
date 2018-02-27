Imports System.Data.SqlClient

Public Class AccesoABD

    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads21-2018.database.windows.net,1433;Initial Catalog=HADS21-TAREAS;Persist Security Info=False;User ID=jv21;Password=***;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            Return "ERROR DE CONEXIÓN: " + ex.Message
        End Try
        Return "CONEXION OK"
    End Function

    Public Shared Sub cerrarconexion()
        conexion.Close()
    End Sub

    Public Shared Function insertar_usuario(ByVal email As String, ByVal nombre As String, ByVal apellidos As String, ByVal numconfir As Integer, ByVal tipo As String, ByVal pass As String) As String
        Dim st = "insert into Usuarios (email, nombre, apellidos, numconfir, confirmado, tipo, pass) values ('" & email & "', '" & nombre & "', '" & apellidos & "', '" & numconfir & "', 'False', '" & tipo & "', '" & pass & "')"
        Dim numregs As Integer
        comando = New SqlCommand(st, conexion)
        Try
            numregs = comando.ExecuteNonQuery()
        Catch ex As Exception
            Return ex.Message
        End Try
        Return (CStr(numregs))
    End Function

    Public Shared Function iniciar_sesion(ByVal email As String, ByVal password As String) As Integer
        Dim st = "select pass, confirmado from Usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Dim reader As SqlDataReader = comando.ExecuteReader()
        If reader.Read Then
            Dim pass = reader.Item("pass")
            Dim confirmado = reader.Item("confirmado")
            If pass = password Then
                If confirmado Then
                    Return 0 'Caso en el que la contraseña es correcta y el usuario ha sido confirmado
                Else
                    Return 1 'Caso en el que la contraseña es correcta pero el usuario no ha sido confirmado
                End If
            End If
        End If
        Return 2 'Contraseña incorrecta o no existe usuario
    End Function

    Public Shared Function confirmar_usuario(ByVal email As String, ByVal num As Integer) As Boolean
        Dim st = "select numconfir from Usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Dim reader As SqlDataReader = comando.ExecuteReader()
        If reader.Read Then
            Dim numconfir = reader.Item("numconfir")
            If numconfir.Equals(num) Then
                Dim update = "update Usuarios set confirmado='True', numconfir='0' where email='" & email & "'"
                comando = New SqlCommand(update, conexion)
                Dim ret = comando.ExecuteNonQuery()
                If ret = 1 Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
End Class
