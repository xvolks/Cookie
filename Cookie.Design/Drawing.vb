Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Friend Module Helpers
    Private TSM As SizeF

    Public Enum MouseState As Byte
        None = 0
        Over = 1
        Down = 2
    End Enum

    Public Function MiddlePoint(G As Graphics, TargetText As String, TargetFont As Font, Rect As Rectangle) As Point
        TSM = G.MeasureString(TargetText, TargetFont)
        Return New Point(CInt(Rect.Width/2 - TSM.Width/2), CInt(Rect.Height/2 - TSM.Height/2))
    End Function

    Public Sub CenterString(G As Graphics, T As String, F As Font, C As Color, R As Rectangle)
        Dim TS As SizeF = G.MeasureString(T, F)

        Using B As New SolidBrush(C)
            G.DrawString(T, F, B, New Point(R.X + R.Width/2 - (TS.Width/2), R.Y + R.Height/2 - (TS.Height/2) - 1))
        End Using
    End Sub
End Module

Public Class BTextBox
    Inherits Control

    Private G As Graphics
    Private WithEvents T As TextBox

    Private AnimatingT As Thread
    Private AnimatingT2 As Thread

    Private ReadOnly RGB() As Integer = {70, 70, 70}

    Private Block As Boolean

    Public Shadows Property Text As String
        Get
            Return T.Text
        End Get
        Set
            MyBase.Text = value
            T.Text = value
            Invalidate()
        End Set
    End Property

    Public Property UseSystemPasswordChar As Boolean
        Get
            Return T.UseSystemPasswordChar
        End Get
        Set
            T.UseSystemPasswordChar = value
            Invalidate()
        End Set
    End Property

    Public Property SelectionStart As Integer
        Get
            Return T.SelectionStart
        End Get
        Set
            T.SelectionStart = Value
            T.Invalidate()
        End Set
    End Property

    Public Property MultiLine As Boolean
        Get
            Return T.Multiline
        End Get
        Set
            T.Multiline = value
            Size = New Size(T.Width + 2, T.Height + 2)
            Invalidate()
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return T.ReadOnly
        End Get
        Set
            T.ReadOnly = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True

        T = New TextBox With {
            .BorderStyle = BorderStyle.None,
            .ForeColor = Color.FromArgb(200, 200, 200),
            .BackColor = Color.FromArgb(55, 55, 58),
            .Location = New Point(6, 4),
            .Multiline = False}


        Controls.Add(T)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Color.FromArgb(55, 55, 58))

        Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        MyBase.OnPaint(e)
    End Sub

    Private Sub TEnter() Handles T.Enter

        If Not Block Then
            AnimatingT = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            AnimatingT.Start()
        End If
    End Sub

    Private Sub TLeave() Handles T.Leave
        AnimatingT2 = New Thread(AddressOf UndoAnimation) With {
            .IsBackground = True}
        AnimatingT2.Start()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        If MultiLine Then
            T.Size = New Size(Width - 7, Height - 7)
            Invalidate()
        Else
            T.Size = New Size(Width - 8, T.Height - 2)
            Size = New Size(Width, T.Height + 9)
        End If
        MyBase.OnResize(e)
    End Sub

    Private Sub TTextChanged() Handles T.TextChanged
        MyBase.OnTextChanged(EventArgs.Empty)
    End Sub

    Private Sub DoAnimation()


        While RGB(2) < 204 AndAlso Not Block

            RGB(1) += 1
            RGB(2) += 2

            Invalidate()
            Thread.Sleep(5)

        End While
    End Sub

    Private Sub UndoAnimation()

        Block = True

        While RGB(2) > 70

            RGB(1) -= 1
            RGB(2) -= 2

            Invalidate()
            Thread.Sleep(5)

        End While

        Block = False
    End Sub

    Private Sub TKeyDown(sender As Object, e As KeyEventArgs) Handles T.KeyDown
        OnKeyDown(e)
    End Sub
End Class

