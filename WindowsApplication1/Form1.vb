Imports System.Text

Public Class Form1
    Private Declare Function GetPixel Lib "gdi32" (ByVal hdc As Long, ByVal x As Long, ByVal y As Long) As Long
    Dim rnd As New Random

    Function countPixels() As Integer
        Dim bmp As Bitmap = Image.FromFile(TextBox1.Text)

        ' Make a difference image.
        Dim w As Integer = bmp.Width ', bmp.Width)
        Dim h As Integer = bmp.Height ', bm2.Height)

        ' Create the difference image.
        Dim count As Integer = 0
        Dim blackPixel As Color

        For x As Integer = 0 To w - 1
            For y As Integer = 0 To h - 1
                blackPixel = bmp.GetPixel(x, y)

                If blackPixel.R = 0 AndAlso blackPixel.G = 0 AndAlso blackPixel.B = 0 Then
                    ' bmp.SetPixel(x, y, Color.Red) 'FromArgb(255, R, G, B))
                    'ListBox1.Items.Add("X :" & x & " , Y :" & y)
                    count += 1
                End If

            Next 'y
        Next 'x

        bmp.Dispose()
        Return count
    End Function
    Private Function GetColor(ByVal pic As PictureBox, ByVal X As Integer, ByVal Y As Integer) As Color

        If pic Is Nothing Then Return Nothing

        Using tmp As New Bitmap(pic.ClientSize.Width, pic.ClientSize.Height)

            Dim r As New Rectangle(0, 0, tmp.Width, tmp.Height)

            Using g As Graphics = Graphics.FromImage(tmp)
                g.DrawImage(pic.Image, r, r, GraphicsUnit.Pixel)
            End Using

            Return tmp.GetPixel(X, Y)

        End Using

    End Function

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


    '    picturebox1.location = New point(picturebox1.location.X + 1, picturebox1.location.y + 0)
    '     if picturebox1.location = (???,???) then
    '        Timer1.enable = False
    '    End If
    'End Sub

    Private Sub pixBox_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pixBox.MouseMove
        Label5.Text = "X : " & e.X.ToString
        Label6.Text = "Y : " & e.Y.ToString

        Dim B As New Bitmap(TextBox1.Text)
        B = pixBox.Image

        'x >>24
        'y >>13 

        Label7.Text = Math.Round((e.X.ToString / 50), 2) - 0.01
        Dim text() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}
        Label8.Text = text(Math.Round((e.Y.ToString / 50), 0))

        PictureBox2.BackColor = B.GetPixel(e.X.ToString, e.Y.ToString)
    End Sub
    Private Sub ig_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Label5.Text = "X : " & e.X.ToString
        Label6.Text = "Y : " & e.Y.ToString
        'Dim ig As PictureBox = DirectCast(sender, PictureBox)
        'Dim igi As PictureBox = DirectCast(sender, PictureBox)

        Dim B As New Bitmap(TextBox1.Text)
        B = ig.Image
        'x >>24
        'y >>13 

        Label7.Text = Math.Round((e.X.ToString / 50), 2) - 0.01
        Dim text() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}
        Label8.Text = text(Math.Round((e.Y.ToString / 50), 0))

        igi.BackColor = B.GetPixel(e.X.ToString, e.Y.ToString)
    End Sub
    Dim ig, igi As New PictureBox
    Dim frm As New Form
    Dim imcount As Integer = 0
    Private Sub pixBox_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pixBox.MouseDown
        imcount += 1
        ig.Name = "hh" & imcount
        ig.Location = New Point(10, 10)
        ig.Size = New Point(350, 450)
        ig.BackColor = Color.Black

        igi.Name = "hh1" & imcount
        igi.Location = New Point(400, 100)
        igi.Size = New Point(50, 50)
        igi.BackColor = Color.Red
        AddHandler ig.MouseMove, AddressOf ig_MouseMove
        Dim bmp As Bitmap = Image.FromFile(TextBox1.Text)

        ' Make a difference image.
        Dim w As Integer = bmp.Width ', bmp.Width)
        Dim h As Integer = bmp.Height ', bm2.Height)

        ' Create the difference image.
        Dim count As Integer = 0
        Dim blackPixel, Pixel As Color
        Dim j() As String = {"red", "green", "yellow", "blue"}

        For x As Integer = 0 To w - 1

            For y As Integer = 0 To h - 1
                blackPixel = bmp.GetPixel(x, y)

                If blackPixel.R = 0 AndAlso blackPixel.G = 0 AndAlso blackPixel.B = 0 Then
                    count += 1
                    'Dim R, G, B As Integer
                    Dim B As Integer

                    'R = rnd.Next(0, 225)
                    'G = rnd.Next(0, 225)
                    'B = rnd.Next(0, 225)


                    B = rnd.Next(0, 4)
                    If j(B) = "red" Then bmp.SetPixel(x, y, Color.Red) ': R.Text += 1
                    If j(B) = "green" Then bmp.SetPixel(x, y, Color.Green) ': G.Text += 1
                    If j(B) = "yellow" Then bmp.SetPixel(x, y, Color.Yellow) ' : Yc.Text += 1
                    If j(B) = "blue" Then bmp.SetPixel(x, y, Color.Blue) ': Bc.Text += 1 

                    ' bmp.SetPixel(x, y, Color.FromArgb(255, R, G, B))
                End If

            Next 'y
        Next 'x 
        'bmp.Dispose()





        ig.Image = bmp


        Label7.Text = Math.Round((e.X.ToString / 50), 2) - 0.01
        Dim text() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N"}
        Label8.Text = text(Math.Round((e.Y.ToString / 50), 0))


        frm.Name = text(Math.Round((e.Y.ToString / 50), 0)) & Math.Round((e.X.ToString / 50), 2) - 0.01
        frm.Text = text(Math.Round((e.Y.ToString / 50), 0)) & Math.Round((e.X.ToString / 50), 2) - 0.01
        frm.Size = New Point(500, 500)
        frm.Controls.Add(ig)

        frm.Controls.Add(igi)
        AddHandler frm.FormClosing, AddressOf Max_FormClosing
        frm.Show()


    End Sub
    Sub check(ByVal text As String)

    End Sub
    Private Sub Max_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        frm.Hide()
        frm.Parent = Nothing
        e.Cancel = True
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pixBox.Image = Image.FromFile(TextBox1.Text)
        TextBox2.Text = countPixels()


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim g As Graphics = Graphics.FromImage(pixBox.Image)
        ' g.Clear(Color.Transparent)

        ''Perform Drawing here

        pixBox.Image.Save(TextBox3.Text, System.Drawing.Imaging.ImageFormat.Tiff)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        pixBox.Image = Image.FromFile(TextBox1.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim bmp As Bitmap = Image.FromFile(TextBox1.Text)

        ' Make a difference image.
        Dim w As Integer = bmp.Width ', bmp.Width)
        Dim h As Integer = bmp.Height ', bm2.Height)

        ' Create the difference image.
        Dim count As Integer = 0
        Dim blackPixel, Pixel As Color
        Dim j() As String = {"red", "green", "yellow", "blue"}

        For x As Integer = 0 To w - 1

            For y As Integer = 0 To h - 1
                blackPixel = bmp.GetPixel(x, y)

                If blackPixel.R = 0 AndAlso blackPixel.G = 0 AndAlso blackPixel.B = 0 Then
                    count += 1
                    'Dim R, G, B As Integer
                    Dim B As Integer

                    'R = rnd.Next(0, 225)
                    'G = rnd.Next(0, 225)
                    'B = rnd.Next(0, 225)


                    B = rnd.Next(0, 4)
                    If j(B) = "red" Then bmp.SetPixel(x, y, Color.Red) ': R.Text += 1
                    If j(B) = "green" Then bmp.SetPixel(x, y, Color.Green) ': G.Text += 1
                    If j(B) = "yellow" Then bmp.SetPixel(x, y, Color.Yellow) ' : Yc.Text += 1
                    If j(B) = "blue" Then bmp.SetPixel(x, y, Color.Blue) ': Bc.Text += 1 

                    ' bmp.SetPixel(x, y, Color.FromArgb(255, R, G, B))
                End If

            Next 'y
        Next 'x 
        'bmp.Dispose()

        pixBox.Image = bmp
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim bmp As Bitmap = pixBox.Image

        ' Make a difference image.
        Dim w As Integer = bmp.Width ', bmp.Width)
        Dim h As Integer = bmp.Height ', bm2.Height)

        ' Create the difference image.
        Dim count As Integer = 0
        Dim Pixel As Color
        For x As Integer = 0 To w - 1
            For y As Integer = 0 To h - 1
                Pixel = bmp.GetPixel(x, y)
                If Pixel = Color.Yellow Then
                    Yc.Text += 1
                ElseIf Pixel = Color.Red Then
                    R.Text += 1
                ElseIf Pixel = Color.Green Then
                    G.Text += 1
                ElseIf Pixel = Color.Blue Then
                    Bc.Text += 1
                End If
            Next 'y
        Next 'x 
        'bmp.Dispose()
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form2.Show()

        Dim sb1 As New StringBuilder
        Dim sb2 As New StringBuilder
        Dim sb3 As New StringBuilder
        Dim sb4 As New StringBuilder
        Dim bmp As Bitmap = pixBox.Image
        Dim Col As Color
        For i = 1 To bmp.Width - 1
            For j = 1 To bmp.Height - 1
                Col = bmp.GetPixel(i, j)
                'sb1.Append(Color.R)
                'sb1.Append(" ")
                'sb2.Append(Color.G)
                'sb2.Append(" ")
                'sb3.Append(Color.B)
                'sb3.Append(" ")
                If Col.R = 255 And Col.G = 0 And Col.B = 0 Then  sb1.Append("@") : sb1.Append(" ")
                If Col.R = 0 And Col.G = 128 And Col.B = 0 Then sb2.Append("#") : sb2.Append(" ")
                If Col.R = 0 And Col.G = 0 And Col.B = 255 Then sb3.Append("-") : sb3.Append(" ")
                'Yellow
                If Col.R = 255 And Col.G = 255 And Col.B = 0 Then sb4.Append("+") : sb4.Append(" ")
            Next
            'sb1.AppendLine()
            'sb2.AppendLine()
            'sb3.AppendLine()
            'sb4.AppendLine()
        Next

        Form2.RichTextBox1.Text = sb1.ToString & sb2.ToString & sb3.ToString & sb4.ToString
    End Sub
End Class