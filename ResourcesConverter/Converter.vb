Public Class Converter
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dialog As New OpenFileDialog
        dialog.Title = "Open..."
        dialog.RestoreDirectory = True
        dialog.Filter = "Executable file|*.exe|All files|*.*"
        If dialog.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = dialog.FileName
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim dialog As New FolderBrowserDialog
        If dialog.ShowDialog() = DialogResult.OK Then
            TextBox2.Text = dialog.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim files As String() = IO.Directory.GetFiles(TextBox2.Text, "*.resources", IO.SearchOption.AllDirectories)
        For Each file In files
            Dim fileWithoutExt As String = IO.Path.GetFileNameWithoutExtension(file)
            ListBox1.Items.Add(file)
            Dim procinfo As New ProcessStartInfo
            procinfo.RedirectStandardOutput = False
            procinfo.UseShellExecute = False
            procinfo.Arguments = """" & file & """ """ & fileWithoutExt & ".resx"""
            procinfo.FileName = TextBox1.Text
            Dim proc As New Process
            proc.StartInfo = procinfo
            proc.Start()
            proc.WaitForExit()
        Next
        MsgBox("Executed conversion.", vbInformation)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class
