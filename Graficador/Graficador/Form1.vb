Public Class Form1
    Public Sub New()
        InitializeComponent()
        Ejes()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim puntos As Integer
        Dim yreal, y, ymax, ymin, xrad, factory, xreal, x, xmax, xmin, factorx, salto As Double
        Dim tlbx As String

        tlbx = ListBox1.GetItemText(ListBox1.SelectedItem)
        If tlbx = "" Then
            MsgBox("Debe seleccionar la función que desea graficar")
            Return
        End If

        ymax = 0
        ymin = 0
        factory = 1
        xmax = 0
        xmin = 0
        factorx = 1
        puntos = 0
        salto = 1

        Ejes()

        'Limites del area a graficar
        ' -200 <= xreal <= 200
        ' -100 <= yreal <= 100
        'correccion al graficar
        ' x = 300 + xreal
        ' y = 150 - yreal

        For xreal = -200 To 200

            xrad = xreal * 3.1416 / 180
  
            Select Case tlbx
                Case "y=x"
                    yreal = xreal
                Case "y=x^2"
                    yreal = xreal * xreal
                Case "y=x^3"
                    yreal = xreal * xreal * xreal
                Case "y=sen(x)"
                    yreal = Math.Sin(xrad)
                Case "y=cos(x)"
                    yreal = Math.Cos(xrad)
                Case "y=tan(x)"
                    yreal = Math.Tan(xrad)
            End Select

            If (yreal >= -100 And yreal <= 100) Then
                'correccion y
                If (yreal > ymax) Then
                    ymax = yreal
                End If
                If (yreal < ymin) Then
                    ymin = yreal
                End If
                If (ymax < 0.1 * 100 And ymin > 0.1 * -100) Then
                    factory = 80 / ymax
                End If
                'correccion x
                If (xreal > xmax) Then
                    xmax = xreal
                End If
                If (xreal < xmin) Then
                    xmin = xreal
                End If
                If (xmax < 0.1 * 200 And xmin > 0.1 * -200) Then
                    factorx = 80 / xmax
                End If
                puntos = puntos + 1
            End If

        Next xreal

        If puntos < 200 Then
            salto = (xmax - xmin) / 200
        End If

        For xreal = xmin To xmax Step salto

            xrad = xreal * 3.1416 / 180

            Select Case tlbx
                Case "y=x"
                    yreal = xreal
                Case "y=x^2"
                    yreal = xreal * xreal
                Case "y=x^3"
                    yreal = xreal * xreal * xreal
                Case "y=sen(x)"
                    yreal = Math.Sin(xrad)
                Case "y=cos(x)"
                    yreal = Math.Cos(xrad)
                Case "y=tan(x)"
                    yreal = Math.Tan(xrad)
            End Select

            If (yreal >= -100 And yreal <= 100) Then
                'correccion
                y = 150 - yreal * factory
                x = 300 + xreal * factorx
                Escribe(x, y, 1)
            End If
        Next xreal
        'MsgBox(factorx)
    End Sub

    Private Function Escribe(ByVal x As Integer, y As Integer, w As Integer) As Integer
        Dim lb As New Label

        lb.Text = ""
        lb.MaximumSize = New Size(w, w)
        lb.Location = New Point(x, y)
        lb.BackColor = Color.Black
        GroupBox1.Controls.Add(lb)

    End Function
    Private Function EscribeTxt(ByVal x As Integer, y As Integer, t As String) As Integer
        Dim lb As New Label

        lb.Text = t
        lb.AutoSize = True
        lb.Location = New Point(x, y)
        GroupBox1.Controls.Add(lb)

    End Function
    Private Function Ejes()
        Dim var As Integer

        GroupBox1.Controls.Clear()
        'dibujar ejes x,y
        For var = 100 To 500
            'eje x
            Escribe(var, 150, 2)
        Next var
        For var = 50 To 250
            'eje y
            Escribe(300, var, 2)
        Next var

        EscribeTxt(510, 145, "X")
        EscribeTxt(295, 30, "Y")

    End Function


End Class




