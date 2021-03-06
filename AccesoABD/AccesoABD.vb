﻿Imports System.Data.SqlClient

Public Class AccesoABD

    Private Shared conexion As New SqlConnection
    Private Shared comando As New SqlCommand

    Public Shared Function conectar() As String
        Try
            conexion.ConnectionString = “Server=tcp:hads21-2018.database.windows.net,1433;Initial Catalog=HADS21-TAREAS;Persist Security Info=False;User ID=jv21;Password=VeskoJulen21;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
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

    Public Shared Function iniciar_sesion(ByVal email As String, ByVal password As String) As String
        Dim st = "select pass, confirmado, tipo from Usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Dim reader As SqlDataReader = comando.ExecuteReader()
        If reader.Read Then
            Dim pass = reader.Item("pass")
            Dim confirmado = reader.Item("confirmado")
            Dim tipo = reader.Item("tipo")
            If pass = password Then
                If confirmado Then
                    If tipo.Equals("Profesor") Then
                        Return "Profesor" 'Caso en el que la contraseña es correcta y el usuario ha sido confirmado siendo el tipo Profesor
                    ElseIf tipo.Equals("Alumno") Then
                        Return "Alumno" 'Caso en el que la contraseña es correcta y el usuario ha sido confirmado siendo el tipo Alumno
                    ElseIf tipo.Equals("Admin") Then
                        Return "Admin"
                    End If
                Else
                    Return "Error1" 'Caso en el que la contraseña es correcta pero el usuario no ha sido confirmado
                End If
            End If
        End If
        Return "Error2" 'Contraseña incorrecta o no existe usuario
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
    Public Shared Function solicitar_cambio(ByVal email As String, ByVal clave As Integer) As Boolean
        Dim st = "select email from Usuarios where email='" & email & "'"
        comando = New SqlCommand(st, conexion)
        Dim reader As SqlDataReader = comando.ExecuteReader()
        If reader.Read Then
            Dim update = "update Usuarios set numconfir='" & clave & "' where email='" & email & "'"
            comando = New SqlCommand(update, conexion)
            Dim ret = comando.ExecuteNonQuery()
            If ret = 1 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Shared Function cambiar_password(ByVal email As String, ByVal clave As Integer, ByVal password As String) As Boolean
        If Not clave = 0 Then
            Dim st = "select numconfir from Usuarios where email='" & email & "'"
            comando = New SqlCommand(st, conexion)
            Dim reader As SqlDataReader = comando.ExecuteReader()
            If reader.Read Then
                Dim num = reader.Item("numconfir")
                If num.Equals(clave) Then
                    Dim update = "update Usuarios set pass='" & password & "', numconfir=0 where email='" & email & "'"
                    comando = New SqlCommand(update, conexion)
                    Dim ret = comando.ExecuteNonQuery()
                    If ret = 1 Then
                        Return True
                    End If
                End If
            End If
            Return False
        End If
        Return False
    End Function

    Public Shared Function obtener_adapter(ByVal queryString As String) As SqlDataAdapter
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(
            queryString, conexion)
        Return adapter
    End Function

    Public Shared Function obtener_media(ByVal asignatura As String) As Integer
        Dim query = "SELECT AVG([EstudiantesTareas].[HReales]) AS media From ([Asignaturas] INNER JOIN [TareasGenericas] ON [Asignaturas].[codigo]=[TareasGenericas].[CodAsig]) INNER JOIN [EstudiantesTareas] ON [TareasGenericas].[Codigo]=[EstudiantesTareas].[CodTarea] WHERE [Asignaturas].[codigo]='" & asignatura & "'"
        comando = New SqlCommand(query, conexion)
        Dim reader As SqlDataReader = comando.ExecuteReader()
        Dim media
        Try
            If reader.Read Then
                media = reader.Item("media")
            Else
                media = 0
            End If
            Return media
        Catch ex As Exception
            Return 0
        End Try

    End Function
End Class