Public Class BRichTextBox
    Inherits Control

    Private G As Graphics
    Private WithEvents T As RichTextBox

    Public Property SelectionColor As Color
        Get
            Return T.SelectionColor
        End Get
        Set
            T.SelectionColor = Value
            T.Invalidate()
        End Set
    End Property

    Public Property SelectedText As String
        Get
            Return T.SelectedText
        End Get
        Set
            If Value IsNot "" Then
                T.SelectedText = Value
                T.Invalidate()
            End If
        End Set
    End Property

    Public Property SelectionStart As Integer
        Get
            Return T.SelectionStart
        End Get
        Set
            T.SelectionStart = value
            T.Invalidate()
        End Set
    End Property

    Public Property SelectionLength As Integer
        Get
            Return T.SelectionLength
        End Get
        Set
            T.SelectionLength = value
            T.Invalidate()
        End Set
    End Property

    Public Sub ScrollToCaret()
        T.ScrollToCaret()
    End Sub

    Public Shadows Property Text As String
        Get
            Return T.Text
        End Get
        Set
            MyBase.Text = value
            T.Text = value
            Invalidate()
        End Set
    End Property

    Public Property MultiLine As Boolean
        Get
            Return T.Multiline
        End Get
        Set
            T.Multiline = value
            Size = New Size(T.Width + 2, T.Height + 2)
            Invalidate()
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return T.ReadOnly
        End Get
        Set
            T.ReadOnly = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True

        T = New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .ForeColor = Color.FromArgb(200, 200, 200),
            .BackColor = Color.FromArgb(40, 40, 43),
            .Location = New Point(3, 4),
            .Multiline = True}


        Controls.Add(T)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Color.FromArgb(40, 40, 43))

        Using Border As New Pen(Color.FromArgb(48, 48, 48))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        If MultiLine Then
            T.Size = New Size(Width - 6, Height - 7)
            Invalidate()
        Else
            T.Size = New Size(Width - 2, T.Height - 2)
            Size = New Size(Width, T.Height + 3)
        End If
        MyBase.OnResize(e)
    End Sub

    Private Sub TTextChanged() Handles T.TextChanged
        MyBase.OnTextChanged(EventArgs.Empty)
    End Sub
End Class

Public Class BProgress
    Inherits ProgressBar

    Private _DisplayText As String
    Private _ProgressColor As Color = Color.FromArgb(0, 122, 204)

    Public Property Shadow As Boolean

    Public Property ProgressColor As Color
        Get
            Return _ProgressColor
        End Get
        Set
            _ProgressColor = value
            Invalidate()
        End Set
    End Property


    Public Property DisplayText As String
        Get
            Return _DisplayText
        End Get
        Set
            _DisplayText = value
            Invalidate()
        End Set
    End Property

    Private G As Graphics

    Sub New()
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint,
                 True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        MyBase.OnPaint(e)

        G.Clear(Color.FromArgb(37, 37, 40))

        Using Border As New Pen(Color.FromArgb(35, 35, 38))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Background As New SolidBrush(ProgressColor)
            G.FillRectangle(Background, New Rectangle(0, 0, CInt(Value/Maximum*Width - 1), Height - 1))
        End Using

        Using Font As New Font("Segoe UI", 8), ShadowBrush As New SolidBrush(Color.FromArgb(60, 60, 60))

            If Shadow Then
                G.DrawString(DisplayText, Font, ShadowBrush,
                             MiddlePoint(G, DisplayText, Font, New Rectangle(2, 2, Width + 2, Height + 2)))
            End If

            G.DrawString(DisplayText, Font, Brushes.White,
                         MiddlePoint(G, DisplayText, Font, New Rectangle(0, 0, Width, Height)))

        End Using
    End Sub
End Class

Public Class BCheckBox
    Inherits CheckBox

    Private G As Graphics
    Private State As MouseState

    Private AnimatingT As Thread
    Private AnimatingT2 As Thread

    Private ReadOnly RGB() As Integer = {70, 70, 70}

    Private Block As Boolean

    Public Property Radio As Boolean

    Private ReadOnly _
        CheckedIcon As String =
            "iVBORw0KGgoAAAANSUhEUgAAAAsAAAAKCAMAAABVLlSxAAAASFBMVEUlJSYuLi8oKCmlpaXx8fGioqJoaGjOzs8+Pj/k5OTu7u5LS0zIyMiBgYKFhYXo6OhUVFWVlZW7u7t+fn7h4eE5OTlfX1+YmJn8uq7eAAAAA3RSTlMAAAD6dsTeAAAACXBIWXMAAABIAAAASABGyWs+AAAAO0lEQVQI12NgwAKYWVhhTDYWdkYok4OTixvCYGDiYeEFM/n4BQRZhCDywiz8XCKiDDAOixjcPGFxDCsASakBdDYGvzAAAAAldEVYdGRhdGU6Y3JlYXRlADIwMTYtMTItMTRUMTI6MDM6MjktMDY6MDB4J65tAAAAJXRFWHRkYXRlOm1vZGlmeQAyMDE2LTEyLTE0VDEyOjAzOjI5LTA2OjAwCXoW0QAAAABJRU5ErkJggg=="

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint,
                 True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics
        G.InterpolationMode = InterpolationMode.HighQualityBicubic

        G.Clear(BackColor)

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, 16, 16))
        End Using

        Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
            G.DrawRectangle(Border, New Rectangle(0, 0, 16, 16))
        End Using

        Using Fore As New SolidBrush(ForeColor)
            G.DrawString(Text, Font, Fore, New Point(22, 0))
        End Using

        If Checked Then

            Using Mark As Image = Image.FromStream(New MemoryStream(Convert.FromBase64String(CheckedIcon)))
                G.DrawImage(Mark, New Point(2, 3))
            End Using

        End If
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)

        If Not Block Then
            AnimatingT = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            AnimatingT.Start()
        End If

        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        AnimatingT2 = New Thread(AddressOf UndoAnimation) With {
            .IsBackground = True}
        AnimatingT2.Start()

        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        If Radio Then
            For Each C As bCheckBox In Parent.Controls.OfType (Of bCheckBox)
                C.Checked = False
            Next
        End If

        MyBase.OnMouseUp(e)
    End Sub

    Private Sub DoAnimation()


        While RGB(2) < 204 AndAlso Not Block

            RGB(1) += 1
            RGB(2) += 2

            Invalidate()
            Thread.Sleep(4)

        End While
    End Sub

    Private Sub UndoAnimation()

        Block = True

        While RGB(2) > 70

            RGB(1) -= 1
            RGB(2) -= 2

            Invalidate()
            Thread.Sleep(4)

        End While

        Block = False
    End Sub
