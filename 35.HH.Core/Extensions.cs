using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Configuration;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;

using PixelSoftOffice.Web.Extensions;
using System.Windows.Forms;
using System.Drawing;

namespace _35.HH.Core
{
    public static class Extensions
    {
        #region Control Properities
        public static void SetControlProperty(this Control field, string propertyTitle, object value)
        {
            field.SetControlProperty(propertyTitle, new object[] { value });
        }
        public static void SetControlProperty(this Control field, string propertyTitle, object[] value)
        {
            field.SetControlProperties(new string[] { propertyTitle }, value);
        }
        public static void SetControlProperties(this Control field, string[] propertyTitles, object[] value)
        {
            Type fieldType = field.GetType();

            foreach (string propertyTitle in propertyTitles)
            {
                PropertyInfo propertyInfo = fieldType.GetProperty(GetPropertyNameForField(propertyTitle, fieldType.Name, false));
                if (propertyInfo != null)
                    //propertyInfo.SetValue(field, value != null ? (value[0] != null ? (value[0] is DataTable ? (DataTable)value[0] : TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFromString(value[0].ToString())) : null) : null);
                    //propertyInfo.SetValue(field, value != null ? (value[0] != null ? (value[0] is DataTable ? (DataTable)value[0] : TypeDescriptor.GetConverter(propertyInfo.PropertyType).ConvertFrom(value[0])) : null) : null);
                    propertyInfo.SetValue(field, value != null ? (value[0] != null ? (value[0] is DataTable ? (DataTable)value[0] : value[0]) : null) : null);
                else
                {
                    IEnumerable<MethodInfo> mInfos = fieldType.GetMethods().Where(x => x.Name == GetPropertyNameForField(propertyTitle, fieldType.Name, false) && x.GetParameters().Length == value.Length);
                    if (mInfos.Count() > 0)
                    {
                        MethodInfo mInfo = mInfos.ElementAt(0);
                        mInfo.Invoke(field, mInfo.GetParameters().Length > 0 ? value : new object[] { });
                    }
                }
            }
        }
        public static void SetControlsProperties(this Control parentControl, string[] fieldPaths, string[] propertyTitles, object value)
        {
            SetControlsProperties(parentControl, fieldPaths, propertyTitles, new object[] { value });
        }
        public static void SetControlsProperties(this Control parentControl, string[] fieldPaths, string[] propertyTitles, object[] value)
        {
            foreach (string fieldPath in fieldPaths)
            {
                string[] fieldNameItems = fieldPath.Split('.');

                List<Control> fields = new List<Control>();
                fields.Add(parentControl.FindControlRecursive(fieldNameItems[0]));

                Control containerControl = fields[0];
                if (fieldNameItems.Length > 1)
                    fields = new List<Control>();

                for (int i = 0; i < fieldNameItems.Length; i++)
                    CollectFields(fields, containerControl, fieldNameItems, i);

                foreach (Control field in fields)
                    field.SetControlProperties(propertyTitles, value);
            }
        }
        public static void CollectFields(List<Control> fields, Control containerControl, string[] fieldItems, int i)
        {
            if (fieldItems.Length == i + 1)
            {
                Control field = containerControl.FindControlRecursive(fieldItems[i]);
                if (field != null)
                    fields.Add(field);
            }
            else
            {
                Control[] containerItems = null;
                if (containerControl is DataGridView)
                    containerItems = (containerControl as DataGridView).Rows.Cast<Control>().ToArray();
                //else if (containerControl is System.Web.UI.WebControls.Repeater)
                //    containerItems = (containerControl as System.Web.UI.WebControls.Repeater).Items.Cast<Control>().ToArray();

                foreach (Control containerItem in containerItems)
                    CollectFields(fields, containerItem, fieldItems, i + 1);
            }
        }

        public static object GetControlProperty(this Control field, string propertyTitle)
        {
            object returnObject = null;

            Type fieldType = field.GetType();

            PropertyInfo propertyInfo = fieldType.GetProperty(GetPropertyNameForField(propertyTitle, fieldType.Name));
            if (propertyInfo != null)
                returnObject = propertyInfo.GetValue(field);
            else
            {
                IEnumerable<MethodInfo> mInfos = fieldType.GetMethods().Where(x => x.Name == GetPropertyNameForField(propertyTitle, fieldType.Name) && x.GetParameters().Length == 0);
                if (mInfos.Count() > 0)
                {
                    MethodInfo mInfo = mInfos.ElementAt(0);
                    returnObject = mInfo.Invoke(field, new object[] { });
                }
            }

            return returnObject;
        }
        public static Dictionary<string, object> GetControlProperties(this Control parentControl, string fieldName, string[] propertyTitles)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();

            Control field = parentControl.FindControlRecursive(fieldName);
            foreach (string propertyTitle in propertyTitles)
                properties.Add(propertyTitle, field.GetControlProperty(propertyTitle));

            return properties;
        }

