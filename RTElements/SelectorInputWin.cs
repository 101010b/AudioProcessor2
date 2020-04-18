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
    public partial class SelectorInputWin : Form
    {

        public RTSelector RTowner;
        // public ProcessingControl owner;
        String name;
        List<string> options;
        public int selection;
        int originalSelection;

        public SelectorInputWin(string _name, List<string> _options, int _selection)
        {
            name = _name;
            // owner = null;
            RTowner = null;
            options = _options;
            selection = _selection;
            originalSelection = selection;

            InitializeComponent();

            foreach (string s in options)
                SelectorWinList.Items.Add(s);

            SelectorWinList.SelectedIndex = selection;
            SelectorWinList.Click += SelectorWinList_Click;
            SelectorWinList.SelectedIndexChanged += SelectorWinList_SelectedIndexChanged;
            SelectorWinList.DrawMode = DrawMode.OwnerDrawFixed;
            SelectorWinList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(selectorBox_DrawItem);

            KeyDown += SelectorInputWin_KeyDown;

            KeyPreview = true;
        }

        private void selectorBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          Color.DimGray);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(SelectorWinList.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        /*
        public SelectorInputWin(ProcessingControl _owner, string _name, List<string> _options, int _selection):
            this(_name,_options,_selection)
        {
            owner = _owner;
        }
        */
        public SelectorInputWin(RTSelector _owner, string _name, List<string> _options, int _selection):
            this(_name,_options,_selection)
        {
            RTowner = _owner;
        }

        private void SelectorWinList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selection = SelectorWinList.SelectedIndex;
            Invalidate();
        }

        private void SelectorWinList_Click(object sender, EventArgs e)
        {
            selection = SelectorWinList.SelectedIndex;
            this.Close();
        }

        private void SelectorInputWin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                selection = originalSelection;
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

    }
}