End Class

Public Class BForm
    Inherits ContainerControl

    Private G As Graphics
    Private Down As Boolean
    Private MousePoint As New Point

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 10)
        ForeColor = Color.FromArgb(180, 180, 180)
    End Sub

    Protected Overrides Sub OnCreateControl()
        Dock = DockStyle.Fill
        ParentForm.FormBorderStyle = FormBorderStyle.None
        BackColor = Color.FromArgb(45, 45, 48)
        MyBase.OnCreateControl()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        Down = False
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If Down = True Then
            ParentForm.Location = MousePosition - MousePoint
        End If
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        If e.Y <= 32 AndAlso e.Button = MouseButtons.Left Then
            Down = True
            MousePoint = New Point(e.Location)
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, 32))
        End Using

        Using Line As New Pen(Color.FromArgb(43, 43, 46))
            G.DrawLine(Line, 0, 32, Width - 1, 32)
        End Using

        G.DrawIcon(FindForm.Icon, New Rectangle(8, 8, 16, 16))

        Using Fore As New SolidBrush(ForeColor)
            G.DrawString(Text, Font, Fore, New Point(28, 7))
        End Using

        Using Border As New Pen(Color.FromArgb(35, 35, 38))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        MyBase.OnPaint(e)
    End Sub
End Class

Public Class BButton
    Inherits Button

    Private G As Graphics

    Private AnimatingT As Thread
    Private AnimatingT2 As Thread

    Private ReadOnly RGB() As Integer = {42, 42, 45}

    Private Block As Boolean

    Public Property DisplayImage As Image

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        ForeColor = Color.FromArgb(200, 200, 200)
        SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer,
                 True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(BackColor)

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Border As New Pen(Color.FromArgb(RGB(0), RGB(1), RGB(2)))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Using Fore As New SolidBrush(ForeColor)

            If IsNothing(DisplayImage) Then
                G.DrawString(Text, Font, Fore, MiddlePoint(G, Text, Font, New Rectangle(0, 0, Width - 1, Height - 1)))
            Else
                G.DrawImage(DisplayImage, New Rectangle(Width/2 - 6, 6, 12, 12))
            End If

        End Using
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)

        If Not Block Then
            AnimatingT = New Thread(AddressOf DoAnimation) With {
                .IsBackground = True}
            AnimatingT.Start()
        End If

        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        AnimatingT2 = New Thread(AddressOf UndoAnimation) With {
            .IsBackground = True}
        AnimatingT2.Start()

        MyBase.OnMouseLeave(e)
    End Sub

    Private Sub DoAnimation()


        While RGB(2) < 204 AndAlso Not Block

            RGB(1) += 1
            RGB(2) += 2

            Invalidate()
            Thread.Sleep(5)

        End While
    End Sub

    Private Sub UndoAnimation()

        Block = True

        While RGB(2) > 45

            RGB(1) -= 1
            RGB(2) -= 2

            Invalidate()
            Thread.Sleep(5)

        End While

        Block = False
    End Sub
End Class

