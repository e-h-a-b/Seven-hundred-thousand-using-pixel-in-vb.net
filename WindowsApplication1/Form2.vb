Public Class Form2

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Form2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' RichTextBox1.Size = Me.Size
    End Sub

    Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Static rex As New System.Text.RegularExpressions.Regex("@", System.Text.RegularExpressions.RegexOptions.Compiled Or System.Text.RegularExpressions.RegexOptions.Multiline)

        Form1.R.Text = (rex.Matches(RichTextBox1.Text).Count / 2).ToString()

        Static rex1 As New System.Text.RegularExpressions.Regex("#", System.Text.RegularExpressions.RegexOptions.Compiled Or System.Text.RegularExpressions.RegexOptions.Multiline)

        Form1.G.Text = (rex1.Matches(RichTextBox1.Text).Count / 2).ToString()

        'Static rex2 As New System.Text.RegularExpressions.Regex("*", System.Text.RegularExpressions.RegexOptions.Compiled Or System.Text.RegularExpressions.RegexOptions.Multiline)

        'Form1.Bc.Text = (rex2.Matches(RichTextBox1.Text).Count / 2).ToString()

        Static rex3 As New System.Text.RegularExpressions.Regex("$", System.Text.RegularExpressions.RegexOptions.Compiled Or System.Text.RegularExpressions.RegexOptions.Multiline)

        Form1.Yc.Text = (rex3.Matches(RichTextBox1.Text).Count / 2).ToString()
    End Sub
End Class