using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoAnalyser
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            _ = DownloadDadosAsync();
        }

        private async Task DownloadDadosAsync()
        {

            var options = new RestClientOptions("https://api.coinmarketcap.com/data-api/v3")
            {
                
            };
            var client = new RestClient(options);

            var request = new RestRequest($"cryptocurrency/listing?start=1&limit={txtQtde.Text}&sortBy=market_cap&sortType=desc&convert=USD&cryptoType=all&tagType=all&audited=false");

           
            var timeline = await client.GetAsync<CryptoInfo>(request);

            var dados = timeline.data.cryptoCurrencyList.OrderByDescending(x => x.quotes[0].volume24h).ToList();


            var convertModel = dados.Select(x => new ItemDataGrid()
            {
                Posicao = x.cmcRank,
                Simbolo = x.symbol,
                Nome = x.name,
                MarketCap = x.quotes[0].marketCap,
                Volume24h = x.quotes[0].volume24h,
                
            }).ToList();

            


            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowAutoFilterRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.OptionsMenu.ShowGroupSummaryEditorItem = true;
            gridView1.OptionsMenu.ShowGroupSortSummaryItems = true;
            gridView1.OptionsMenu.ShowFooterItem = true;
            gridView1.OptionsView.ShowFooter = true;

            if (gridView1.OptionsBehavior.Editable)
            {
                gridView1.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
                gridView1.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;

            }

            this.gridControl1.DataSource = convertModel;
            this.gridView1.BestFitColumns();
            //aa.Where(x => x.quotes[0].)
            //timeline.data.cryptoCurrencyList.OrderBy(x => x.quotes[0])
            //https://api.coinmarketcap.com/data-api/v3/cryptocurrency/listing?start=1&limit=200&sortBy=market_cap&sortType=desc&convert=USD&cryptoType=all&tagType=all&audited=false
        }


        public class ItemDataGrid
        {
            [Display(Name = "Rank")]
            public Int32 Posicao { get; set; }

            public String Simbolo { get; set; }
            public String Nome { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
            public Double MarketCap { get; set; }
            [DisplayFormat(DataFormatString = "{0:C}")]
            public Double Volume24h { get; set; }

            [DisplayFormat(DataFormatString = "{0:P2}")]
            public Double Percentual { get => (Volume24h / MarketCap ); }
        }

    }
}