Public Class Renderer
    Inherits ToolStripRenderer

    Private G As Graphics

    Public Event PaintMenuBackground(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintMenuBorder(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintMenuImageMargin(sender As Object, e As ToolStripRenderEventArgs)
    Public Event PaintItemCheck(sender As Object, e As ToolStripItemImageRenderEventArgs)
    Public Event PaintItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs)
    Public Event PaintItemText(sender As Object, e As ToolStripItemTextRenderEventArgs)
    Public Event PaintItemBackground(sender As Object, e As ToolStripItemRenderEventArgs)
    Public Event PaintItemArrow(sender As Object, e As ToolStripArrowRenderEventArgs)
    Public Event PaintSeparator(sender As Object, e As ToolStripSeparatorRenderEventArgs)

    Protected Overrides Sub OnRenderToolStripBackground(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuBackground(Me, e)
    End Sub

    Protected Overrides Sub OnRenderImageMargin(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuImageMargin(Me, e)
    End Sub

    Protected Overrides Sub OnRenderToolStripBorder(e As ToolStripRenderEventArgs)
        RaiseEvent PaintMenuBorder(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemCheck(e As ToolStripItemImageRenderEventArgs)
        RaiseEvent PaintItemCheck(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemImage(e As ToolStripItemImageRenderEventArgs)
        RaiseEvent PaintItemImage(Me, e)
    End Sub

    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        RaiseEvent PaintItemText(Me, e)
    End Sub

    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        RaiseEvent PaintItemBackground(Me, e)
    End Sub

    Protected Overrides Sub OnRenderArrow(e As ToolStripArrowRenderEventArgs)
        RaiseEvent PaintItemArrow(Me, e)
    End Sub

    Protected Overrides Sub OnRenderSeparator(e As ToolStripSeparatorRenderEventArgs)
        RaiseEvent PaintSeparator(Me, e)
    End Sub
End Class

Public Class BContextMenuStrip
    Inherits ContextMenuStrip

    Private G As Graphics
    Private Rect As Rectangle

    Sub New()
        Font = New Font("Segoe UI", 8)
        ForeColor = Color.FromArgb(200, 200, 200)
        Dim Renderer As New Renderer()
        AddHandler Renderer.PaintMenuBackground, AddressOf Renderer_PaintMenuBackground
        AddHandler Renderer.PaintMenuBorder, AddressOf Renderer_PaintMenuBorder
        AddHandler Renderer.PaintItemImage, AddressOf Renderer_PaintItemImage
        AddHandler Renderer.PaintItemText, AddressOf Renderer_PaintItemText
        AddHandler Renderer.PaintItemBackground, AddressOf Renderer_PaintItemBackground
        MyBase.Renderer = Renderer
    End Sub

    Private Sub Renderer_PaintMenuBackground(sender As Object, e As ToolStripRenderEventArgs)
        G = e.Graphics

        G.Clear(Color.FromArgb(55, 55, 58))
    End Sub


    Private Sub Renderer_PaintMenuBorder(sender As Object, e As ToolStripRenderEventArgs)

        G = e.Graphics

        Using Border As New Pen(Color.FromArgb(35, 35, 38))
            G.DrawRectangle(Border,
                            New Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1,
                                          e.AffectedBounds.Height - 1))
        End Using
    End Sub

    Private Sub Renderer_PaintItemImage(sender As Object, e As ToolStripItemImageRenderEventArgs)

        G = e.Graphics

        G.DrawImage(e.Image, New Point(10, 3))
    End Sub

    Private Sub Renderer_PaintItemText(sender As Object, e As ToolStripItemTextRenderEventArgs)

        G = e.Graphics

        Using Fore As New SolidBrush(e.TextColor)
            G.DrawString(e.Text, Font, Fore, New Point(e.TextRectangle.X, e.TextRectangle.Y + 1))
        End Using
    End Sub

    Private Sub Renderer_PaintItemBackground(sender As Object, e As ToolStripItemRenderEventArgs)

        G = e.Graphics

        Rect = e.Item.ContentRectangle

        If e.Item.Selected Then

            Using Background As New SolidBrush(Color.FromArgb(70, 70, 70))
                G.FillRectangle(Background, New Rectangle(Rect.X - 4, Rect.Y - 1, Rect.Width + 8, Rect.Height - 1))
            End Using

        End If
    End Sub
End Class

Public Class BToolTip
    Inherits ToolTip

    Private G As Graphics

    Public Sub New()
        OwnerDraw = True
        BackColor = Color.FromArgb(41, 41, 44)
        AddHandler Draw, AddressOf OnDraw
    End Sub

    Private Sub OnDraw(sender As Object, e As DrawToolTipEventArgs)

        G = e.Graphics

        G.Clear(Color.FromArgb(41, 41, 44))

        Using Border As New Pen(Color.FromArgb(43, 43, 46))
            G.DrawRectangle(Border, New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1))
        End Using

        Using TextFont As New Font("Segoe UI", 9), Fore As New SolidBrush(Color.FromArgb(180, 180, 180))
            G.DrawString(e.ToolTipText, TextFont, Fore, New PointF(e.Bounds.X + 4, e.Bounds.Y + 1))
        End Using
    End Sub
End Class

Public Class BTabControl
    Inherits TabControl

    Private G As Graphics
    Private Rect As Rectangle

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        e.Control.BackColor = Color.FromArgb(45, 45, 48)
        e.Control.ForeColor = Color.FromArgb(200, 200, 200)
        e.Control.Font = New Font("Segoe UI", 9)
        MyBase.OnControlAdded(e)
    End Sub

    Sub New()
        DoubleBuffered = True
        Alignment = TabAlignment.Left
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(32, 170)
        Font = New Font("Segoe UI", 9)
        SetStyle(
            ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque Or
            ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Parent.BackColor)

        Using Background As New SolidBrush(Color.FromArgb(48, 48, 51))
            G.FillRectangle(Background, New Rectangle(0, 3, 174, Height - 6))
        End Using

        Using Border As New Pen(Color.FromArgb(40, 40, 43))
            G.DrawLine(Border, ItemSize.Height + 3, 4, ItemSize.Height + 3, Height - 5)
        End Using

        For T = 0 To TabPages.Count - 1

            Rect = GetTabRect(T)

            If SelectedIndex = T Then

                Using Background As New SolidBrush(Color.FromArgb(0, 122, 204))
                    G.FillRectangle(Background, New Rectangle(Rect.X - 4, Rect.Y + 1, Rect.Width + 6, Rect.Height - 1))
                End Using

                Using Fore As New SolidBrush(Color.FromArgb(240, 240, 240))
                    G.DrawString(TabPages(T).Text, Font, Fore, New Point(Rect.X + 40, Rect.Y + 8))
                End Using

            Else

                Using Fore As New SolidBrush(Color.FromArgb(180, 180, 180))
                    G.DrawString(TabPages(T).Text, Font, Fore, New Point(Rect.X + 40, Rect.Y + 8))
                End Using

            End If

            If IsNumeric(TabPages(T).Tag) Then

                Select Case TabPages(T).Tag
                    Case 0

                        Using Background As New SolidBrush(Color.FromArgb(201, 106, 87))
                            G.FillRectangle(Background, New Rectangle(Rect.X - 2, Rect.Y + 1, 4, Rect.Height - 1))
                        End Using

                    Case 1

                        Using Background As New SolidBrush(Color.FromArgb(87, 201, 106))
                            G.FillRectangle(Background, New Rectangle(Rect.X - 2, Rect.Y + 1, 4, Rect.Height - 1))
                        End Using

                End Select

            End If

            If Not IsNothing(ImageList) Then
                If Not TabPages(T).ImageIndex < 0 Then
                    G.DrawImage(ImageList.Images(TabPages(T).ImageIndex), New Rectangle(Rect.X + 12, Rect.Y + 5, 22, 22))
                End If
            End If

        Next

        MyBase.OnPaint(e)
    End Sub
End Class

Public Class BHorizontalTabControl
    Inherits TabControl

    Private G As Graphics
    Private Rect As Rectangle

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        e.Control.BackColor = Color.FromArgb(45, 45, 48)
        e.Control.ForeColor = Color.FromArgb(200, 200, 200)
        e.Control.Font = New Font("Segoe UI", 9)
        MyBase.OnControlAdded(e)
    End Sub

    Sub New()
        DoubleBuffered = True
        Alignment = TabAlignment.Top
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(120, 30)
        Font = New Font("Segoe UI", 9)
        SetStyle(
            ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque Or
            ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        G.Clear(Parent.BackColor)

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, 30))
        End Using

        Using Border As New Pen(Color.FromArgb(43, 43, 46))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, 30))
        End Using

        For T = 0 To TabPages.Count - 1

            Rect = GetTabRect(T)

            If SelectedIndex = T Then

                Using Fore As New SolidBrush(Color.FromArgb(240, 240, 240))
                    CenterString(G, TabPages(T).Text, Font, Fore.Color, Rect)
                End Using

            Else

                Using Fore As New SolidBrush(Color.FromArgb(180, 180, 180))
                    CenterString(G, TabPages(T).Text, Font, Fore.Color, Rect)
                End Using

            End If

            If Not IsNothing(ImageList) Then
                If Not TabPages(T).ImageIndex < 0 Then
                    G.DrawImage(ImageList.Images(TabPages(T).ImageIndex), New Rectangle(Rect.X + 6, Rect.Y + 6, 16, 16))
                End If
            End If

        Next

        MyBase.OnPaint(e)
    End Sub
