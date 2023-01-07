Imports System.Threading

Public Class Form1
    Private WithEvents bufferedWriter As NetworkVariableBufferedWriter(Of Int32)
    Private readerInterval As NetworkVariableReader(Of Int32)
    Private readerBoolean As NetworkVariableReader(Of Boolean)
    'Private WithEvents writeInt As NetworkVariableBufferedWriter(Of Int16)
    Private readerInt As NetworkVariableReader(Of Int16) 'Short read as Int16
    Private readerStr As NetworkVariableReader(Of UInt32) ' String read as Unit32
    'Private Const NetworkVariableLocation As String = "\\localhost\system\doublearray"
    Private Const DoubleNetworkVariableLocation As String = "\\localhost\OPC\OPC\PLC\_System\_WriteOptimizationDutyCycle"
    Private Const BooleanExample As String = "\\localhost\OPC\OPC\PLC\PLC0\manual"
    Private Const IntExample As String = "\\localhost\OPC\OPC\PLC\PLC0\Print_RH_NGCode"
    Private Const StrExample As String = "\\localhost\OPC\OPC\PLC\PLC0\Print_HW_Ver"

    Public Sub New()
        InitializeComponent()

        bufferedWriter = New NetworkVariableBufferedWriter(Of Int32)(DoubleNetworkVariableLocation)
        'doubleBufferedWriter = New NetworkVariableBufferedWriter(Of Double)(DoubleNetworkVariableLocation)
        readerInterval = New NetworkVariableReader(Of Int32)(DoubleNetworkVariableLocation)
        readerBoolean = New NetworkVariableReader(Of Boolean)(BooleanExample)
        'writeInt = New NetworkVariableBufferedWriter(Of Int16)(IntExample)
        readerInt = New NetworkVariableReader(Of Int16)(IntExample)
        readerStr = New NetworkVariableReader(Of UInt32)(StrExample)
        'writeInt.Connect()
        readerInt.Connect()
        bufferedWriter.Connect()
        readerInterval.Connect()
        readerBoolean.Connect()
        readerStr.Connect()
        Thread.Sleep(1000)
        'doubleBufferedWriter.Connect()
        Label1.Text = readerInterval.ReadData().GetValue
        Label2.Text = readerBoolean.ReadData().GetValue
        Label3.Text = readerInt.ReadData().GetValue
        Label4.Text = readerStr.ReadData().GetValue

    End Sub

End Class
