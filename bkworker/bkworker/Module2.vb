Module Module2

        Public Plink As New System.Diagnostics.Process()



        Public Function Plink_Start(ByVal Host As String, ByVal Username As String, ByVal Password As String, Optional ByVal Hidden As Boolean = True, Optional ByVal LocalPort As String = "3307", Optional ByVal RemoteHost As String = "localhost", Optional ByVal RemotePort As String = "3306") As Boolean

            Plink.StartInfo.FileName = Application.StartupPath & "\plink.exe"

            Plink.StartInfo.Arguments = "-ssh -l " & Username & " -pw " & Password & " -L " & LocalPort & ":" & RemoteHost & ":" & RemotePort & " -batch " & Host

            If Hidden = True Then

                Plink.StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            End If



            Try

                Plink.Start()

                Return True

            Catch ex As Exception

                Return False

            End Try

        End Function



        Public Sub Plink_Stop()

            Try

                If Plink.HasExited = False Then

                    Plink.Kill()

                End If

            Catch ex As Exception

            End Try

        End Sub

    End Module



'    'Start with Plink hidden using local port 3307 

'Plink_Start("example.com", "ssh_username", "ssh_password", true, "3307", "localhost", "3306") 



'    'Plink can be started visibly for debugging purposes 

'Plink_Start("example.com", "ssh_username", "ssh_password", false, "3307", "localhost", "3306") 
'End Module