End Class

Public Class BComboBox
    Inherits ComboBox

    Private G As Graphics

    Private State As MouseState
    Private Rect As Rectangle

    Private ItemString As String = String.Empty
    Private FirstItem As String = String.Empty

    Sub New()
        ItemHeight = 20
        DoubleBuffered = True
        Font = New Font("Segoe UI", 9)
        BackColor = Color.FromArgb(40, 40, 43)
        DropDownStyle = ComboBoxStyle.DropDownList
        DrawMode = DrawMode.OwnerDrawFixed
        SetStyle(
            ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.Opaque Or
            ControlStyles.OptimizedDoubleBuffer, True)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        MyBase.OnPaint(e)

        G.Clear(Parent.BackColor)


        Using Fill As New SolidBrush(BackColor)
            G.FillRectangle(Fill, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using

        Select Case State

            Case MouseState.None

                Using Border As New Pen(Color.FromArgb(44, 44, 47))
                    G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                End Using

            Case MouseState.Over

                Using Border As New Pen(Color.FromArgb(52, 52, 55))
                    G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
                End Using

        End Select

        Using ArrowFont As New Font("Marlett", 12), ArrowBrush As New SolidBrush(Color.FromArgb(180, 180, 180))
            G.DrawString("6", ArrowFont, ArrowBrush, New Point(Width - 20, 5))
        End Using

        If Not IsNothing(Items) Then
            Try : FirstItem = GetItemText(Items(0))
            Catch :
            End Try

            If Not SelectedIndex = - 1 Then

                Using TextBrush As New SolidBrush(Color.FromArgb(200, 200, 200))
                    G.DrawString(ItemString, Font, TextBrush, New Point(4, 4))
                End Using

            Else

                Using TextBrush As New SolidBrush(Color.FromArgb(200, 200, 200))
                    G.DrawString(FirstItem, Font, TextBrush, New Point(4, 4))
                End Using

            End If


        End If
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)

        G = e.Graphics

        Rect = e.Bounds

        Using Back As New SolidBrush(Color.FromArgb(30, 30, 30))
            G.FillRectangle(Back, New Rectangle(e.Bounds.X - 4, e.Bounds.Y - 1, e.Bounds.Width + 4, e.Bounds.Height - 1))
        End Using

        If Not e.Index = - 1 Then
            ItemString = GetItemText(Items(e.Index))
        End If

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then

            Using HoverItemBrush As New SolidBrush(Color.FromArgb(220, 220, 220))
                G.DrawString(ItemString, Font, HoverItemBrush, New Point(Rect.X + 5, Rect.Y + 1))
            End Using

        Else

            Using DefaultItemBrush As New SolidBrush(Color.FromArgb(200, 200, 200))
                G.DrawString(ItemString, Font, DefaultItemBrush, New Point(Rect.X + 5, Rect.Y + 1))
            End Using

        End If

        MyBase.OnDrawItem(e)
    End Sub

    Protected Overrides Sub OnSelectedItemChanged(e As EventArgs)
        Invalidate()
        MyBase.OnSelectedItemChanged(e)
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
        State = MouseState.None
        Invalidate()
        MyBase.OnSelectedIndexChanged(e)
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        State = MouseState.Over
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        State = MouseState.None
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub
End Class

