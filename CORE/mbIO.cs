
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.ComponentModel;
using System.IO;
using MaterialSkin.Controls;
using Newtonsoft.Json;

namespace GL8.CORE
{
    public partial class mbMainMenu : MaterialForm
    {
        // ------------------- Data Handling ----------------------
        public void LoadPSWDData()
        {
            var json = File.ReadAllText(mbFilePath);
            mbPSWDList = JsonConvert.DeserializeObject<BindingList<mbPSWD>>(json);

            if (mbPSWDList == null) { mbPSWDList = new BindingList<mbPSWD>(); }

            mbDataView.DataSource = mbPSWDList;
            this.Refresh();
        }
        private void CreateDataFileIfMissing()
        {
            if (!File.Exists(mbFilePath))
            {
                File.WriteAllText(mbFilePath, JsonConvert.SerializeObject(new BindingList<mbPSWD>()));
            }
        }
        public void SavePSWDData()
        {
            var json = JsonConvert.SerializeObject(mbPSWDList);
            File.WriteAllText(mbFilePath, JsonConvert.SerializeObject(mbPSWDList));
        }
    }
}