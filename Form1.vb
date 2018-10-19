Public Class Form1
    Const PriceBoardsOnly As Decimal = 20.0
    Const PriceWithBoots As Decimal = 30.0
    Dim TotalPrice As Decimal
    Dim SummaryQuantityBoots, SummaryQuantityBoards As Integer
    Dim SummaryTotal As Decimal
    Dim SummaryAverage As Decimal
    Dim NumOfSales As Integer


    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextID.TextChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCalcOrder_Click(sender As Object, e As EventArgs) Handles BtnCalcOrder.Click
        Dim QuantityBoardsOnly, QuantityWithBoots As Integer
        Try
            'Convert quantity to numeric value
            QuantityBoardsOnly = Integer.Parse(TextQuantBoards.Text)
            QuantityWithBoots = Integer.Parse(TextQuantBoots.Text)
            Try
                'Calculate price of the order placed
                TotalPrice = (QuantityBoardsOnly * PriceBoardsOnly) + (QuantityWithBoots * PriceWithBoots)
                'Display the total price in the text box named total
                TextBoxTotal.Text() = TotalPrice.ToString("N")
                'Calculate summary values
                SummaryQuantityBoots += QuantityWithBoots
                SummaryQuantityBoards += QuantityBoardsOnly
                SummaryTotal += TotalPrice
                NumOfSales += 1
                SummaryAverage = SummaryTotal / NumOfSales
                'Display summary values
                TextSnowboardsTotal.Text() = SummaryQuantityBoards.ToString("N")
                TextSnowBoardsWithBootsTotal.Text() = SummaryQuantityBoots.ToString("N")
                TextTotalCharges.Text() = SummaryTotal.ToString("N")
                TextAvgCharge.Text() = SummaryAverage.ToString("N")



            Catch PriceEx As FormatException
                ' Handle the price exception with message
                MessageBox.Show("Could not calculate total due to invalid inputs", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                With TextBoxTotal
                    .Focus()
                    .SelectAll()
                End With
            End Try

        Catch ex As Exception
            ' Handle the quantity exception
            MessageBox.Show("Quantities must be numeric.", "Enter numeric values",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            With TextQuantBoards
                .Focus()
                .SelectAll()
            End With
            With TextQuantBoots
                .Focus()
                .SelectAll()
            End With
        End Try
    End Sub

    'Make the clear button the cancel button
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        TextName.Clear()
        TextID.Clear()
        TextQuantBoards.Clear()
        TextQuantBoots.Clear()
    End Sub

    Private Sub BtnClearAll_Click(sender As Object, e As EventArgs) Handles BtnClearAll.Click

        'Clear summary and set summary values to 0 for a new day of sales
        SummaryQuantityBoards = 0
        SummaryQuantityBoots = 0
        SummaryAverage = 0
        SummaryTotal = 0
        TextAvgCharge.Clear()
        TextSnowboardsTotal.Clear()
        TextSnowBoardsWithBootsTotal.Clear()
        TextTotalCharges.Clear()
        TextName.Clear()
        TextID.Clear()
        TextQuantBoards.Clear()
        TextQuantBoots.Clear()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    'Print the form
    Private Sub Print_Click(sender As Object, e As EventArgs) Handles Print.Click
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub

    'Exit the form

End Class