        public static string GetPropertyNameForField(string properityTitle, string fieldTypeName)
        {
            return GetPropertyNameForField(properityTitle, fieldTypeName, true);
        }
        public static string GetPropertyNameForField(string properityTitle, string fieldTypeName, Boolean isForGet)
        {
            string propertyName = properityTitle;

            //try
            //{
            //    IEnumerable<Dictionary<string, object>> property = ControlPropertyNameMap.Where(x => Array.IndexOf(x["FieldTypeName"].ToString().Split(','), fieldTypeName) != -1 && x["PropertyTitle"].ToString() == properityTitle && (x["IsForGet"].ToNullableBoolean() ?? isForGet) == isForGet);
            //    if (property.Count() > 0)
            //        propertyName = property.ElementAt(0)["PropertyName"].ToString();
            //}
            //catch (Exception) { }

            return propertyName;
        }
        public static Control FindControlRecursive(this Control control, string controlName)
        {
            Control foundControl = null;

            foreach (Control child in control.Controls)
            {
                if (child.Name == controlName)
                {
                    foundControl = child;
                    break;
                }
            }

            if (foundControl == null)
            {
                foreach (Control child in control.Controls)
                {
                    if ((foundControl = child.FindControlRecursive(controlName)) != null)
                        break;
                }
            }

            return foundControl;
        }
        #endregion

        #region Set&Craete
        delegate void AddRowCallback(DataGridView gv, DataGridViewRow gc);
        delegate void UpdateRowCellsCallback(DataGridView gv, DataGridViewRow gvr, DataGridViewCellCollection gvrCells);
        delegate void AddColumnCallback(DataGridView gv, DataGridViewColumn gc);
        //delegate void SetVisibiltyCallback(Control control, Boolean visible);
        //delegate void SetTextCallback(Control control, string newText);
        delegate void AddItemCallback(ListBox lb, object item);
        delegate void ItemsClearCallback(ListBox lb);
        delegate void RowsClearCallback(DataGridView dgv);

        delegate void SetPropertyCallback(Control control, string propertyName, object value);
        delegate void SetBindingSourceCallback(BindingNavigator bn, BindingSource bs, IListSource datasource);

        delegate void ProcessDelegate();

        public static void AddRow(this DataGridView gv, DataGridViewRow gvr)
        {
            if (gv.InvokeRequired)
            {
                AddRowCallback _gvr = new AddRowCallback(AddRow);
                gv.Invoke(_gvr, new object[] { gv, gvr });
            }
            else
                gv.Rows.Add(gvr);
        }
        public static void UpdateRowCells(this DataGridView gv, DataGridViewRow gvr, DataGridViewCellCollection gvrCells)
        {
            if (gv.InvokeRequired)
            {
                UpdateRowCellsCallback _gvr = new UpdateRowCellsCallback(UpdateRowCells);
                gv.Invoke(_gvr, new object[] { gv, gvr, gvrCells });
            }
            else
                gvr.SetValues(gvrCells.Cast<DataGridViewCell>().Select(x => x.Value).ToArray());
        }
        public static void AddColumn(this DataGridView gv, DataGridViewColumn gc)
        {
            if (gv.InvokeRequired)
            {
                AddColumnCallback _gc = new AddColumnCallback(AddColumn);
                gv.Invoke(_gc, new object[] { gv, gc });
            }
            else
                gv.Columns.Add(gc);
        }
        //public static void SetVisibilty(this Control control, Boolean visible)
        //{
        //    if (control.InvokeRequired)
        //    {
        //        SetVisibiltyCallback _visible = new SetVisibiltyCallback(SetVisibilty);
        //        control.Invoke(_visible, new object[] { control, visible });
        //    }
        //    else
        //        control.Visible = visible;
        //}
        //public static void SetText(this Control control, string text)
        //{
        //    if (control.InvokeRequired)
        //    {
        //        SetTextCallback _text = new SetTextCallback(SetText);
        //        control.Invoke(_text, new object[] { control, text });
        //    }
        //    else
        //        control.Text = text;
        //}
        public static void AddItem(this ListBox lb, object item)
        {
            if (lb.InvokeRequired)
            {
                AddItemCallback _gvr = new AddItemCallback(AddItem);
                lb.Invoke(_gvr, new object[] { lb, item });
            }
            else
                lb.Items.Add(item);
        }
        public static void ItemsClear(this ListBox lb)
        {
            if (lb.InvokeRequired)
            {
                ItemsClearCallback _gvr = new ItemsClearCallback(ItemsClear);
                lb.Invoke(_gvr, new object[] { lb });
            }
            else
                lb.Items.Clear();
        }
        public static void RowsClear(this DataGridView dgv)
        {
            if (dgv.InvokeRequired)
            {
                RowsClearCallback _dgv = new RowsClearCallback(RowsClear);
                dgv.Invoke(_dgv, new object[] { dgv });
            }
            else
                dgv.Rows.Clear();
        }

        public static void SetPropertyInThread(this Control control, string propertyName, object value)
        {
            if (control.InvokeRequired)
            {
                SetPropertyCallback _control = new SetPropertyCallback(SetPropertyInThread);
                control.Invoke(_control, new object[] { control, propertyName, value });
            }
            else
                //control.SetProperty(propertyName, value);
                control.SetControlProperty(propertyName, value);
        }
        public static void SetBindingSourceSource(this BindingNavigator bn, BindingSource bs, IListSource datasource)
        {
            if (bn.InvokeRequired)
            {
                SetBindingSourceCallback _bn = new SetBindingSourceCallback(SetBindingSourceSource);
                bn.Invoke(_bn, new object[] { bn, bs, datasource });
            }
            else
                bs.DataSource = datasource;
        }
        #endregion

        #region Drawing
        public static Bitmap Resize(this Bitmap img, Size size)
        {
            Bitmap b = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, size.Width, size.Height);
            }

            return b;
        }
        #endregion

        public static Dictionary<string, object> ToDictionary(this DataRow dr)
        {
            return dr.Table.Columns.Cast<DataColumn>().ToDictionary(col => col.ColumnName, col => dr[col.ColumnName]);
        }
    }
}
