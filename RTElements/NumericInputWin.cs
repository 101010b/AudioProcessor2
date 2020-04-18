using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioProcessor
{
    public partial class NumericInputWin : Form
    {
        double valMin;
        double valMax;
        public double value;
        double originalValue;
        double rangeMax;
        Boolean hasLimits;
        Boolean isLog;
        String name;
        String unit;
        String format;

        // public ProcessingControl owner;
        public Control ownerCtrl;

        /*
        public NumericInputWin(ProcessingControl _owner, string _name, String _unit, String _format, double _valMin, double _value, double _valMax, Boolean _isLog) : 
            this(_owner, _name, _unit, _format, true, _valMin, _value, _valMax, _isLog)
        {
        }

        public NumericInputWin(ProcessingControl _owner, string _name, String _unit, String _format, double _value, Boolean _isLog) :
            this(_owner, _name, _unit, _format, false, -1, _value, 1, _isLog)
        {
        }

        public NumericInputWin(ProcessingControl _owner, string _name, String _unit, String _format, double _value) :
            this(_owner, _name, _unit, _format, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(ProcessingControl _owner, string _name, String _unit, double _value) :
            this(_owner, _name, _unit, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(ProcessingControl _owner, string _name, double _value) :
              this(_owner, _name, null, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(ProcessingControl _owner, double _value) :
              this(_owner, null, null, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(ProcessingControl _owner, string _name, String _unit, String _format, Boolean _hasLimits, double _valMin, double _value, double _valMax, Boolean _isLog):
            this(_name,_unit,_format,_hasLimits,_valMin,_value,_valMax,_isLog)
        {
            owner = _owner;
        }
        */
        public NumericInputWin(Control _owner, string _name, String _unit, String _format, double _valMin, double _value, double _valMax, Boolean _isLog) :
            this(_owner, _name, _unit, _format, true, _valMin, _value, _valMax, _isLog)
        {
        }

        public NumericInputWin(Control _owner, string _name, String _unit, String _format, double _value, Boolean _isLog) :
            this(_owner, _name, _unit, _format, false, -1, _value, 1, _isLog)
        {
        }

        public NumericInputWin(Control _owner, string _name, String _unit, String _format, double _value) :
            this(_owner, _name, _unit, _format, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(Control _owner, string _name, String _unit, double _value) :
            this(_owner, _name, _unit, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(Control _owner, string _name, double _value) :
              this(_owner, _name, null, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(Control _owner, double _value) :
              this(_owner, null, null, null, false, -1, _value, 1, false)
        {
        }

        public NumericInputWin(Control _owner, string _name, String _unit, String _format, Boolean _hasLimits, double _valMin, double _value, double _valMax, Boolean _isLog) :
            this(_name, _unit, _format, _hasLimits, _valMin, _value, _valMax, _isLog)
        {
            ownerCtrl = _owner;
        }


        public NumericInputWin(string _name, String _unit, String _format, Boolean _hasLimits, double _valMin, double _value, double _valMax, Boolean _isLog) : base()
        {
            name = _name;
            unit = _unit;
            valMin = _valMin;
            valMax = _valMax;
            value = _value;
            isLog = _isLog;
            format = _format;
            // owner = null;
            ownerCtrl = null;
            originalValue = value;
            hasLimits = _hasLimits;

            InitializeComponent();

            if ((format == null) || (format.Length < 1))
                format = "{0}";

            if (hasLimits)
            {
                numericInMax.Text = String.Format(format, valMax);
                numericInMin.Text = String.Format(format, valMin);
            }
            else
            {
                numericInMax.Visible = false;
                numericInMin.Visible = false;
                numericInSetMax.Visible = false;
                numericInSetMin.Visible = false;
            }
            if ((unit == null) || (unit.Length < 1))
                numericInUnit.Visible = false;
            else
                numericInUnit.Text = unit;

            updateValue();

            if (isLog)
            {
                numericInPlus100.Text = "x 2";
                numericInPlus10.Text = "+10%";
                numericInPlus1.Text = "+1%";
                numericInMinus1.Text = "-1%";
                numericInMinus10.Text = "-10%";
                numericInMinus100.Text = "/ 2";
            }
            else
            {
                double range = valMax - valMin;
                if (!hasLimits)
                    range = 100;

                if (range >= 10000)
                {
                    rangeMax = 1000;
                    numericInPlus100.Text = "+1000";
                    numericInPlus10.Text = "+100";
                    numericInPlus1.Text = "+10";
                    numericInMinus1.Text = "-10";
                    numericInMinus10.Text = "-100";
                    numericInMinus100.Text = "-1000";
                }
                else if (range >= 1000)
                {
                    rangeMax = 100;
                    numericInPlus100.Text = "+100";
                    numericInPlus10.Text = "+10";
                    numericInPlus1.Text = "+1";
                    numericInMinus1.Text = "-1";
                    numericInMinus10.Text = "-10";
                    numericInMinus100.Text = "-100";
                }
                else if (range >= 100)
                {
                    rangeMax = 10;
                    numericInPlus100.Text = "+10";
                    numericInPlus10.Text = "+1";
                    numericInPlus1.Text = "+0.1";
                    numericInMinus1.Text = "-0.1";
                    numericInMinus10.Text = "-1";
                    numericInMinus100.Text = "-10";
                }
                else if (range >= 10)
                {
                    rangeMax = 1;
                    numericInPlus100.Text = "+1";
                    numericInPlus10.Text = "+0.1";
                    numericInPlus1.Text = "+0.01";
                    numericInMinus1.Text = "-0.01";
                    numericInMinus10.Text = "-0.1";
                    numericInMinus100.Text = "-1";
                }
                else
                {
                    rangeMax = 0.1;
                    numericInPlus100.Text = "+0.1";
                    numericInPlus10.Text = "+0.01";
                    numericInPlus1.Text = "+0.001";
                    numericInMinus1.Text = "-0.001";
                    numericInMinus10.Text = "-0.01";
                    numericInMinus100.Text = "-0.1";
                }
            }
            numericInEnter.Click += NumericInEnter_Click;
            numericInVal.TextChanged += NumericInVal_TextChanged;

            numericInSetMax.Click += NumericInSetMax_Click;
            numericInSetMin.Click += NumericInSetMin_Click;

            numericInPlus100.Click += NumericInPlus100_Click;
            numericInPlus10.Click += NumericInPlus10_Click;
            numericInPlus1.Click += NumericInPlus1_Click;
            numericInMinus1.Click += NumericInMinus1_Click;
            numericInMinus10.Click += NumericInMinus10_Click;
            numericInMinus100.Click += NumericInMinus100_Click;

            numericInEnterMu.Click += NumericInEnterMu_Click;
            numericInEnterMilli.Click += NumericInEnterMilli_Click;
            numericInEnterKilo.Click += NumericInEnterKilo_Click;
            numericInEnterMega.Click += NumericInEnterMega_Click;

            KeyDown += NumericInputWin_KeyDown;

            //LostFocus += new EventHandler(lostFocus);

            KeyPreview = true;

            numericInVal.SelectAll();
        }
        /*
        private void lostFocus(object sender, EventArgs e)
        {
            Form f = sender as Form;
            f.Close();
            f.Dispose();
        }
        */
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
        }

        private void NumericInputWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                value = originalValue;
                this.Close();
                return;
            }
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            //if (owner != null)
            //    owner.clientWinClosed();
            //owner = null;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            this.Close();
        }

        private double limit(double val)
        {
            if (!hasLimits) return val;

            if (val < valMin)
                val = valMin;
            if (val > valMax)
                val = valMax;
            return val;
        }

        private void NumericInEnterMega_Click(object sender, EventArgs e)
        {
            value = limit(value * 1e6);
            this.Close();
        }

        private void NumericInEnterKilo_Click(object sender, EventArgs e)
        {
            value = limit(value * 1e3);
            this.Close();
        }

        private void NumericInEnterMilli_Click(object sender, EventArgs e)
        {
            value = limit(value * 1e-3);
            this.Close();
        }

        private void NumericInEnterMu_Click(object sender, EventArgs e)
        {
            value = limit(value * 1e-6);
            this.Close();
        }

        private void updateValue()
        {
            numericInVal.Text = String.Format(format, value);
            if (hasLimits)
            {
                if ((value < valMin) || (value > valMax))
                    numericInVal.ForeColor = Color.Red;
                else
                    numericInVal.ForeColor = Color.Green;
            } else
                numericInVal.ForeColor = Color.Green;
        }

        private void NumericInMinus100_Click(object sender, EventArgs e)
        {
            if (isLog)
            { 
                value = limit(value / 2);
                updateValue();
            } else
            {
                value = limit(value - rangeMax);
                updateValue();
            }
        }

        private void NumericInMinus10_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                value = limit(value / 1.1);
                updateValue();
            }
            else
            {
                value = limit(value - rangeMax/10.0);
                updateValue();
            }
        }

        private void NumericInMinus1_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                value = limit(value / 1.01);
                updateValue();
            }
            else
            {
                value = limit(value - rangeMax/100.0);
                updateValue();
            }
        }

        private void NumericInPlus1_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                value = limit(value * 1.01);
                updateValue();
            }
            else
            {
                value = limit(value + rangeMax / 100.0);
                updateValue();
            }
        }

        private void NumericInPlus10_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                value = limit(value * 1.1);
                updateValue();
            }
            else
            {
                value = limit(value + rangeMax / 10.0);
                updateValue();
            }
        }

        private void NumericInPlus100_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                value = limit(value * 2);
                updateValue();
            }
            else
            {
                value = limit(value + rangeMax);
                updateValue();
            }
        }

        private void NumericInSetMin_Click(object sender, EventArgs e)
        {
            value = valMin;
            updateValue();
        }

        private void NumericInSetMax_Click(object sender, EventArgs e)
        {
            value = valMax;
            updateValue();
        }

        private void NumericInVal_TextChanged(object sender, EventArgs e)
        {
            double newVal = value;
            Boolean badInput = false;
            try
            {
                newVal = Convert.ToDouble(numericInVal.Text);
            } catch (Exception ex)
            {
                newVal = value;
                badInput = true;
            }
            if (hasLimits)
            {
                if (badInput || (newVal < valMin) || (newVal > valMax))
                {
                    if (!badInput)
                        value = limit(newVal);
                    numericInVal.ForeColor = Color.Red;
                }
                else
                {
                    value = newVal;
                    numericInVal.ForeColor = Color.Green;
                }
            } else
            {
                if (badInput)
                    numericInVal.ForeColor = Color.Red;
                else
                {
                    numericInVal.ForeColor = Color.Green;
                    value = newVal;
                }
            }

        }

        private void NumericInEnter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
