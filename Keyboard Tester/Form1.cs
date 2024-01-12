﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_Tester
{
    public partial class Form1 : Form
    {
        private Button[] numericButtons;
        public Form1()
        {
            InitializeComponent();
            InitializeNumericButtons();
        }
        private void InitializeNumericButtons()
        {
            // Create an array of numeric buttons
            numericButtons = new Button[] { btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }
        private void RemoveFocusFromAllControls()
        {
            foreach (Control control in this.Controls)
            {
                control.Focus();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Activate();
            //this.Focus();
            
            this.KeyPreview = true;

            // Call the method to remove focus from all controls
            RemoveFocusFromAllControls();
        }

        private void ChangeButtonColor(Button button, bool isPressed)
        {
            button.BackColor = isPressed ? Color.Lime : SystemColors.Control;
        }
        private void ChangePicColor(PictureBox pic, bool isPressed)
        {
            pic.BackColor = isPressed ? Color.Lime : SystemColors.Control;
        }
       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Show a popup with the name of the pressed key
            //MessageBox.Show("Key pressed: " + e.KeyCode, "Key Pressed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Find the corresponding button based on the key pressed
            Control[] controls = this.Controls.Find("btn" + e.KeyCode.ToString(), true);

            if (controls.Length > 0 && controls[0] is Button)
            {
                Button correspondingButton = (Button)controls[0];
                correspondingButton.BackColor = Color.Lime;
            }

            // Check if the pressed key is a numeric key (D0 to D9)
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                int buttonIndex = (int)e.KeyCode - (int)Keys.D0;

                if (buttonIndex >= 0 && buttonIndex < numericButtons.Length)
                {
                    numericButtons[buttonIndex].BackColor = Color.Lime;
                }
            }

           
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    // Check if the right Ctrl key is pressed
                    if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                    {
                        // Right Ctrl key is pressed
                        ChangeButtonColor(btnCTRLRIGHT, true);
                    }
                    else
                    {
                        // Left Ctrl key is pressed
                        ChangeButtonColor(btnCTRLLEFT, true);
                    }
                    break;
                case Keys.ShiftKey:
                    
                    if ((e.Modifiers & Keys.Control) == Keys.Control)
                    {
                        // Right shift key is pressed
                        ChangeButtonColor(btnSHIFTRIGHT, true);
                    }
                    else
                    {
                        // Left shift key is pressed
                        ChangeButtonColor(btnSHIFTLEFT, true);
                    }
                    break;
                case Keys.Menu:
                    // Check if the right Ctrl key is pressed
                    if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                    {
                        // Right Ctrl key is pressed
                        ChangeButtonColor(btnALTRIGHT, true);
                    }
                    else
                    {
                        // Left Ctrl key is pressed
                        ChangeButtonColor(btnALTLEFT, true);
                    }
                    break;
                case Keys.CapsLock:
                    ChangeButtonColor(btnCAPSLOCK, Control.IsKeyLocked(Keys.CapsLock));
                    break;
                case Keys.Tab:
                    ChangeButtonColor(btnTAB, true);
                    e.SuppressKeyPress = true; // Prevent default navigation behavior
                    break;
                case Keys.LWin:
                case Keys.RWin:
                    e.SuppressKeyPress = true; // Prevent default navigation behavior
                    ChangePicColor(btnWINDOW, true);
                    
                    break;
                case Keys.Apps:
                    ChangePicColor(btnMenu, true);
                    break;
                case Keys.Oemcomma:
                    ChangeButtonColor(btnComa, true);
                    break;
                case Keys.OemPeriod:
                    ChangeButtonColor(btnPeriod, true);
                    break;
                case Keys.OemQuestion:
                    ChangeButtonColor(btnSlash, true);
                    break;
                case Keys.Oemtilde:
                    ChangeButtonColor(btnTilde, true);
                    break;
                case Keys.Escape:
                    ChangeButtonColor(btnESC, true);
                    break;
                case Keys.Print:
                    ChangeButtonColor(btnPRTSC, true);
                    break;
                case Keys.PageUp:
                    ChangeButtonColor(btnPgUp, true);
                    break;
                case Keys.PageDown:
                    ChangeButtonColor(btnPgDn, true);
                    break;
                case Keys.NumLock:
                    ChangeButtonColor(btnNumlk, true);
                    break;
                case Keys.OemSemicolon:
                    ChangeButtonColor(btnSemicolon, true);
                    break;
                case Keys.OemQuotes:
                    ChangeButtonColor(btnQuote, true);
                    break;
                case Keys.OemOpenBrackets:
                    ChangeButtonColor(btnOpenBrackets, true);
                    break;
                case Keys.OemCloseBrackets:
                    ChangeButtonColor(btnClosedBrackets, true);
                    break;
                case Keys.Oem5:
                    ChangeButtonColor(btnBackSlash, true);
                    break;
                case Keys.Oemplus:
                    ChangeButtonColor(btnPlus, true);
                    break;
                case Keys.OemMinus:
                    ChangeButtonColor(btnMinus, true);
                    break;
                case Keys.Back:
                    ChangeButtonColor(btnBACKSPACE, true);
                    break;
                case Keys.Divide:
                    ChangeButtonColor(btnNumPadDivision, true);
                    break;
                case Keys.Multiply:
                    ChangeButtonColor(btnNumPadMultiplication, true);
                    break;
                case Keys.Subtract:
                    ChangeButtonColor(btnNumPadMinus, true);
                    break;
                case Keys.Add:
                    ChangeButtonColor(btnNumPadPlus, true);
                    break;
                case Keys.Decimal:
                    ChangeButtonColor(btnNumPadPeriod, true);
                    break;
                case Keys.Enter:
                   if ((e.Modifiers & Keys.Control) == Keys.Control)
                    {
                        ChangeButtonColor(btnENTER, true);
                    }
                    else if ((e.Modifiers & Keys.Alt) == Keys.Alt)
                    {
                        ChangeButtonColor(btnNumPadEnter, true);
                    }
                    break;
                
                   
                // Add more cases for other keys...

                default:
                    break;
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Tab key is pressed
            if (keyData == Keys.Tab)
            {
                ChangeButtonColor(btnTAB, true);
                return true; // Suppress default behavior
            }
            if (keyData == Keys.Left)
            {
                ChangeButtonColor(btnLEFT, true);
                return true; // Suppress default behavior
            }
            if (keyData == Keys.Up)
            {
                ChangeButtonColor(btnUP, true);
                return true; // Suppress default behavior
            }
            if (keyData == Keys.Down)
            {
                ChangeButtonColor(btnDOWN, true);
                return true; // Suppress default behavior
            }
            if (keyData == Keys.Right)
            {
                ChangeButtonColor(btnRIGHT, true);
                return true; // Suppress default behavior
            }

            // Add more key checks and custom behaviors...

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void picGithub_Click(object sender, EventArgs e)
        {
            string githublink = "https://github.com/NattyXO/Keyboard-Tester";

            Process.Start(githublink);
        }

        private void picYoutube_Click(object sender, EventArgs e)
        {
            string youtubelink = "https://www.youtube.com/@AhaduTech";

            Process.Start(youtubelink);
        }
        private void ShowHelpMessage()
        {
            string helpMessage = "Key Combinations:\n\n" +
                                 "Ctrl + Enter:\n  - Result: Normal Enter\n  - Description: Pressing Ctrl and Enter simultaneously will simulate a regular Enter key press.\n\n" +
                                 "Alt + Enter:\n  - Result: Numpad Enter\n  - Description: Pressing Alt and Enter simultaneously will simulate a Numpad Enter key press.\n\n" +
                                 "Shift + Ctrl:\n  - Result: Right Ctrl\n  - Description: Pressing Shift and Ctrl simultaneously will simulate a press of the right Ctrl key.\n\n" +
                                 "Ctrl + Shift:\n  - Result: Right Shift\n  - Description: Pressing Ctrl and Shift simultaneously will simulate a press of the right Shift key.\n\n" +
                                 "Note: These key combinations are specific to this Keyboard Tester application and may not have the same effect in other contexts.\n\n" +
                                 "Thank you for using Keyboard Tester!";

            MessageBox.Show(helpMessage, "Keyboard Tester Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHelpMessage();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ResetAllKeyColors()
        {
            // Reset the color of all buttons to white
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).BackColor = Color.White;
                }
            }

            btnWINDOW.BackColor = Color.White;
            btnMenu.BackColor = Color.White;
            // btnSpecial.BackColor = SystemColors.Control;
        }
        private void resetAllKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetAllKeyColors();
        }

        private void runAllTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Iterate through all keys and simulate key presses
            for (int keyCode = 0; keyCode < 256; keyCode++)
            {
                char keyChar = (char)keyCode;

                // Handle special characters
                string keyToSend = keyChar.ToString();
                if (keyChar == '{' || keyChar == '}' || keyChar == '(' || keyChar == ')' || keyChar == '%' || keyChar == '+' || keyChar == '^')
                {
                    keyToSend = "{" + keyChar + "}";
                }

                SendKeys.Send(keyToSend);
            }

            // Wait for a moment to observe the visual changes
            System.Threading.Thread.Sleep(1000);

            // Reset all key colors after the test
            ResetAllKeyColors();
        }
    }
}
