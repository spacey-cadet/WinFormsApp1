Public Class Form2
    Inherits Form

    Private WithEvents OpenFileDialogButton As New Button()
    Private ReadOnly PictureBox1 As New PictureBox()
    Private ReadOnly OpenFileDialog1 As New OpenFileDialog()

    Dim SampleText As New TextBox()
    Dim SampleTextLabel As New Label()


    'fonts groupbox
    Dim fontsGrp As New GroupBox()
    'fonts checkboxes
    Dim Garamond As New CheckBox()
    Dim Tahoma As New CheckBox()
    Dim Magneto As New CheckBox()


    'font color group box
    Dim fontColorGrp As New GroupBox()
    'font color check boxes
    Dim Green As New CheckBox()
    Dim Blue As New CheckBox()
    Dim Red As New CheckBox()

    'font style froup box
    Dim fontStyleGrp As New GroupBox()
    'font stly check boxes
    Dim Bold As New CheckBox()
    Dim Italic As New CheckBox()
    Dim BoldlItalic As New CheckBox()

    Private Sub Form2_OnLoad() Handles MyBase.Load
        'set the Text of all the check boxes
        Tahoma.Text = "Tahome"
        Garamond.Text = "Garamond"
        Magneto.Text = "Magneto"

        Blue.Text = "Blue"
        Red.Text = " Red"
        Green.Text = "Green"

        Bold.Text = "Bold"
        Italic.Text = "Italic"
        BoldlItalic.Text = "Bold Italic"

        'add checkboxes to their group boxes
        fontsGrp.Controls.Add(Tahoma)
        fontsGrp.Controls.Add(Garamond)
        fontsGrp.Controls.Add(Magneto)

        fontColorGrp.Controls.Add(Blue)
        fontColorGrp.Controls.Add(Red)
        fontColorGrp.Controls.Add(Green)

        fontStyleGrp.Controls.Add(Italic)
        fontStyleGrp.Controls.Add(Bold)
        fontStyleGrp.Controls.Add(Bold)

        'add lable to sampletext
        SampleTextLabel.Text = "Sample Text"
        SampleText.Controls.Add(SampleTextLabel)

        'add all the controls to the form
        Me.Controls.Add(fontColorGrp)
        Me.Controls.Add(fontsGrp)
        Me.Controls.Add(fontStyleGrp)
        Me.Controls.Add(SampleText)


        For Each ctl As Control In fontColorGrp.Controls
            If TypeOf ctl Is CheckBox Then
                AddHandler CType(ctl, CheckBox).CheckedChanged, AddressOf fontColor_Change
            End If
        Next

        For Each ctl As Control In fontsGrp.Controls
            If TypeOf ctl Is CheckBox Then
                AddHandler CType(ctl, CheckBox).CheckedChanged, AddressOf font_Change
            End If
        Next

        For Each ctl As Control In fontStyleGrp.Controls
            If TypeOf ctl Is CheckBox Then
                AddHandler CType(ctl, CheckBox).CheckedChanged, AddressOf fontSyle_Change
            End If
        Next
    End Sub

    Private Sub OpenFileDialogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFileDialogButton.Click
        ' Show the Open File dialog. If the user clicks OK, load the
        ' picture that the user chose.
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Load(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub fontSyle_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim checkbox As CheckBox = CType(sender, CheckBox)
        If checkbox.Checked Then
            SampleText.Font = New Font(checkbox.Text, SampleText.Font.Size, SampleText.Font.Style)
        End If
    End Sub

    Private Sub font_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim checkbox As CheckBox = CType(sender, CheckBox)
        If checkbox.Checked Then
            Select Case checkbox.Text
                Case "Blue"
                    SampleText.ForeColor = Color.Blue
                Case "Green"
                    SampleText.ForeColor = Color.Green
                Case "Red"
                    SampleText.ForeColor = Color.Red
            End Select
        End If

    End Sub

    Private Sub fontColor_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim checkbox As CheckBox = CType(sender, CheckBox)
        If checkbox.Text Then
            Select Case checkbox.Text
                Case "Bold"
                    SampleText.Font = New Font(SampleText.Font, FontStyle.Bold)
                Case "Italic"
                    SampleText.Font = New Font(SampleText.Font, FontStyle.Italic)
                Case "Bold Italic"
                    SampleText.Font = New Font(SampleText.Font, FontStyle.Bold Or FontStyle.Italic)
            End Select
        End If
    End Sub

End Class