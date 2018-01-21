Imports System.Data.SqlClient
Public Class Form1
    Dim sa As String
    Dim cmd As SqlCommand
    Dim dt As SqlDataReader


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) _
                         Handles BackgroundWorker1.DoWork
        ' Do some time-consuming work on this thread.

        'Call RoomBilling()

        Call testsync()


    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
 Handles BackgroundWorker1.RunWorkerCompleted
        NotifyIcon1.BalloonTipText = "All Routine Completed"
        NotifyIcon1.ShowBalloonTip(500)
        System.Threading.Thread.Sleep(100000)


    End Sub
    Sub testsync()

        NotifyIcon1.BalloonTipText = "synchronizing inventory as "
        NotifyIcon1.ShowBalloonTip(500)
        Try
            con.Open()

            sa = "INSERT INTO OPENQUERY(MYSQL, 'SELECT * FROM test') SELECT [id], [name], [title] FROM test WHERE NOT EXISTS (SELECT * FROM OPENQUERY(MYSQL,'select id as idem from test') WHERE idem = id)"
            cmd = New SqlCommand(sa, con)
            dt = cmd.ExecuteReader

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try


    End Sub
End Class
