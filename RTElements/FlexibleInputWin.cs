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
    public partial class FlexibleInputWin : Form
    {
        public enum FlexibleInputWinType
        {
            String = 0,
            Integer,
            Float
        }
        FlexibleInputWinType type;
        double valMin;
        double valMax;
        public double floatValue;
        public int intValue;
        public string stringValue;
        double originalFloatValue;
        int originalIntValue;
        string originalStringValue;
        bool hasLimits;
        string name;
        string unit;
        string format;

        public FlexibleInputWin(string _name, string _unit, FlexibleInputWinType _type, string _format, 
            bool _hasLimits, double _valMin, double _valMax,
            string _stringValue, int _intValue, double _floatValue): base()
        {
            name = _name;
            unit = _unit;
            type = _type;
            format = _format;
            hasLimits = _hasLimits;
            valMin = _valMin;
            valMax = _valMax;
            stringValue = _stringValue;
            intValue = _intValue;
            floatValue = _floatValue;
            originalFloatValue = _floatValue;
            originalIntValue = _intValue;
            originalStringValue = _stringValue;         

            InitializeComponent();

            if ((format == null) || (format.Length < 1))
                format = "{0}";

            if ((unit == null) || (unit.Length < 1))
            {
                Width = numericInUnit.Location.X;
                numericInUnit.Visible = false;
            }
            else
                numericInUnit.Text = unit;

            updateValue();

            numericInVal.TextChanged += NumericInVal_TextChanged;

            KeyDown += NumericInputWin_KeyDown;

            //LostFocus += new EventHandler(lostFocus);

            KeyPreview = true;

            numericInVal.SelectAll();

        }

        public FlexibleInputWin(string _name, string _stringValue) : this(_name, null, FlexibleInputWinType.String, null, false, 0, 0, _stringValue, 0, 0)
        {
        }

        public FlexibleInputWin(string _name, int _intValue) : this(_name, null, FlexibleInputWinType.Integer, null, false, 0, 0, null, _intValue, 0)
        {
        }

        public FlexibleInputWin(string _name, string _unit, int _intValue) : this(_name, _unit, FlexibleInputWinType.Integer, null, false, 0, 0, null, _intValue, 0)
        {
        }

        public FlexibleInputWin(string _name, int _minVal, int _maxVal,int _intValue) : this(_name, null, FlexibleInputWinType.Integer, null, true, _minVal, _maxVal, null, _intValue, 0)
        {
        }

        public FlexibleInputWin(string _name, string _unit, int _minVal, int _maxVal, int _intValue) : this(_name, _unit, FlexibleInputWinType.Integer, null, true, _minVal, _maxVal, null, _intValue, 0)
        {
        }

        public FlexibleInputWin(string _name, double _doubleValue, string _format) : this(_name, null, FlexibleInputWinType.Float, _format, false, 0, 0, null, 0, _doubleValue)
        {
        }

        public FlexibleInputWin(string _name, string _unit, double _doubleValue, string _format) : this(_name, _unit, FlexibleInputWinType.Float, _format, false, 0, 0, null, 0, _doubleValue)
        {
        }

        public FlexibleInputWin(string _name, double _minVal, double _maxVal, double _doubleValue, string _format) : 
            this(_name, null, FlexibleInputWinType.Float, _format, true, _minVal, _maxVal, null, 0, _doubleValue)
        {
        }

        public FlexibleInputWin(string _name, string _unit, double _minVal, double _maxVal, double _doubleValue, string _format) :
            this(_name, _unit, FlexibleInputWinType.Float, _format, true, _minVal, _maxVal, null, 0, _doubleValue)
        {
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
        }

        private void NumericInputWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                switch (type)
                {
                    case FlexibleInputWinType.String:
                        stringValue = originalStringValue;
                        break;
                    case FlexibleInputWinType.Integer:
                        intValue = originalIntValue;
                        break;
                    case FlexibleInputWinType.Float:
                        floatValue = originalFloatValue;
                        break;
                }
                this.Close();
                return;
            }
            if (e.KeyCode == Keys.Enter)
                this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            /*
            if (owner != null)
                owner.clientWinClosed();
            owner = null;
            */
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

        private void updateValue()
        {
            switch (type)
            {
                case FlexibleInputWinType.String:
                    numericInVal.Text = stringValue;
                    break;
                case FlexibleInputWinType.Integer:
                    numericInVal.Text = String.Format("{0}", intValue);
                    if (hasLimits)
                    {
                        if ((intValue < valMin) || (intValue > valMax))
                            numericInVal.ForeColor = Color.Red;
                        else
                            numericInVal.ForeColor = Color.Green;
                    }
                    break;
                case FlexibleInputWinType.Float:
                    if ((format != null) && (format.Length > 0))
                        numericInVal.Text = String.Format(String.Format("{{0:{0}}}", format), floatValue);
                    else
                        numericInVal.Text = String.Format("{0:e}", floatValue);
                    if (hasLimits)
                    {
                        if ((intValue < valMin) || (intValue > valMax))
                            numericInVal.ForeColor = Color.Red;
                        else
                            numericInVal.ForeColor = Color.Green;
                    }
                    break;
            }
        }

        private void NumericInVal_TextChanged(object sender, EventArgs e)
        {
            switch (type)
            {
                case FlexibleInputWinType.String:
                    stringValue = numericInVal.Text;
                    break;
                case FlexibleInputWinType.Integer:
                    int storeInt = intValue;
                    try {
                        intValue = Convert.ToInt32(numericInVal.Text);
                        if (hasLimits && ((intValue < valMin) || (intValue > valMax)))
                            throw new Exception("Out of range");
                        numericInVal.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        numericInVal.ForeColor = Color.Red;
                        intValue = storeInt;
                    }
                    break;
                case FlexibleInputWinType.Float:
                    double storeFloat = floatValue;
                    try
                    {
                        floatValue = Convert.ToDouble(numericInVal.Text);
                        if (hasLimits && ((floatValue < valMin) || (floatValue > valMax)))
                            throw new Exception("Out of range");
                        numericInVal.ForeColor = Color.Green;
                    }
                    catch (Exception ex)
                    {
                        numericInVal.ForeColor = Color.Red;
                        floatValue = storeFloat;
                    }
                    break;
            }
        }

    }
}
