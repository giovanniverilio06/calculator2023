﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator_2023
{
    public partial class Calculator2023 : Form
    {
        public enum SymbolType
        {
            Number,
            Operator,
            Specialoperator,
            DecimalPoint,
            PlusMminusSign,
            Backspace,
            ClearAll,
            ClearEntry,
            Undefined
        }

        public struct btnStruct
        {
            public char Content;
            public SymbolType Type;
            public bool IsBold;
            public btnStruct(char c, SymbolType t = SymbolType.Undefined, bool b = false)
            {
                this.Content = c;
                this.Type = t;
                this.IsBold = b;
            }
        }

        private btnStruct[,] buttons =
        {
            { new btnStruct('%'), new btnStruct('\u0152',SymbolType.ClearEntry), new btnStruct('C',SymbolType.ClearAll), new btnStruct('\u232B',SymbolType.Backspace) },
            { new btnStruct('\u215F',SymbolType.Specialoperator), new btnStruct('\u00B2'), new btnStruct('\u221A'), new btnStruct('\u00F7',SymbolType.Operator) },
            { new btnStruct('7',SymbolType.Number, true), new btnStruct('8',SymbolType.Number, true), new btnStruct('9',SymbolType.Number, true), new btnStruct('\u00D7',SymbolType.Operator) },
            { new btnStruct('4',SymbolType.Number, true), new btnStruct('5',SymbolType.Number, true), new btnStruct('6',SymbolType.Number, true), new btnStruct('-',SymbolType.Operator) },
            { new btnStruct('1',SymbolType.Number, true), new btnStruct('2',SymbolType.Number, true), new btnStruct('3',SymbolType.Number, true), new btnStruct('+',SymbolType.Operator) },
            { new btnStruct('\u00B1',SymbolType.PlusMminusSign), new btnStruct('0',SymbolType.Number, true), new btnStruct(',',SymbolType.DecimalPoint), new btnStruct('=',SymbolType.Operator) },
        };
        float lblResultBaseFontSize;
        const int lblResultWidthMargin = 24;
        const int lblResultMaxDigit = 25;

        char lastOperator = ' ';
        decimal operand1, operand2, result;
        btnStruct lastButtonClicked;
        public Calculator2023()
        {
            InitializeComponent();
            lblResultBaseFontSize = lblResult.Font.Size;

        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }

        private void Calculator2023_Load(object sender, EventArgs e)
        {
            MakeButtons(buttons.GetLength(0),buttons.GetLength(1));
        }

        private void MakeButtons(int rows,int cols)
        {
            int btnWidth = 80;
            int btnHeight = 60;
            int posX = 0;
            int posY = 116;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button myButton = new Button();
                    FontStyle fs = buttons[i, j].IsBold ? FontStyle.Bold : FontStyle.Regular;
                    myButton.Text = buttons[i, j].Content.ToString();
                    myButton.Font = new Font("Segoe UI", 16, fs);
                    myButton.BackColor = buttons[i, j].IsBold ? Color.White : Color.Transparent;
                    myButton.Width = btnWidth;
                    myButton.Height = btnHeight;
                    myButton.Top = posY;
                    myButton.Left = posX;
                    myButton.Tag = buttons[i, j];
                    myButton.Click += Button_Click;
                    this.Controls.Add(myButton);
                    posX += myButton.Width;

                }
                posX = 0;
                posY += btnHeight;
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            btnStruct clickedButtonStruct = (btnStruct)clickedButton.Tag;

            switch (clickedButtonStruct.Type)
            {
                case SymbolType.Number:
                    if (lblResult.Text == "0" || lastButtonClicked.Type == SymbolType.Operator) lblResult.Text = "";
                    lblResult.Text += clickedButton.Text;
                    break;
                case SymbolType.Operator:
                case SymbolType.Specialoperator:
                    if (lastButtonClicked.Type != SymbolType.Operator || clickedButtonStruct.Content == '=')
                    {
                        ManageOperator(clickedButtonStruct);
                    }
                    else
                    {
                        lastOperator = clickedButtonStruct.Content;
                    }
                    break;
                case SymbolType.DecimalPoint:
                    if (lblResult.Text.IndexOf(",") == -1)
                        lblResult.Text += clickedButton.Text;
                    break;
                case SymbolType.PlusMminusSign:
                    if (lblResult.Text != "0")
                        if (lblResult.Text.IndexOf("-") == -1)
                            lblResult.Text = "-" + lblResult.Text;
                        else
                            lblResult.Text = lblResult.Text.Substring(1);
                    break;
                case SymbolType.Backspace:
                    if (lastButtonClicked.Type != SymbolType.Operator)
                    {
                        lblResult.Text = lblResult.Text.Substring(0, lblResult.Text.Length - 1);
                        if (lblResult.Text.Length == 0 || lblResult.Text == "-0" || lblResult.Text == "-")
                            lblResult.Text = "0";
                    }
                    break;
                case SymbolType.ClearAll:
                    operand1 = 0;
                    operand2 = 0;
                    result = 0;
                    lastOperator = ' ';
                    lblResult.Text = "0";
                    break;
                case SymbolType.Undefined:
                    break;
                default:
                    break;
            }
            if (clickedButtonStruct.Type != SymbolType.Backspace)
                lastButtonClicked = clickedButtonStruct;
        }
        private void ManageOperator(btnStruct clickedButtonStruct)
        {
            if(clickedButtonStruct.Type ==SymbolType.Specialoperator)
            {
                switch(clickedButtonStruct.Content)
                {
                    case '\u215f':
                        result = 1 / operand2;
                        break;
                        default :
                        break;
                }
            }
            if (lastOperator == ' ' )
            {
                operand1 = decimal.Parse(lblResult.Text);
                if (clickedButtonStruct.Content != '=') lastOperator = clickedButtonStruct.Content;
            }
            else
            {
                if (lastButtonClicked.Content != '=') operand2 = decimal.Parse(lblResult.Text);
                switch (lastOperator)
                {
                    case '+':
                        result = operand1 + operand2;
                        break;
                    case '-':
                        result = operand1 - operand2;
                        break;
                    case '\u00F7':
                        result = operand1 / operand2;
                        break;
                    case '\u00D7':
                        result = operand1 * operand2;
                        break;
                    
                    

                }
                operand1 = result;
                if (clickedButtonStruct.Content != '=')
                {
                    lastOperator = clickedButtonStruct.Content;
                    if (lastButtonClicked.Content == '=')
                        operand2 = 0;
                }
                lblResult.Text = result.ToString();
            }
        }

        private void lblResult_TextChanged(object sender, EventArgs e)
        {
            if (lblResult.Text.Length > 0)
            {
                double num = double.Parse(lblResult.Text); string stOut = "";
                NumberFormatInfo nfi = new CultureInfo("it-IT", false).NumberFormat;
                int decimalSeparatorPosition = lblResult.Text.IndexOf(",");
                nfi.NumberDecimalDigits = decimalSeparatorPosition == -1 ? 0
                    : lblResult.Text.Length - decimalSeparatorPosition - 1;
                stOut = num.ToString("N", nfi);
                if (lblResult.Text.IndexOf(",") == lblResult.Text.Length - 1) stOut += ",";
                lblResult.Text = stOut;


            }
            if (lblResult.Text.Length > lblResultMaxDigit)
                lblResult.Text = lblResult.Text.Substring(0, lblResultMaxDigit);

            int textWidth = TextRenderer.MeasureText(lblResult.Text, lblResult.Font).Width;
            float newSize = lblResult.Font.Size * (((float)lblResult.Size.Width - lblResultWidthMargin) / textWidth);
            if (newSize > lblResultBaseFontSize) newSize = lblResultBaseFontSize;
            lblResult.Font = new Font("Segoe UI", newSize, FontStyle.Regular);


        }
    
}
}
