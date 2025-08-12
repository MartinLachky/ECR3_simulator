using System;
using System.Windows.Forms;

namespace ECR3_simulator
{
    public partial class FormResponse : Form
    {
        public FormResponse()
        {
            InitializeComponent();
        }

        public void ShowResponse(string json)
        {
            // Parse JSON → Root model
            string cleanedJson = json.Replace("\"base\":", "\"baseAmount\":");

            try
            {
                var parsed = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(cleanedJson);

                // Build pretty string with all non-empty values
                var sb = new System.Text.StringBuilder();
                AppendProperties(parsed, sb, "");

                rtbResponseDisplay.Text = sb.ToString();
            }
            catch
            {
                // If parsing fails, just show raw JSON
                rtbResponseDisplay.Text = json;
            }
        }

        private void AppendProperties(object obj, System.Text.StringBuilder sb, string indent)
        {
            if (obj == null)
                return;

            // Handle lists
            if (obj is System.Collections.IEnumerable enumerable && !(obj is string))
            {
                foreach (var item in enumerable)
                {
                    AppendProperties(item, sb, indent + "  ");
                }
                return;
            }

            var type = obj.GetType();
            var props = type.GetProperties();

            if (props.Length > 0) // Complex object
            {
                foreach (var prop in props)
                {
                    var value = prop.GetValue(obj, null);

                    if (value == null)
                        continue;

                    // If it's a string, skip empty
                    if (value is string strVal && string.IsNullOrWhiteSpace(strVal))
                        continue;

                    // If complex object or list, recurse
                    if (!(value is string) && !(value.GetType().IsValueType))
                    {
                        sb.AppendLine($"{indent}{prop.Name}:");
                        AppendProperties(value, sb, indent + "  ");
                    }
                    else
                    {
                        sb.AppendLine($"{indent}{prop.Name}: {value}");
                    }
                }
            }
            else
            {
                // Primitive value type
                sb.AppendLine($"{indent}{obj}");
            }
        }
        private void rtbResponseDisplay_TextChanged(object sender, EventArgs e)
        {
            // Optionally leave empty, or add logic if needed



        }
    }
}
