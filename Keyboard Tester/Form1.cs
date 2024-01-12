using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            this.PreviewKeyDown += Form1_PreviewKeyDown;
            this.KeyUp += Form1_KeyUp;

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
                    ChangeButtonColor(btnCTRLLEFT, true);
                    break;
                case Keys.ShiftKey:
                    ChangeButtonColor(btnSHIFTLEFT, true);
                    break;
                case Keys.Menu:
                    ChangeButtonColor(btnALTRIGHT, true);
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
                case Keys.Up:
                    ChangeButtonColor(btnUP, true);
                    break;
                case Keys.Down:
                    ChangeButtonColor(btnDOWN, true);
                    break;
                case Keys.Right:
                    ChangeButtonColor(btnRIGHT, true);
                    break;
                case Keys.Left:
                    ChangeButtonColor(btnLEFT, true);
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
                // Add more cases for other keys...

                default:
                    break;
            }

        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