Public Class BStatusBar
    Inherits Control

    Private G As Graphics

    Private Body As Color = Color.FromArgb(0, 122, 204)
    Private Outline As Color = Color.FromArgb(0, 126, 204)

    Public Property Type As Types

    Public Function Push(Text As String, Optional Type As Types = Types.Basic) As Boolean
        Me.Text = Text
        Me.Type = Type
        Invalidate()
        Return True
    End Function

    Public Enum Types As Byte
        Basic = 0
        Warning = 1
        Wrong = 2
        Success = 3
    End Enum

    Sub New()
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        Select Case Type

            Case Types.Basic

                Body = Color.FromArgb(0, 122, 204)
                Outline = Color.FromArgb(0, 126, 204)

            Case Types.Warning

                Body = Color.FromArgb(210, 143, 75)
                Outline = Color.FromArgb(214, 147, 75)

            Case Types.Wrong

                Body = Color.FromArgb(212, 110, 110)
                Outline = Color.FromArgb(216, 114, 114)

            Case Else

                Body = Color.FromArgb(45, 193, 90)
                Outline = Color.FromArgb(45, 197, 90)

        End Select

        Using Background As New SolidBrush(Body), Line As New Pen(Outline)
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
            G.DrawLine(Line, 0, 0, Width - 2, 0)
        End Using

        Using Fore As New SolidBrush(Color.FromArgb(255, 255, 255)), Font As New Font("Segoe UI semibold", 8)
            G.DrawString(Text, Font, Fore, New Point(4, 2))
        End Using

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        Invalidate()
        MyBase.OnTextChanged(e)
    End Sub
End Class

Public Class BListBox
    Inherits Control

    Private G As Graphics
    Private WithEvents LB As ListBox

    Private _Items As String() = {""}
    Private _SelectedColor As Color = Color.FromArgb(0, 122, 204)

    Public Property SelectedColor As Color
        Get
            Return _SelectedColor
        End Get
        Set
            _SelectedColor = value
        End Set
    End Property

    Public Property Items As String()
        Get
            Return _Items
        End Get
        Set
            _Items = value
            LB.Items.Clear()
            If Not IsNothing(value) Then
                LB.Items.AddRange(value)
            End If
            Invalidate()
        End Set
    End Property

    Public ReadOnly Property SelectedItem As String
        Get
            Return LB.SelectedItem
        End Get
    End Property

    Public ReadOnly Property SelectedIndex As Integer
        Get
            Return LB.SelectedIndex
        End Get
    End Property

    Sub AddRange(items As Object())
        LB.Items.Remove("")
        LB.Items.AddRange(items)
    End Sub

    Sub AddItem(item As Object)
        LB.Items.Remove("")
        LB.Items.Add(item)
    End Sub

    Public Sub Clear()
        LB.Items.Clear()
    End Sub

    Sub New()
        Font = New Font("Segoe UI", 8)
        LB = New ListBox With {
            .BorderStyle = BorderStyle.None,
            .BackColor = Color.FromArgb(40, 40, 43),
            .Font = Font,
            .Location = New Point(2, 2),
            .ForeColor = Color.FromArgb(200, 200, 200),
            .DrawMode = DrawMode.OwnerDrawFixed}
        Controls.Add(LB)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        G = e.Graphics

        MyBase.OnPaint(e)

        G.Clear(BackColor)

        Using Background As New SolidBrush(Color.FromArgb(40, 40, 43)), Border As New Pen(Color.FromArgb(42, 42, 45))
            G.FillRectangle(Background, New Rectangle(0, 0, Width - 1, Height - 1))
            G.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
        End Using
    End Sub

    Sub Drawitem(sender As Object, e As DrawItemEventArgs) Handles LB.DrawItem

        e.DrawBackground()

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then

            Using Highlight As New SolidBrush(SelectedColor)
                e.Graphics.FillRectangle(Highlight, e.Bounds)
            End Using

        End If

        'If Not IsNothing(e.Then


        'End If

        'e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y)

        Using Fore As New SolidBrush(Color.FromArgb(255, 255, 255))
            e.Graphics.DrawString(LB.GetItemText(LB.Items(e.Index)), Font, Fore, e.Bounds)
        End Using
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        LB.Size = New Size(Width - 3, Height - 2)
        MyBase.OnResize(e)
    End Sub
