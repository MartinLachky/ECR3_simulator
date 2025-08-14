using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;
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
            rtbResponseDisplay.Clear();

            string cleanedJson = json.Replace("\"base\":", "\"baseAmount\":");

            try
            {
                var parsed = Newtonsoft.Json.JsonConvert.DeserializeObject<JToken>(cleanedJson);

                var sb = new StringBuilder();
                AppendProperties(parsed, sb, "");

                // If pretty-print produced output, show it
                if (sb.Length > 0)
                {
                    rtbResponseDisplay.AppendText(sb.ToString());
                }
                else
                {
                    // Parsing OK but nothing appended – still show original JSON
                    rtbResponseDisplay.AppendText(json);
                }
            }
            catch
            {
                rtbResponseDisplay.AppendText(json);
            }
        }

        private void AppendProperties(object node, StringBuilder sb, string indent)
        {
            if (node is JObject obj)
            {
                foreach (var prop in obj.Properties())
                {
                    if (prop.Value is JValue val) // simple value: one line
                    {
                        sb.AppendLine($"{indent}{prop.Name}: {val.Value}");
                    }
                    else // complex value: name on one line, then recurse
                    {
                        sb.AppendLine($"{indent}{prop.Name}:");
                        AppendProperties(prop.Value, sb, indent + "  ");
                    }
                }
            }
            else if (node is JArray arr)
            {
                foreach (var item in arr)
                {
                    sb.Append($"{indent}- ");
                    if (item is JValue val)
                    {
                        sb.AppendLine($"{val.Value}");
                    }
                    else
                    {
                        sb.AppendLine();
                        AppendProperties(item, sb, indent + "  ");
                    }
                }
            }
            else if (node is JValue val)
            {
                sb.AppendLine($"{indent}{val.Value}");
            }
        }


        private void rtbResponseDisplay_TextChanged(object sender, EventArgs e)
        {
            // Optionally leave empty, or add logic if needed



        }
    }
}
