'Karaoke Music Night app


Public Class frmKaraoke
    Private _decSong As Decimal = 2.99D
    Private _decHourlyRate As Decimal = 8.99D
    Private Sub frmKaraoke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'splash screen pauses in 5 seconds
        Threading.Thread.Sleep(5000)
        ClearForm()
    End Sub
    Private Function ValidateInput() As Boolean
        'validate Input
        Dim intNumber As Integer
        Dim blnValid As Boolean = False
        Try
            'convert to an integer value
            intNumber = Convert.ToInt32(txtValue.Text)
            If intNumber > 0D Then
                blnValid = True
                Return blnValid
            Else
                MsgBox("Please enter a number greater than 0", , "Error")
            End If
        Catch Exception As FormatException
            'case of symbols, letters,...
            MsgBox("Please enter a valid amount", , "Error")
        Catch Exception As SystemException
            'case of the rest
            MsgBox("Entry invalid. Please enter a number", , "Error")

        End Try
        txtValue.Focus()
        txtValue.Clear()
        Return blnValid
    End Function
    Private Function ComputeSongCost(ByVal intPass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intPass * _decSong
        Return decPassCost
    End Function
    Private Function ComputeRoomCost(ByVal intPass As Integer) As Decimal
        Dim decRoomCost As Decimal
        decRoomCost = intPass * _decHourlyRate
        Return decRoomCost
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        'Clear Form
        cboComboBox.SelectedIndex = -1
        lblOption.Visible = False
        txtValue.Visible = False
        btnTotalCost.Visible = False
        btnTotalCost.Visible = False
        btnClear.Visible = False
        lblResult.Visible = False
        txtValue.Clear()
    End Sub

    Private Sub btnTotalCost_Click(sender As Object, e As EventArgs) Handles btnTotalCost.Click
        Dim blnAmountIsValid As Boolean = False
        Dim intValue As Integer
        Dim decTotal As Decimal
        'A dunction procedure is called to validate the value entered
        blnAmountIsValid = ValidateInput()
        If blnAmountIsValid = True Then
            intValue = Convert.ToInt32(txtValue.Text)
            If cboComboBox.SelectedIndex = 0 Then
                decTotal = ComputeSongCost(intValue)
            Else
                decTotal = ComputeRoomCost(intValue)
            End If
            lblResult.Visible = True
            lblResult.Text = "Total Cost of Karaoke Night : " & decTotal.ToString("C")
        End If
    End Sub
    Private Sub cboComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboComboBox.SelectedIndexChanged
        If cboComboBox.SelectedIndex = 0 Then
            lblOption.Text = "Number of Karaoke Song"
            lblOption.Visible = True
            txtValue.Visible = True
            btnTotalCost.Visible = True
            btnClear.Visible = True
            txtValue.Focus()
        End If
        If cboComboBox.SelectedIndex = 1 Then
            lblOption.Text = "Hourly Rental of Karaoke Room"
            lblOption.Visible = True
            txtValue.Visible = True
            btnTotalCost.Visible = True
            btnClear.Visible = True
            txtValue.Focus()
        End If
    End Sub
End Class