End Class

Public Class BListView
    Inherits Control

    Public Property Columns As String()

    Public Property Items As ListViewItem()

    Public Property ColumnWidth As Integer = 120

    Public Property SelectedIndex As Integer = - 1

    Public Property SelectedIndexes As New List(Of Integer)

    Public Property Multiselect As Boolean

    Public Property HandleItemsForeColor As Boolean

    Public Property Grid As Boolean

    Public ReadOnly Property SelectedCount As Integer
        Get
            Return SelectedIndexes.Count
        End Get
    End Property

    Public ReadOnly Property FocusedItem As ListViewItem
        Get
            If IsNothing(SelectedIndexes) Then
                Return New ListViewItem
            End If

            Return Items(SelectedIndexes(0))
        End Get
    End Property

    Private SelectedBounds As Rectangle
    Private BorderIndex As Integer = - 1

    Public Event SelectedIndexChanged(sender As Object, e As EventArgs)

    Public Sub Add(Item As ListViewItem)
        If Items Is Nothing Then
            Items = New ListViewItem() {}
        End If
        Dim ItemsList As List(Of ListViewItem) = Items.ToList
        ItemsList.Add(Item)
        Items = ItemsList.ToArray
        Invalidate()
    End Sub

    Sub New()
        DoubleBuffered = True
        ForeColor = Color.FromArgb(200, 200, 200)
        Font = New Font("Segoe UI", 9)
    End Sub

    Public Function ReturnForeFromItem(I As Integer, Item As ListViewItem) As SolidBrush
        If SelectedIndexes.Contains(I) Then
            Return New SolidBrush(Color.FromArgb(10, 10, 10))
        End If
        If HandleItemsForeColor Then
            Return New SolidBrush(Item.ForeColor)
        Else
            Return New SolidBrush(ForeColor)
        End If
    End Function

    Public Function ReturnForeFromSubItem(I As Integer, Item As ListViewItem.ListViewSubItem) As SolidBrush
        If SelectedIndexes.Contains(I) Then
            Return New SolidBrush(Color.FromArgb(10, 10, 10))
        End If
        If HandleItemsForeColor Then
            Return New SolidBrush(Item.ForeColor)
        Else
            Return New SolidBrush(ForeColor)
        End If
    End Function

    'Caution: Don't read below if you don't want your brain to be completely fucked.
    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        e.Graphics.Clear(Color.FromArgb(50, 50, 53))

        Using Background As New SolidBrush(Color.FromArgb(55, 55, 58))
            e.Graphics.FillRectangle(Background, New Rectangle(1, 1, Width - 2, 26))
        End Using

        Using Border As New Pen(Color.FromArgb(42, 42, 45)), Shadow As New Pen(Color.FromArgb(65, 65, 68))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, Height - 1))
            e.Graphics.DrawRectangle(Border, New Rectangle(0, 0, Width - 1, 26))
            e.Graphics.DrawLine(Shadow, 1, 1, Width - 2, 1)
        End Using

        If Not IsNothing(Columns) Then

            For I = 0 To Columns.Count - 1

                If Not I = 0 Then

                    Using Separator As New SolidBrush(Color.FromArgb(42, 42, 45)),
                        Shadow As New SolidBrush(Color.FromArgb(65, 65, 68))
                        e.Graphics.FillRectangle(Separator, New Rectangle(ColumnWidth*I, 1, 1, 26))
                        e.Graphics.FillRectangle(Shadow, New Rectangle(ColumnWidth*I - 1, 1, 1, 25))

                        If Grid AndAlso Not IsNothing(Items) Then

                            e.Graphics.FillRectangle(Separator,
                                                     New Rectangle(ColumnWidth*I, 1, 1, 26 + (Items.Count*16)))
                            e.Graphics.FillRectangle(Shadow,
                                                     New Rectangle(ColumnWidth*I - 1, 1, 1, 25 + (Items.Count*16)))

                        End If

                    End Using

                End If

                Using Fore As New SolidBrush(ForeColor)

                    If I = 0 Then
                        e.Graphics.DrawString(Columns(I), Font, Fore, New Point(6, 4))
                    Else
                        e.Graphics.DrawString(Columns(I), Font, Fore, New Point((ColumnWidth*I) + 6, 4))
                    End If

                End Using

            Next

        End If

        If Not IsNothing(Items) Then

            Using Selection As New SolidBrush(Color.FromArgb(41, 130, 232)), Line As New Pen(Color.FromArgb(40, 40, 40))

                If Multiselect AndAlso Not SelectedIndexes.Count = 0 Then

                    For Each Selected As Integer In SelectedIndexes

                        If Selected = 0 Then
                            e.Graphics.FillRectangle(Selection, New Rectangle(1, 27, Width - 2, 16))
                        Else
                            e.Graphics.FillRectangle(Selection, New Rectangle(1, 27 + Selected*16, Width - 2, 16))
                        End If

                        If Selected = 0 AndAlso SelectedIndexes.Count = 1 Then
                            e.Graphics.DrawLine(Line, 1, 27 + 16, Width - 2, 27 + 16)

                        ElseIf SelectedIndexes.Count = 1 Then
                            e.Graphics.DrawLine(Line, 1, 27 + 16 + Selected*16, Width - 2, 27 + 16 + Selected*16)
                        End If

                    Next

                Else

                    If SelectedIndex = 0 Then
                        e.Graphics.FillRectangle(Selection, New Rectangle(1, 27, Width - 2, 16))

                    ElseIf SelectedIndex > 0 Then
                        e.Graphics.FillRectangle(Selection, New Rectangle(1, 27 + SelectedIndex*16, Width - 2, 16))
                    End If

                End If


            End Using

            If SelectedIndexes.Count > 0 Then
                BorderIndex = SelectedIndexes.Max
            End If

            For I = 0 To Items.Count - 1

                Using Fore As New SolidBrush(ForeColor)

                    If I = 0 Then

                        e.Graphics.DrawString(Items(I).Text, Font, ReturnForeFromItem(0, Items(0)), New Point(6, 26))
                        SelectedBounds = New Rectangle(1, 27, Width - 2, 16)

                    Else
                        e.Graphics.DrawString(Items(I).Text, Font, ReturnForeFromItem(I, Items(I)),
                                              New Point(6, 26 + I*16))
                        SelectedBounds = New Rectangle(1, 27 + I*16, Width - 2, 16)
                    End If


                    If Not IsNothing(Items(I).SubItems) Then

                        For X = 0 To Items(I).SubItems.Count - 1

                            If Not Items(I).SubItems(X).Text = Items(I).Text Then
                                e.Graphics.DrawString(Items(I).SubItems(X).Text, Font,
                                                      ReturnForeFromSubItem(I, Items(I).SubItems(X)),
                                                      New Rectangle((ColumnWidth*X) + 6, 26 + I*16, ColumnWidth - 8, 16))
                            End If

                        Next

                    End If

                End Using

            Next

            If SelectedIndexes.Contains(BorderIndex) Then

                Using Selection As New SolidBrush(Color.FromArgb(41, 130, 232)),
                    Line As New Pen(Color.FromArgb(40, 40, 40))
                    e.Graphics.DrawLine(Line, 1, 27 + 16 + BorderIndex*16, Width - 2, 27 + 16 + BorderIndex*16)
                End Using

            End If

        End If

        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)

        Dim Selection As Integer = GetSelectedFromLocation(e.Location)

        If Selection = - 1 OrElse Not (e.Button = MouseButtons.Left OrElse e.Button = MouseButtons.Right) Then _
            MyBase.OnMouseUp(e) : Return

        If Multiselect AndAlso My.Computer.Keyboard.CtrlKeyDown Then

            If Not SelectedIndexes.Contains(Selection) Then
                SelectedIndexes.Add(Selection)
            Else
                SelectedIndexes.Remove(Selection)
            End If

        ElseIf Multiselect AndAlso Not My.Computer.Keyboard.CtrlKeyDown AndAlso Not My.Computer.Keyboard.ShiftKeyDown _
            Then

            SelectedIndexes = New List(Of Integer)
            SelectedIndexes.Add(Selection)

        Else
            SelectedIndexes = New List(Of Integer)
            SelectedIndexes.Add(Selection)
            SelectedIndex = Selection
        End If

        If Selection = - 1 Then
            SelectedIndexes = New List(Of Integer)
        End If

        Invalidate()

        RaiseEvent SelectedIndexChanged(Me, e)
        MyBase.OnMouseUp(e)
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)

        If Multiselect And e.KeyCode = Keys.A AndAlso e.Control Then
            SelectedIndexes = New List(Of Integer)

            For I = 0 To Items.Count - 1
                SelectedIndexes.Add(I)
            Next
            Invalidate()
        End If

        MyBase.OnKeyDown(e)
    End Sub

    Private Function GetSelectedFromLocation(Location As Point) As Integer

        If Not IsNothing(Items) Then

            For I = 0 To Items.Count - 1

                If I = 0 Then

                    If New Rectangle(1, 27, Width - 2, 16).Contains(Location) Then
                        Return 0
                    End If

                Else

                    If New Rectangle(1, 27 + I*16, Width - 2, 16).Contains(Location) Then
                        Return I
                    End If

                End If

            Next

        End If

        Return - 1
    End Function
End Class